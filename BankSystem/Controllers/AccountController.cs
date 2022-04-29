using BankSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankSystem.Controllers
{
    public class AccountController : Controller
    {
        #region private field
        private readonly ILogger<AccountController> logger;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        #endregion

        #region constructor
        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, ILogger<AccountController> logger)
        {
            this.logger = logger;
            this.userManager = userManager;
            this.signInManager = signInManager;

        }
        #endregion

        #region public method

        //method to registor 
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = registerViewModel.Email, Email = registerViewModel.Email };
                var result = await userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);//non persistanc
                    logger.LogInformation("New User Register");
                    return RedirectToAction("AddCustomer", "Customer");

                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(registerViewModel);
        }

        //method to login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        public async Task<IActionResult> Login(UserLogin userLogin)
        {


            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(userLogin.LoginId,
                    userLogin.Password, userLogin.RememberMe, false);//false lock user
                if (result.Succeeded)
                {

                    logger.LogInformation("User Logged");
                    return RedirectToAction("CustomerHomePage", "Home");
                }
            }
            return View(userLogin);

        }

        // method to change password

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> PasswordChange()
        {
            ViewBag.isTrue = false;
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PasswordChange(UserPassword userPassword)
        {
            ViewBag.isTrue = false;

            if (ModelState.IsValid)
            {
                ViewBag.isTrue = false;
                var current_User = userManager.GetUserAsync(HttpContext.User).Result;
                string current_User_Id = current_User.Id;
                string current_User_Email = current_User.Email;
                var user = await userManager.FindByIdAsync(current_User_Id);

                bool result1 = await userManager.CheckPasswordAsync(user, userPassword.OldPassword);
                if (result1)
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);

                    var result = await userManager.ResetPasswordAsync(user, token, userPassword.Password);
                    if (result.Succeeded)
                    {

                        ViewBag.isTrue = true;
                        ViewBag.pass = 1;
                        ViewBag.errorMessage = "Password changed successfully !!!";
                        logger.LogInformation("User Changed Password");
                    }
                    else
                    {
                        ViewBag.isTrue = true;
                        ViewBag.errorMessage = "Problem while changing password";
                    }
                }
                else
                {
                    ViewBag.isTrue = true;
                    ViewBag.errorMessage = "Old Password is not matching";
                }


            }
            return View();

        }
        //
        //method to logout

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            logger.LogInformation("User Logged Out");
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}

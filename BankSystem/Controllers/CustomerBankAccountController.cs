using BankSystem.Models;
using BusinessLayer.Contract;
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
    public class CustomerBankAccountController : Controller
    {
        #region private field
        private readonly ILogger<CustomerBankAccountController> logger;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IAccountManager accountManager;
        #endregion

        #region constructor
        public CustomerBankAccountController(UserManager<IdentityUser> userManager,
            IAccountManager accountManager, ILogger<CustomerBankAccountController> logger)
        {
            this.logger = logger;
            this.userManager = userManager;
            this.accountManager = accountManager;
        }

        #endregion

        #region public method
        public IActionResult Index()
        {
            return View();
        }

        //method for account details

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> AccountDetails()
        {

            var current_User = userManager.GetUserAsync(HttpContext.User).Result;
            string current_User_Id = current_User.Id;

            var result = await this.accountManager.GetAllAccounts(current_User_Id);

            return View(result);

        }

        //method to create account

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> CreateAccount()
        {
            
            ViewBag.isTrue = false;
            return View();


        }

        
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateAccount(AccountViewModel accountViewModel)
        {
            ViewBag.isTrue = false;

            try
            {
                if (accountViewModel.AccountType.Equals("Saving") && accountViewModel.Balance < 1000)
                {

                    ViewBag.isTrue = true;
                    ViewBag.errorMessage = "Initial Deposit Must Be Greter Than 1000";
                    return View();
                }
                if (accountViewModel.AccountType.Equals("Current") && accountViewModel.Balance < 5000)
                {
                    ViewBag.isTrue = true;
                    ViewBag.errorMessage = "Initial Deposit Must Be Greter Than 5000";
                    return View();
                }
                var current_User = userManager.GetUserAsync(HttpContext.User).Result;
                string current_User_Id = current_User.Id;
                CommonLayer.Models.Account account = new CommonLayer.Models.Account()
                {
                    CustomerId = current_User_Id,
                    CreateDate = DateTime.UtcNow,
                    AccountType = accountViewModel.AccountType,
                    Balance = accountViewModel.Balance,


                };

                var newAccount = await this.accountManager.AddAccount(account);
                if (newAccount != null)
                {
                    ViewBag.isTrue = true;
                    ViewBag.pass = 1;
                    ViewBag.errorMessage = "Account Created Successfully !!!";
                    logger.LogInformation("New Account is created by customer "+current_User_Id);
                }
                else
                {
                    ViewBag.isTrue = true;
                    ViewBag.errorMessage = "Failed To Create Account";
                }

            }
            catch (Exception)
            {

                ViewBag.isTrue = true;
                ViewBag.errorMessage = "Something Went Wrong";
            }
            return View();

        }


        //method to check account balance
        [HttpGet]
        [Authorize]
        public  ActionResult BalancCheck()
        {

            ViewBag.id = 0;
            return View();

        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> BalancCheck(int id)
        {
           

            try
            {
                
                var current_User = userManager.GetUserAsync(HttpContext.User).Result;
                string current_User_Id = current_User.Id;

                var result = await this.accountManager.GetAllAccounts(current_User_Id);
                foreach (var item in result)
                {
                    if (item.AccountNo == id)
                    {
                        var balance = await this.accountManager.BalanceCheck(id);
                        if(balance!=0)
                        {
                           
                            ViewBag.pass = 1;
                            ViewBag.No = id;
                            ViewBag.balance = balance;
                            return View();
                        }

                        

                    }

                }

               
                ViewBag.pass = 0;
                ViewBag.errorMessage = "Given Source account no is not associate with customer";

                return View();


            }
            catch (Exception)
            {

                ViewBag.isTrue = true;
                ViewBag.errorMessage = "Something Went Wrong";
            }
            return View();

        }




        #endregion

    }
}

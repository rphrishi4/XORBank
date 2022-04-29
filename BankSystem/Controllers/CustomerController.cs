using BankSystem.Models;
using BusinessLayer.Contract;
using CommonLayer.Models;
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
    public class CustomerController : Controller
    {
        #region private field
        private readonly ILogger<CustomerController> logger;
        private readonly ICustomerManager customerManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IAccountManager accountManager;
        private readonly ITransactionManager transationManager;

        #endregion

        #region constructor
        public CustomerController(ICustomerManager customerManager, UserManager<IdentityUser> userManager, 
            IAccountManager accountManager, ITransactionManager transationManager, ILogger<CustomerController> logger)
        {
            this.logger = logger;
            this.customerManager = customerManager;
            this.userManager = userManager;
            this.accountManager = accountManager;
            this.transationManager = transationManager;
        }
        #endregion

        #region public method

        public IActionResult Index()
        {
            return View();
        }

        //method to addcustomer
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> AddCustomer()
        {
            
            var currentUser = userManager.GetUserAsync(HttpContext.User).Result;  
            ViewBag.email = currentUser.Email;
            var currentUserId = currentUser.Id;
            var result = await this.customerManager.GetCustomer(currentUserId);
            if (result != null)
            {
                BankSystem.Models.Customer result1 = new BankSystem.Models.Customer()
                {
                    CustomerId = result.CustomerId,
                    CustomerName = result.CustomerName,
                    City = result.City,
                    DateOfBirth = result.DateOfBirth,
                    Pin = result.Pin,
                    State = result.State,
                    MobileNo = result.MobileNo,
                    Address = result.Address,
                    Gender = result.Gender,
                    EmailId = result.EmailId,
                };
                if (result1 != null)
                {
                    return View(result1);
                }
            }
            return View();
            
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddCustomer(CommonLayer.Models.Customer customer)
        {
           
            if (ModelState.IsValid)
            {
                var current_User = userManager.GetUserAsync(HttpContext.User).Result;
                string current_User_Id = current_User.Id;
                ViewBag.email = current_User.Email;
                var customer1 = new CommonLayer.Models.Customer()
                {
                    CustomerId = current_User_Id,
                    CustomerName = customer.CustomerName,
                    City = customer.City,
                    DateOfBirth = customer.DateOfBirth,
                    Pin = customer.Pin,
                    State = customer.State,
                    MobileNo =customer.MobileNo,
                    Address = customer.Address,
                    Gender = customer.Gender,
                    EmailId = customer.EmailId,
                };

                var result = await this.customerManager.AddCustomer(customer1);
                logger.LogInformation(" customer updated information " + current_User_Id);
                if (result != null)
                {
                    var result1 = new BankSystem.Models.Customer()
                    {
                        CustomerId = result.CustomerId,
                        CustomerName = result.CustomerName,
                        City = result.City,
                        DateOfBirth = result.DateOfBirth,
                        Pin = result.Pin,
                        State = result.State,
                        MobileNo = result.MobileNo,
                        Address = result.Address,
                        Gender = result.Gender,
                        EmailId = result.EmailId,
                    };
                    return View(result1);
                }
                //  return RedirectToAction("CustomerForm", new { @customer = result});
                
            }
            return View(customer);
        }






        //[Authorize]

        //    public IActionResult CustomerForm()
        //    {
        //        var current_User = userManager.GetUserAsync(HttpContext.User).Result;
        //        string current_User_Id = " " + current_User.Id;
        //        ViewBag.current_User_Id = current_User_Id;

        //        return View();
        //    }
        //[HttpGet]
        //public IActionResult CustomerForm(Customer customer)
        //{

        //    ViewBag.result = customer;
        //    return View();
        //}
        #endregion

    }
}
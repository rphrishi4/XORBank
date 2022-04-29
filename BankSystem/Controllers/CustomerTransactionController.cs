using AutoMapper;
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
    public class CustomerTransactionController : Controller
    {
        #region private field
        private readonly ILogger<CustomerTransactionController> logger;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IAccountManager accountManager;
        private readonly ITransactionManager transationManager;
        private readonly IMapper mapper;

        #endregion

        #region constructor
        public CustomerTransactionController(UserManager<IdentityUser> userManager,
            IAccountManager accountManager, ITransactionManager transationManager, IMapper mapper, ILogger<CustomerTransactionController> logger)
        {
            this.logger = logger;
            this.userManager = userManager;
            this.accountManager = accountManager;
            this.transationManager = transationManager;
            this.mapper = mapper;
        }
        #endregion

        #region public method
        public IActionResult Index()
        {
            return View();
        }

        //method for fund transfer

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> FundTranfer()
        {
            ViewBag.isTrue = false;
            ViewBag.errorMessage = " ";
            return View();
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult> FundTranfer(BankSystem.Models.TransactionViewModel transaction)
        {
            @ViewBag.istrue = false;
            try
            {

                var current_User = userManager.GetUserAsync(HttpContext.User).Result;
                string current_User_Id = current_User.Id;
                Transaction newTransaction = new Transaction()
                {
                   
                    FromAccountNo = transaction.FromAccountNo,
                    ToAccountNo = transaction.ToAccountNo,
                    TransactionAmount = transaction.TransactionAmount,
                    TransactionDate = DateTime.UtcNow,
                    TransactionType ="Net Banking",
                    Description= transaction.Description

                };

                var result = await this.accountManager.GetAllAccounts(current_User_Id);
                foreach (var item in result)
                {
                    if (item.AccountNo == transaction.FromAccountNo)
                    {
                        bool isTrue = await this.transationManager.MakeTransaction(newTransaction);
                        ViewBag.isTrue = isTrue;
                        ViewBag.pass = 1;
                        ViewBag.errorMessage = "Successful done";
                        logger.LogInformation("Customer Tranfer Money");

                        return View();

                    }

                }

                ViewBag.isTrue = true;
                ViewBag.errorMessage = "Given Payer account no is not associate with customer";

                return View();


            }
            catch (Exception e)
            {
                ViewBag.isTrue = true;
                ViewBag.errorMessage = e.Message;
                return View();

            }
            finally
            {

            }
        }

        //method for ministatement

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> MiniStatement()
        {

            ViewBag.isTrue = false;
            return View(); 
        }

         [HttpPost]
        [Authorize]
        public async Task<ActionResult> MiniStatement(int accountNo)
        {
            

            var current_User = userManager.GetUserAsync(HttpContext.User).Result;
            string current_User_Id = current_User.Id;
           
          

            var result = await this.accountManager.GetAllAccounts(current_User_Id);
            //<CommonLayer.Models.Transaction> listOfStatement = new List<Transaction>();
            foreach (var item in result)
            {
                if (item.AccountNo == accountNo)
                {
                    
                    var listOfStatement = await this.transationManager.MiniStatement(accountNo);
                    List<BankSystem.Models.TransactionViewModel> statements = new List<TransactionViewModel>();
                    foreach (var transaction in listOfStatement)
                    {
                        TransactionViewModel transactionView = new TransactionViewModel()
                        {

                            TransactionAmount = transaction.TransactionAmount,
                            TransactionDate = transaction.TransactionDate,
                            TransactionId = transaction.TransactionId,
                            TransactionType = transaction.TransactionType,
                            ToAccountNo = transaction.ToAccountNo,
                            FromAccountNo = transaction.FromAccountNo,
                            FromAccountBalance=transaction.FromAccountBalance,
                            ToAccountBalance=transaction.ToAccountBalance,
                            Description = transaction.Description,


                        };
                        statements.Add(transactionView);
                    }
                    if (listOfStatement==null)
                    {

                        ViewBag.isTrue = true;
                        ViewBag.errorMessage = "No Transaction";
                    }

                    ViewBag.isTrue = false;
              
                    return View(statements);
                }
                else
                {
                    ViewBag.isTrue = true;
                    ViewBag.errorMessage = "Given account no is not associate with customer";
                }
               
            }

            return View();


        }


        //method for Customized statement
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> CustomizedStatement()
        {

            ViewBag.isTrue = false;
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CustomizedStatement(int accountNo,DateTime fromDate,DateTime toDate)
        {
            ViewBag.isTrue = false;

            var current_User = userManager.GetUserAsync(HttpContext.User).Result;
            string current_User_Id = current_User.Id;

            var result = await this.accountManager.GetAllAccounts(current_User_Id);
            List<BankSystem.Models.TransactionViewModel> statements = new List<TransactionViewModel>();
            foreach (var item in result)
            {
                if (item.AccountNo == accountNo)
                {

                    var listOfStatement = await this.transationManager.CustomizedStatement(accountNo,fromDate,toDate);
                    foreach (var transaction in listOfStatement)
                    {
                        TransactionViewModel transactionView = new TransactionViewModel()
                        {
                            
                            TransactionAmount = transaction.TransactionAmount,
                            TransactionDate = transaction.TransactionDate,
                            TransactionId = transaction.TransactionId,
                            TransactionType = transaction.TransactionType,
                            ToAccountNo = transaction.ToAccountNo,
                            FromAccountNo = transaction.FromAccountNo,
                            FromAccountBalance = transaction.FromAccountBalance,
                            ToAccountBalance = transaction.ToAccountBalance,
                            Description =transaction.Description,
                           

                        };
                        statements.Add(transactionView);
                    }

                    TransactionViewModel transactionViewModel = new TransactionViewModel();
                    if (listOfStatement == null)
                    {

                        ViewBag.isTrue = true;
                        ViewBag.errorMessage = "No Transaction";
                    }

                    ViewBag.isTrue = false;
                    return View(statements);
                }
                else
                {
                    ViewBag.isTrue = true;
                    ViewBag.errorMessage = "Given account no is not associate with customer";
                }

            }

            return View();


        }

        #endregion
    }
}

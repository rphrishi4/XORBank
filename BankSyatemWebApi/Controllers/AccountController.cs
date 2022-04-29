using BusinessLayer.Contract;
using CommonLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankSyatemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region private field
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ICustomerManager customerManager;

        private readonly IAccountManager accountManager;

        #endregion

        
        #region constructore
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, 
            IAccountManager accountManager, ICustomerManager customerManager)
        {
            this.customerManager = customerManager;
            this.accountManager= accountManager;


            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        #endregion


        #region public method

        /// <summary>
        /// Method to Delete Account
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        /// <remark>
        /// Delete Account
        /// 
        /// 
        /// api/Account/DeleteAccount
        /// </remark>>
        [HttpDelete("{accountId:int}")]
       
        public async Task<ActionResult> DeleteAccount(int accountId)
        {
            try
            {

                if (await this.accountManager.DeleteAccount(accountId))
                {
                    return Ok($"Account is Deleted ");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error while Deleting Customer" + e.Message);
            }

        }

        /// <summary>
        /// Method to Get All account
        /// </summary>
        /// <returns></returns>
        /// <remark>
        /// Get All Account
        /// 
        /// 
        /// api/Account/Get
        /// </remark>>
        [HttpGet]
        [Route("Get")]
        
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await this.accountManager.GetAllAccounts();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception )
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error whilw retriving data from the server");
            }
        }

        /// <summary>
        /// Method to Search Account
        /// </summary>
        /// <param name="accountNo"></param>
        /// <returns></returns>
        /// <remark>
        /// Search Account
        /// 
        /// 
        /// api/Account/Get/accountId=1
        /// </remark>>

        [HttpGet("{accountNo:int}")]

        public async Task<ActionResult> Get(int accountNo)
        {
            try
            {
                var result = await this.accountManager.GetAccount(accountNo);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error whilw retriving data from the server");
            }
        }

        /// <summary>
        /// Method to Create Account for customer
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        ///  /// <remark>
        /// Add Account
        /// 
        /// 
        /// api/Account/CreateAccount
        /// </remark>>

        [HttpPost]
        [Route("CreateAccount")]
        public async Task<ActionResult> CreateAccount(Account account)
        {
            try
            {
                if (account == null)

                {
                    return BadRequest();
                }
                if ((account.AccountType == "Saving" && account.Balance >= 1000) || (account.AccountType == "Current" && account.Balance >= 5000))
                {
                    var result = await this.customerManager.Search(account.CustomerEmail);
                    account.CustomerId = result.CustomerId;
                    account.CreateDate = DateTime.UtcNow;
                    var newAccount = await this.accountManager.AddAccount(account);

                    return CreatedAtAction(nameof(Get), new { accountNo = newAccount.AccountNo }, newAccount);
                }
                return BadRequest($"Account type is Current then initial deposit > 1000 and if Saving then initial deposit >= 5000 ");
            }
            catch (Exception )
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error while creating account");
            }
        }

        /// <summary>
        /// Method to update Account for customer
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        ///  /// <remark>
        /// Update Account
        /// 
        /// 
        ///  api/Account/UpdateAccount
        /// </remark>>
        [HttpPost]
        [Route("UpdateAccount")]
        public async Task<ActionResult> UpdateAccount(Account account)
        {
            try
            {
                if (account == null)

                {
                    return BadRequest();
                }

                var newAccount = await this.accountManager.UpdateAccount(account);

                return CreatedAtAction(nameof(Get), new { accountNo = newAccount.AccountNo }, newAccount);

            }
            catch (Exception )
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error while updating account");
            }
        }

        /// <summary>
        /// Method to Check Account Balance
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remark>
        ///  Update Account
        /// 
        /// 
        ///  api/Account/CreateAccount
        /// </remark>>
        [HttpGet]
        [Route("BalanceCheck")]
        public async Task<ActionResult> BalanceCheck(int id)
        {
            try
            {
                if (id == 0)

                {
                    return BadRequest();
                }

                var newAccount = await this.accountManager.BalanceCheck(id);
                if(newAccount==0)
                {
                    return NotFound();
                }
                return Ok(newAccount);

            }
            catch (Exception )
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error while checking balance  ");
            }
        }
        #endregion
    }



}


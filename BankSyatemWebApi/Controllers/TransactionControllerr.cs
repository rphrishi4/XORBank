using BusinessLayer.Contract;
using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankSyatemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionControllerr : ControllerBase
    {
        #region private field
        private readonly ITransactionManager transactionManager;
        #endregion

        public TransactionControllerr(ITransactionManager transactionManager)
        {
            this.transactionManager = transactionManager;
        }
        #region public method

        /// <summary>
        /// Method to Deposit 
        /// 
        /// </summary>
        /// <param name="transaction"> 
        ///  <see> Required field = 
        ///   toAccountNo ,
        ///   transaction amount ,
        ///   transaction Type  ,
        ///   description
        ///   </see>
        /// </param>
        /// <remark>
        /// </remark>
        /// <returns></returns>


        [HttpPost]
        [Route("Deposit")]
        public async Task<ActionResult> Deposit(Transaction transaction)
        {
            try
            {

                if (transaction != null)
                {
                    string type = "Deposit";  
                    Transaction newTransaction = new Transaction()
                    {
                        ToAccountNo = transaction.ToAccountNo,
                        TransactionAmount = transaction.TransactionAmount,
                        TransactionDate = DateTime.Now,
                        TransactionType = type,
                        Description = transaction.Description


                       
                        

                    };

                    if (await this.transactionManager.DepositWithdrawal(transaction))
                    {
                        return Ok($"Successful ");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                return Ok("Something is missing");
            }
            catch (Exception )
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error while Transfering Money" );
            }
        }

        /// <summary>
        /// Method for MiniStatement
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("MiniStatement")]
        public async Task<ActionResult> MiniStatement(int accountId)
        {
            try
            {

                if (accountId !=0)
                {

                    var list = await this.transactionManager.MiniStatement(accountId);
                    if(list !=null)
                    {
                        return Ok(list);
                    }
                    return Ok("No Transaction");

                   
                }
                return Ok("Something is Wrong");
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error while Transfering Money" + e.Message);
            }
        }

        /// <summary>
        /// Method to get CustomizedStatement
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="fromDate"></param>
        /// <param name="todate"></param>
        /// <returns></returns>


        [HttpGet]
        [Route("CustomizedStatement")]
        public async Task<ActionResult> CustomizedStatement(int accountId ,DateTime fromDate,DateTime todate)
        {
            try
            {

                if (accountId != 0)
                {

                    var list = await this.transactionManager.CustomizedStatement(accountId,fromDate,todate);
                    if (list != null)
                    {
                        return Ok(list);
                    }
                    return Ok("No Transaction");


                }
                return Ok("Something is Wrong");
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error while Transfering Money" + e.Message);
            }
        }
        /// <summary>
        /// Method for Withdrawal
        /// </summary>
        /// <param name="transaction">
        ///  <see> Required field = 
        ///   fromAccountNo ,
        ///   transaction amount ,
        ///   transaction Type  ,
        ///   description
        ///   </see>
        ///   </param>
        /// <returns></returns>

        [HttpPost]
        [Route("Withdrawal")]
        public async Task<ActionResult> Withdrawal(Transaction transaction)
        {
            try
            {

                if (transaction != null)
                {
                    string type = "Withdrawal";

                    Transaction newTransaction = new Transaction()
                    {

                        ToAccountNo = transaction.ToAccountNo,
                        FromAccountNo=transaction.FromAccountNo,
                        TransactionAmount = transaction.TransactionAmount,
                        TransactionDate = DateTime.UtcNow,
                        TransactionType = type,
                        Description = transaction.Description

                    };

                    if (await this.transactionManager.DepositWithdrawal(transaction))
                    {
                        return Ok($"Successful ");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                return Ok("Something is missing");
            }
            catch (Exception )
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error while Transfering Money" );
            }
        }

        #endregion
    }
}

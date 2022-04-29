using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contract
{
    public interface ITransactionManager
    {

        /// <summary>
        /// Method to Make Transaction
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public Task<bool> MakeTransaction(Transaction transaction);

        /// <summary>
        /// Method to get Mini Statement
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public Task<IEnumerable<CommonLayer.Models.Transaction>> MiniStatement(int accountId);
        /// <summary>
        /// Method To get CustomizedStatement
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public Task<IEnumerable<CommonLayer.Models.Transaction>> CustomizedStatement(int accountId, DateTime fromDate, DateTime toDate);
        /// <summary>
        /// Method To DepositWithdrawal
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public Task<bool> DepositWithdrawal(Transaction transaction);
    }
}

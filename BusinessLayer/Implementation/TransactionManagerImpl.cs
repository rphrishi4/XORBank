using BusinessLayer.Contract;
using CommonLayer.Models;
using EFDataLayer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation
{
    public class TransactionManagerImpl : ITransactionManager
    {
        #region private field
        private readonly ITransactionRepo transactionRepo;
        #endregion

        #region constructor
        public TransactionManagerImpl(ITransactionRepo transactionRepo)
        {
            this.transactionRepo = transactionRepo;
        }
        #endregion

        #region public method

        public Task<IEnumerable<Transaction>> CustomizedStatement(int accountId, DateTime fromDate, DateTime toDate)
        {
            return this.transactionRepo.CustomizedStatement(accountId,fromDate,toDate);
        }

        public Task<bool> DepositWithdrawal(Transaction transaction)
        {
            return this.transactionRepo.DepositWithdrawal(transaction);
        }

        public async Task<bool> MakeTransaction(Transaction transaction)
        {
            return await this.transactionRepo.MakeTransaction(transaction);
        }

        public async Task<IEnumerable<Transaction>> MiniStatement(int accountId)
        {
            return await this.transactionRepo.MiniStatement(accountId);
        }

        #endregion
    }
}

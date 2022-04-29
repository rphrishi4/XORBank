using AutoMapper;
using EFDataLayer.Contract;
using EFDataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataLayer.Implementation
{
    public class TransactionRepoImpl : ITransactionRepo
    {
        #region private field
        private readonly Bank_DbContext context;
        private IMapper mapper;
        #endregion

        #region public constructor
        public TransactionRepoImpl(Bank_DbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        #endregion

        #region public Method
        /// <summary>
        /// Method to Get customized statement of an account
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CommonLayer.Models.Transaction>> CustomizedStatement(int accountId, DateTime fromDate, DateTime toDate)
        {
            List<CommonLayer.Models.Transaction> transactions = new List<CommonLayer.Models.Transaction>();

            if (accountId != 0)
            {

                var results = await this.context.Transactions.Where(x => x.TransactionDate >= fromDate).Where(x => x.TransactionDate <= toDate).ToListAsync();
                //var result1 = (from s in this.context.Transactions where s.TransactionDate >=fromDate select s).ToList();
                //var results = (from s in result1 where s.TransactionDate <= toDate select s).ToList();
                transactions = StatementMap(results, accountId);
            }
            return transactions;

        }
        /// <summary>
        /// Method To get depositwithdrawal 
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<bool> DepositWithdrawal(CommonLayer.Models.Transaction transaction)
        {
            try
            {

                bool isTrue = false;
                int result;
                //var transactionAmount = transaction.TransactionAmount;
                if (transaction != null)
                {
                    if (transaction.TransactionType.Equals("Deposit"))
                    {
                         result = await this.context.Database.ExecuteSqlRawAsync(" EXEC sp_depositWithdrawal @accountNo={0},@transactionType={1},@amount={2}", transaction.ToAccountNo, transaction.TransactionType, transaction.TransactionAmount);
                    }
                    else
                    {
                         result = await this.context.Database.ExecuteSqlRawAsync(" EXEC sp_depositWithdrawal @accountNo={0},@transactionType={1},@amount={2}", transaction.FromAccountNo, transaction.TransactionType, transaction.TransactionAmount);

                    }
                    if (result > 0)
                    {

                        var newTrans = mapper.Map<EFDataLayer.Model.Transaction>(transaction);
                        if (transaction.TransactionType.Equals("Deposit"))
                        {
                            var resultAccount = await this.context.Accounts.Where(X => X.IsDeleted == 0).FirstOrDefaultAsync(x => x.AccountNo == transaction.ToAccountNo);

                            newTrans.ToAccountBalance = resultAccount.Balance;
                            newTrans.TransactionDate = DateTime.UtcNow;
                        }
                        if (transaction.TransactionType.Equals("Withdrawal"))
                        {
                           var resultAccount = await this.context.Accounts.Where(X => X.IsDeleted == 0).FirstOrDefaultAsync(x => x.AccountNo == transaction.FromAccountNo);

                            newTrans.FromAccountBalance = resultAccount.Balance;
                            newTrans.TransactionDate = DateTime.UtcNow;
                        }
                        await this.context.Transactions.AddAsync(newTrans);
                        await this.context.SaveChangesAsync();

                        isTrue = true;
                    }

                }
                return isTrue;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        /// <summary>
        /// Method to make transaction
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>

        public async Task<bool> MakeTransaction(CommonLayer.Models.Transaction transaction)
        {


            try
            {
                if (transaction != null)
                {

                    int result = await this.context.Database.ExecuteSqlRawAsync(" EXEC sp_MakeTransation @sourceAccount={0},@destinationAccount={1},@amount={2},@transactionDate={3},@transactionType={4},@description={5} ", transaction.FromAccountNo, transaction.ToAccountNo, transaction.TransactionAmount, transaction.TransactionDate, transaction.TransactionType, transaction.Description);
                    if (result > 0)
                    {
                        return true;
                    }


                }
                return false;
            }
            catch (Exception )
            {

                throw;
            }

        }
        /// <summary>
        /// Method to get Ministatement of an account
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CommonLayer.Models.Transaction>> MiniStatement(int accountId)
        {
            List<CommonLayer.Models.Transaction> transactions = new List<CommonLayer.Models.Transaction>();

            if (accountId != 0)
            {
                var results = await this.context.Transactions.ToListAsync();
                transactions = StatementMap(results, accountId);


            }
            return transactions.OrderByDescending(x => x.TransactionDate).Take(5);
        }

        /// <summary>
        /// method to map transaction 
        /// </summary>
        /// <param name="results"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>

        public List<CommonLayer.Models.Transaction> StatementMap(List<EFDataLayer.Model.Transaction> results, int accountId)
        {
            List<CommonLayer.Models.Transaction> transactions = new List<CommonLayer.Models.Transaction>();
            foreach (var transaction in results)
            {
                if (transaction.FromAccountNo == accountId)
                {
                    var oneTransaction = mapper.Map<CommonLayer.Models.Transaction>(transaction);
                    oneTransaction.TransactionType = "Debit";
                   // oneTransaction.FromAccountBalance = transaction.FromAccountBalance;
                    transactions.Add(oneTransaction);
                }
                else if (transaction.ToAccountNo == accountId)
                {
                    var oneTransaction = mapper.Map<CommonLayer.Models.Transaction>(transaction);
                    oneTransaction.TransactionType = "Credit";
                   // oneTransaction.ToAccountBalance = transaction.ToAccountBalance;
                    transactions.Add(oneTransaction);

                }
            }
            return transactions;
        }
        #endregion
    }
}

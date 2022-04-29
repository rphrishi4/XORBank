using AutoMapper;
using CommonLayer.Models;
using EFDataLayer.Contract;
using EFDataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account = CommonLayer.Models.Account;

namespace EFDataLayer.Implementation
{
    public class AccountRepoImpl : IAccountRepo
    {
        #region private field
        private readonly Bank_DbContext context;
        private IMapper mapper;
        #endregion

        #region public constructor
        public AccountRepoImpl(Bank_DbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        #endregion

        #region public method
        /// <summary>
        /// Method To add account
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public async Task<Account> AddAccount(Account account)
        {
            var newAccount = mapper.Map<EFDataLayer.Model.Account>(account);
            var result1=await this.context.Accounts.AddAsync(newAccount);
            await this.context.SaveChangesAsync();
            var result = await this.context.Accounts.Where(x =>x.CustomerId.Equals(result1.Entity.CustomerId)).FirstOrDefaultAsync(x=>x.CreateDate==result1.Entity.CreateDate);

            EFDataLayer.Model.Transaction newTransaction = new Model.Transaction()
            {
                TransactionAmount = account.Balance,
                TransactionDate = DateTime.UtcNow,
                TransactionType = "Deposit",
                ToAccountNo = result.AccountNo,
                ToAccountBalance = account.Balance
            };
            await this.context.AddAsync(newTransaction);
            await this.context.SaveChangesAsync();
            return mapper.Map<CommonLayer.Models.Account>(newAccount);

        }

        /// <summary>
        /// Method to CheckBalance
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<double> BalanceCheck(int id)
        {
            var result = await this.context.Accounts.Where(X => X.IsDeleted == 0).FirstOrDefaultAsync(x => x.AccountNo == id);
            if(result!=null)
            {
                return result.Balance;
            }
            return result.Balance;
        }

        /// <summary>
        /// Method to Delete Account
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAccount(int id)
        {
            bool isTrue = false;
            var result = await this.context.Accounts.Where(X => X.IsDeleted == 0).FirstOrDefaultAsync(x => x.AccountNo == id);
            if(result!=null)
            {
                result.IsDeleted = 1;
                await this.context.SaveChangesAsync();
                isTrue = true;
            }
            return isTrue;
        }
        
        /// <summary>
        /// Method to search account by account id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Account> GetAccount(int id)
        {
            var result = await this.context.Accounts.Where(X=>X.IsDeleted==0).FirstOrDefaultAsync(x => x.AccountNo == id);
            return mapper.Map<CommonLayer.Models.Account>(result);
        }

        /// <summary>
        /// Method to Get All Account
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Account>> GetAllAccounts(string id ="Null")
        {
            List<CommonLayer.Models.Account> accounts = new List<CommonLayer.Models.Account>();
            if (id.Equals("Null"))
            {
                var results = await this.context.Accounts.Where(x => x.IsDeleted == 0).ToListAsync();

                foreach (var account in results)
                {
                    var oneAccount = mapper.Map<CommonLayer.Models.Account>(account);
                    accounts.Add(oneAccount);
                }
            }
            else
            {
                var results = await (from s in this.context.Accounts where s.CustomerId.Equals(id) && s.IsDeleted==0 select s).ToListAsync();

                foreach (var account in results)
                {
                    var oneAccount = mapper.Map<CommonLayer.Models.Account>(account);
                    accounts.Add(oneAccount);
                }
            }
            return accounts;
        }
        /// <summary>
        /// Method to Search Account but Not Implimented
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>

        public Task<IEnumerable<Account>> Search(string key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to Update account 
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public async Task<Account> UpdateAccount(Account account)
        {
            var accountToUpdate = await this.context.Accounts.Where(X => X.IsDeleted == 0).FirstOrDefaultAsync(x => x.AccountNo==account.AccountNo);
            if (accountToUpdate != null)
            {
                accountToUpdate.AccountNo = account.AccountNo;
                accountToUpdate.AccountType = account.AccountType;
                accountToUpdate.CreateDate = account.CreateDate;
                accountToUpdate.Balance = account.Balance;
                await this.context.SaveChangesAsync();

            }
            return mapper.Map<CommonLayer.Models.Account>(accountToUpdate);
        }
#endregion
    }
}

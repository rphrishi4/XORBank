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
    public class AccountManagerImpl : IAccountManager
    {
        #region private field
        private readonly IAccountRepo accountRepo;
        #endregion

        #region constructor
        public AccountManagerImpl(IAccountRepo accountRepo)
        {
            this.accountRepo = accountRepo;
        }
        #endregion

        #region Public method
        public async Task<Account> AddAccount(Account account)
        {
            return await this.accountRepo.AddAccount(account);
        }

        public async Task<double> BalanceCheck(int id)
        {
            return await this.accountRepo.BalanceCheck(id);
        }

        public async Task<bool> DeleteAccount(int id)
        {
            return await this.accountRepo.DeleteAccount(id);
        }

        public async Task<Account> GetAccount(int id)
        {
            return await this.accountRepo.GetAccount(id);
        }

        public async Task<IEnumerable<Account>> GetAllAccounts(string id = "Null")
        {
            return await this.accountRepo.GetAllAccounts(id);
        }

        public Task<IEnumerable<Account>> Search(string key)
        {
            throw new NotImplementedException();
        }

        public async Task<Account> UpdateAccount(Account account)
        {
            return await this.accountRepo.UpdateAccount(account);
        }

        #endregion
    }
}

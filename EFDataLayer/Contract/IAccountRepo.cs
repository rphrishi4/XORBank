using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataLayer.Contract
{
   public interface IAccountRepo
    {

        /// <summary>
        /// Method to Get All Accounts
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Account>> GetAllAccounts( string id="Null");
        /// <summary>
        /// Method to search Account By Name
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Account>> Search(string key);
        /// <summary>
        /// Method to get Account by id
        /// </summary>
        /// <returns></returns>
        Task<Account> GetAccount(int id);
        /// <summary>
        /// Method to Add Account
        /// </summary>
        /// <returns></returns>
        Task<Account> AddAccount(Account account);
        /// <summary>
        /// Method to update Account
        /// </summary>
        /// <returns></returns>
        Task<Account> UpdateAccount(Account account);
        /// <summary>
        /// method to delete Account
        /// </summary>
        /// <returns></returns>
        Task<bool> DeleteAccount(int id);
        /// <summary>
        /// Method to check Balance
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<double> BalanceCheck(int id);
    }
}

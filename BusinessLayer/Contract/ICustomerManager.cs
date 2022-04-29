using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contract
{
  public interface ICustomerManager
    {

        /// <summary>
        /// Method to get Customer
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Customer>> GetAllCustomer();
        /// <summary>
        /// Method to search Customer By Name
        /// </summary>
        /// <returns></returns>
        Task<Customer> Search(string key);
        /// <summary>
        /// Method to get Customer by id
        /// </summary>
        /// <returns></returns>
        Task<Customer> GetCustomer(string id);
        /// <summary>
        /// Method to Add Customer
        /// </summary>
        /// <returns></returns>
        Task<Customer> AddCustomer(Customer customer);
        /// <summary>
        /// Method to update Customer
        /// </summary>
        /// <returns></returns>
        Task<Customer> UpdateCustomer(Customer customer);
        /// <summary>
        /// method to delete Customer
        /// </summary>
        /// <returns></returns>
        Task<bool> DeleteCustomer(string id);



    }
}

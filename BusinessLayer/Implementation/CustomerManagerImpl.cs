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
    public class CustomerManagerImpl : ICustomerManager
    {
        #region private field
        private readonly ICustomerRepo customerRepo;
        #endregion

        #region constructor
        public CustomerManagerImpl(ICustomerRepo customerRepo)
        {
            this.customerRepo = customerRepo;
        }
        #endregion

        #region Public Method
        public async Task<Customer> AddCustomer(Customer customer)
        {
            return await this.customerRepo.AddCustomer(customer);
        }

        public async Task<bool> DeleteCustomer(string id)
        {
            return await this.customerRepo.DeleteCustomer(id);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            return await this.customerRepo.GetAllCustomer();
        }

        public async Task<Customer> GetCustomer(string id)
        {
            return await this.customerRepo.GetCustomer(id);
        }

        public async Task<Customer> Search(string key)
        {
            return await this.customerRepo.Search(key);
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            return await this.customerRepo.UpdateCustomer(customer);
        }

        #endregion
    }
}

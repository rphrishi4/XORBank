using CommonLayer.Models;
using EFDataLayer.Contract;
using EFDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Customer = CommonLayer.Models.Customer;
using Microsoft.EntityFrameworkCore;

namespace EFDataLayer.Implementation
{
    public class CustomerRepoImpl : ICustomerRepo
    {
        #region private field
        private readonly Bank_DbContext context;
        private IMapper mapper;
        #endregion


        #region public constructor
        public CustomerRepoImpl(Bank_DbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        #endregion

        #region public method

        /// <summary>
        /// Method to Add Customer
        /// </summary>
        /// <param name="customerToUpdate"></param>
        /// <returns></returns>
        public async Task<Customer> AddCustomer(Customer customerToUpdate)
        {
            var newCustomer = mapper.Map<EFDataLayer.Model.Customer>(customerToUpdate);
            var result = this.context.Customers.Where(X => X.IsDeleted == 0).FirstOrDefault(x=>x.CustomerId.Equals(customerToUpdate.CustomerId));
            if(result!=null)
            {
               
                return await UpdateCustomer(customerToUpdate);
            }
            var customer= await this.context.Customers.AddAsync(newCustomer);
            await this.context.SaveChangesAsync();
            
            return new CommonLayer.Models.Customer()
            {
                CustomerId=customer.Entity.CustomerId,
                CustomerName = customer.Entity.CustomerName,
                City = customer.Entity.City,
                DateOfBirth = customer.Entity.DateOfBirth,
                Pin = customer.Entity.Pin,
                State = customer.Entity.State,
                MobileNo = customer.Entity.MobileNo,
                Address = customer.Entity.Address,
                Gender = customer.Entity.Gender,
                EmailId = customer.Entity.EmailId,
            };
        }

        /// <summary>
        /// Method Delete customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteCustomer(string id)
        {
            try
            {

                bool isTrue = false;
                var customerHasAccount = this.context.Accounts.Where(X => X.IsDeleted == 0).FirstOrDefault(x => x.CustomerId.Equals(id));
                var customerToDelete = await this.context.Customers.Where(X => X.IsDeleted == 0).FirstOrDefaultAsync(x => x.CustomerId.Equals(id));

                if (customerHasAccount == null)
                {
                    customerToDelete.IsDeleted = 1;
                    await this.context.SaveChangesAsync();
                    isTrue = true;
                }
                return isTrue;
            }
            catch (Exception )
            {

                throw;
            }
        }

        /// <summary>
        /// Method to Get All Customers
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            var results = await this.context.Customers.Where(x=>x.IsDeleted==0).ToListAsync();
            

            List<CommonLayer.Models.Customer> customers = new List<CommonLayer.Models.Customer>();
            foreach (var customer in results)
            {
                var oneCustomer = mapper.Map<CommonLayer.Models.Customer>(customer);
                customers.Add(oneCustomer);
            }
            return customers;
        }
        /// <summary>
        /// Method to get customer by its id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<Customer> GetCustomer(string id)
        {
            var customerToSearch = await this.context.Customers.Where(X => X.IsDeleted == 0).FirstOrDefaultAsync(x => x.CustomerId.Equals(id));
            return mapper.Map<CommonLayer.Models.Customer>(customerToSearch);

        }
        /// <summary>
        /// Method to search customer by its userId(EmailId)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>

        public async Task<Customer> Search(string key)
        {
            var result=await this.context.Customers.Where(X => X.IsDeleted == 0).FirstOrDefaultAsync(x=>x.EmailId.Equals(key));
            return mapper.Map<CommonLayer.Models.Customer>(result);

        }
        /// <summary>
        /// Method to Update Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task<Customer> UpdateCustomer(Customer customer)
        {
           //
            var customerToUpdate = this.context.Customers.Where(X => X.IsDeleted == 0).FirstOrDefault(x => x.CustomerId.Equals(customer.CustomerId));
            if(customerToUpdate!=null)
            {
                customerToUpdate.CustomerName = customer.CustomerName;
                customerToUpdate.City = customer.City;
                customerToUpdate.DateOfBirth = customer.DateOfBirth;
                customerToUpdate.Pin = customer.Pin;
                customerToUpdate.State = customer.State;
                customerToUpdate.MobileNo = customer.MobileNo;
                customerToUpdate.Address = customer.Address;
                customerToUpdate.Gender = customer.Gender;
                customerToUpdate.EmailId = customer.EmailId;
                await this.context.SaveChangesAsync();
                
            }
            return mapper.Map<CommonLayer.Models.Customer>(customerToUpdate);
            //    new CommonLayer.Models.Customer()
            //{

            //    CustomerName = customer.CustomerName,
            //    City = customer.City,
            //    DateOfBirth = customer.DateOfBirth,
            //    Pin = customer.Pin,
            //    State = customer.State,
            //    MobileNo = customer.MobileNo,
            //    Address = customer.Address,
            //    Gender = customer.Gender,
            //    EmailId = customer.EmailId,
            //};


        }
        #endregion
    }
}

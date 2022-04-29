using AutoMapper;
using EFDataLayer.Contract;
using EFDataLayer.Implementation;
using EFDataLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemUnitTest
{ 
    [TestClass]
    public class CustomerRepoTest
    {
        //private Mock<CustomerRepoImpl> customerRepo1 = new Mock<CustomerRepoImpl>();
        //private Mock<Mapper> mapper = new Mock<Mapper>();
       
        CustomerRepoImpl customerRepoImpl = null;
        private  Mock< Bank_DbContext> context=new Mock<Bank_DbContext>();
        private Mock<IMapper> mapper=new Mock<IMapper>();

        
        [TestInitialize]
        public void init()
        {
            
            this.customerRepoImpl = new CustomerRepoImpl(context.Object, mapper.Object);
            ICustomerRepo customerRepo = customerRepoImpl;
            
        }

        [TestMethod]
        public async Task GetAllCustomerAsync()
        {
            EFDataLayer.Model.Customer customer1 = new Customer()
            {

                CustomerId = "1",
                CustomerName = "vaishnavi",
                City = "Baramati",
                DateOfBirth = DateTime.UtcNow,
                Pin = 42379,
                State = "Pune",
                MobileNo = "4152639874",
                Address = "Murum",
                Gender = "Female",
                EmailId = "vaishnavi@gmail.com",
            };
            //List<EFDataLayer.Model.Customer> customers = new List<Customer>();
            //customers.Add(customer1);
            //await this.context.Setup(x => x.Customers.ToListAsync().
            //await context.Setup(x => x.Customers.ToListAsync()).Returns(true);
            //var actualaccount = this.customerRepoImpl.GetAllCustomer().Result.Count();
            //int excepted = 5;
            //Assert.AreEqual(actualaccount,excepted);

        }
    }
}

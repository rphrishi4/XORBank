using BankSystem.Controllers;
using BusinessLayer.Contract;
using CommonLayer.Models;
using EFDataLayer.Implementation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemUnitTest.Controller
{
    [TestClass]
   public class CustomerControllerTest
    {
        CustomerController customerController = null;
        private Mock<ICustomerManager> customerManager = new Mock<ICustomerManager>();
        
        private Mock<IAccountManager> accountManager =new Mock<IAccountManager>();
        private Mock< ITransactionManager> transationManager=new Mock<ITransactionManager>();
        

       

        [TestInitialize]
        public void init()
        {
            //customerController = new CustomerController(customerManager.Object,accountManager.Object,transationManager.Object);

        }
        [TestMethod]
        public void Get()
        {
            CommonLayer.Models.Customer customer1 = new CommonLayer.Models.Customer()
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
            CommonLayer.Models.Customer customer = new CommonLayer.Models.Customer()
            {

               
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
            List<CommonLayer.Models.Customer> customers = new List<Customer>();
            customerManager.Setup(x => x.AddCustomer(customer)).ReturnsAsync(customer1);
            var actul = this.customerController.AddCustomer(customer).Result;
            
            Assert.AreEqual(actul,customer1);


        }
    }
}

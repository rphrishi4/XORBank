using BusinessLayer.Contract;
using BusinessLayer.Implementation;
using CommonLayer.Models;
using EFDataLayer.Contract;
using EFDataLayer.Implementation;
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
    public class CustomerManagerUnitTest 
    {
        // private  CustomerRepoImpl customerRepo;
        // private Mock<EFDataLayer.Model.Bank_DbContext> context = new Mock<EFDataLayer.Model.Bank_DbContext>();

        CustomerManagerImpl customerManager = null;
        private Mock<ICustomerRepo> customerRepo = new Mock<ICustomerRepo>();

        [TestInitialize]
        public void init()
        {
            customerManager = new CustomerManagerImpl(customerRepo.Object);
           // CustomerRepoImpl customer = new CustomerRepoImpl();

            }


        //[TestMethod]
        //public void AddCustomer()
        //{
        //    CommonLayer.Models.Customer customer = new Customer()
        //    {


        //        CustomerName = "vaishnavi",
        //        City = "Baramti",
        //        DateOfBirth = DateTime.UtcNow,
        //        Pin = 42379,
        //        State = "Pune",
        //        MobileNo = "4152639874",
        //        Address = "rtyui",
        //        Gender = "f",
        //        EmailId = "vaishnavi@gmail.com",
        //    };
        //    CommonLayer.Models.Customer customer1 = new Customer()
        //    {


        //        CustomerName = "vaishnavi",
        //        City = "Baramti",
        //        DateOfBirth = DateTime.UtcNow,
        //        Pin = 42379,
        //        State = "Pune",
        //        MobileNo = "4152639874",
        //        Address = "rtyui",
        //        Gender = "f",
        //        EmailId = "vaishnavi@gmail.com",
        //    };

        //    customerRepo.Setup(x => x.AddCustomer(customer)).ReturnsAsync(customer);
        //    var actualCustomer = this.customerManager.AddCustomer(customer);
        //    var exceptedCustomer = customer;
        //    Assert.AreEqual(actualCustomer,exceptedCustomer);
        //}

        [TestMethod]
        public void GetById()
        {
            string id = "1";
            CommonLayer.Models.Customer customer1 = new Customer()
            {

                CustomerId="1",
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

            customerRepo.Setup(x => x.GetCustomer(id)).ReturnsAsync(customer1);
            var actual = this.customerManager.GetCustomer(id).Result;
            var excepted = "vaishnavi";
            Assert.AreEqual(actual.CustomerName,excepted);
        }

        [TestMethod]
        public void GetCustomerByGmail()
        {
            string email = "vaishnavi@gmail.com";
            CommonLayer.Models.Customer customer1 = new Customer()
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
                IsDeleted = 0
            };

            customerRepo.Setup(x => x.Search(email)).ReturnsAsync(customer1);
            var actual = this.customerManager.Search(email).Result;
            var excepted = "vaishnavi";
            Assert.AreEqual(actual.CustomerName, excepted);

        }
        [TestMethod]
        public void GetCustomerByGmail1()
        {
            string email = "vaishnavi@gmail.com";
            CommonLayer.Models.Customer customer1 = new Customer();
            customer1 = null;
           
            customerRepo.Setup(x => x.Search(email)).ReturnsAsync(customer1);
            var actual = this.customerManager.Search(email).Result;
            
            Assert.AreEqual(actual,null);

        }


        [TestMethod]
        public void UpdateCustomer()
        {
            CommonLayer.Models.Customer customer1 = new Customer()
            {

                CustomerId = "1",
                CustomerName = "vaishnavi",
                City = "Baramati",
                DateOfBirth = DateTime.UtcNow,
                Pin = 42379,
                State = "Maharashtra",
                MobileNo = "4152639874",
                Address = "Murum",
                Gender = "Female",
                EmailId = "vaishnavi@gmail.com",
                IsDeleted = 0
            };

            customerRepo.Setup(x => x.UpdateCustomer(customer1)).ReturnsAsync(customer1);
            var actual = this.customerManager.UpdateCustomer(customer1).Result;
            var excepted = "Maharashtra";
            Assert.AreEqual(actual.State, excepted);
        }
        [TestMethod]
        public void DeleteCustomer()
        {
            string id = "1";
            CommonLayer.Models.Customer customer1 = new Customer()
            {

                CustomerId = "1",
                CustomerName = "vaishnavi",
                City = "Baramati",
                DateOfBirth = DateTime.UtcNow,
                Pin = 42379,
                State = "Maharashtra",
                MobileNo = "4152639874",
                Address = "Murum",
                Gender = "Female",
                EmailId = "vaishnavi@gmail.com",
                IsDeleted = 0
            };

            customerRepo.Setup(x => x.DeleteCustomer(id)).ReturnsAsync(true);
            var actual = this.customerManager.DeleteCustomer(id).Result;
            var excepted = true;
            Assert.AreEqual(actual, excepted);
        }
    }
    }

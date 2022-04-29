using BusinessLayer.Contract;
using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankSyatemWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CustomerController : ControllerBase
    {
        #region private field
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IAccountManager accountManager;
        private readonly ICustomerManager customerManager;
        #endregion

        #region constructor
        public CustomerController(IAccountManager accountManager, ICustomerManager customerManager,
            UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.accountManager = accountManager;
            this.customerManager = customerManager;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        #endregion

        #region public method

        /// <summary>
        /// Method to Register Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>Newly Registered Customer</returns>
        ///  <remark>
        /// +Register Customer
        /// 
        ///   +api/Customer/RegisterCustomer
        ///   </remark>


        [HttpPost]
        [Route("RegisterCustomer")]
        public async Task<ActionResult> RegisterCustomer(Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    return BadRequest();
                }
                var user = new IdentityUser { UserName = customer.EmailId, Email = customer.EmailId };
                var result = await userManager.CreateAsync(user, customer.EmailId);


                if (result.Succeeded)
                {
                    customer.CustomerId = user.Id;
                    var newCustomer = await this.customerManager.AddCustomer(customer);
                    return Ok(newCustomer);
                }

                return NotFound($"Error while adding customer found dublication");

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error whilw retriving data from the server ");
            }

        }
        /// <summary>
        /// Method to Delete Customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        /// <remark>
        /// Delete Customer
        /// 
        ///  api/Customer/DeleteCustomer
        /// </remark>>

        [HttpDelete("{customerId}")]
        public async Task<ActionResult> DeleteCustomer(string customerId)
        {
            try
            {



                if (await this.customerManager.DeleteCustomer(customerId))
                {
                    return Ok($"Customer is Deleted is Deleted");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Can Not Delete Customer ");
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error while Deleting Customer");
            }

        }

        /// <summary>
        /// Method to Get all Customer
        /// </summary>
        /// <param ></param>
        /// <returns>List of Customer</returns>
        /// <remark>
        /// Get All Customer
        /// 
        ///  api/Customer/GetAllCustomers
        /// </remark>>

        [HttpGet]
        [Route("GetAllCustomers")]
        public async Task<ActionResult> GetAllCustomers()
        {
            try
            {
                var result = await this.customerManager.GetAllCustomer();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception )
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error whilw retriving data from the server");
            }
        }

        /// <summary>
        /// Method to Serach Customer By UserId(Email)
        /// </summary>
        /// <param name="email"></param>
        /// <returns> Customer</returns>
        /// <remark>
        /// Serach Customer
        /// 
        ///  api/Customer/GetCustomer
        /// </remark>>

        [HttpGet]
        [Route("GetCustomer")]
        public async Task<ActionResult> GetCustomer(string email)
        {
            try
            {
                var result = await this.customerManager.Search(email);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error whilw retriving data from the server");
            }
        }

        /// <summary>
        /// Method to Update customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateCustomer")]
        public async Task<ActionResult> UpdateCustomer(Customer customer)
        {
            try
            {if (customer != null)
                {
                    var result = await this.customerManager.UpdateCustomer(customer);
                    if (result == null)
                    {
                        return NotFound();
                    }

                    return Ok(result);
                }
            return BadRequest();
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error whilw retriving data from the server");
            }
        }



        #endregion
    }


}

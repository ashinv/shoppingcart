using BackEnd.Controllers;
using BackEnd.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace BackEndTesting
{
    class CustomersControllerTest
    {
        CustomersController customersController;

        [SetUp]
        public void SetUp()
        {
            customersController = new CustomersController();
        }

        [Test]
        public void GetCustomerByIdTest()
        {
            IHttpActionResult customer = customersController.GetCustomer(1);
            OkNegotiatedContentResult<Customer> contentResult = (OkNegotiatedContentResult<Customer>)customer;
            string actualOutput = contentResult.Content.Fullname;
            Assert.AreEqual(actualOutput, "Akshay Tony");
        }
        [Test]
        public void PostCustomerTest()
        {
            Customer customer = new Customer();
            customer.Fullname = "Allen";
            customer.Mobilephone = 9874554789;
            customer.Email = "allen@gmail.com";
            customer.Password = "456123";
            IHttpActionResult result = customersController.PostCustomer(customer);
            CreatedAtRouteNegotiatedContentResult<Customer> contentResult = (CreatedAtRouteNegotiatedContentResult<Customer>)result;
            Assert.IsNotNull(contentResult.Content.Fullname);
        }
        [Test]
        public void PutParticipantTest()
        {
            Customer customer = new Customer();
            customer.CusID = 2;
            customer.Fullname = "namithaJames";
            customer.Mobilephone = 7845124578;
            customer.Email = "namitha@gmail.com";
            customer.Password = "password";
            IHttpActionResult result = customersController.PutCustomer(customer.CusID, customer);
            Assert.AreEqual(typeof(StatusCodeResult), result.GetType());

        }
        [Test]
        public void DeleteCustomerById()
        {
            IHttpActionResult result = customersController.DeleteCustomer(32);
            Assert.AreEqual(typeof(OkNegotiatedContentResult<Customer>), result.GetType());
        }
    }
}

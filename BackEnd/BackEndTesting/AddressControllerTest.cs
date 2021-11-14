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
    class AddressControllerTest
    {
        AddressesController addressController;

        [SetUp]
        public void SetUp()
        {
            addressController = new AddressesController();
        }

        [Test]
        public void GetAddressByIdTest()
        {
            IHttpActionResult address = addressController.GetAddress(6);
            OkNegotiatedContentResult<Address> contentResult = (OkNegotiatedContentResult<Address>)address;
            string actualOutput = contentResult.Content.country;
            Assert.AreEqual(actualOutput,"India");
        }
        [Test]
        public void PostAddressTest()
        {
            Address address= new Address();
            address.firstName = "Akhil";
            address.lastName = "Jason";
            address.address1 = "Fourth avenue";
            address.country = "India";
            address.state = "Kerala";
            address.zip = "652356";
            address.PhoneNumber = "7845123265";
            IHttpActionResult result = addressController.PostAddress(address);
            CreatedAtRouteNegotiatedContentResult<Address> contentResult = (CreatedAtRouteNegotiatedContentResult<Address>)result;
            Assert.IsNotNull(contentResult.Content.country);
        }

    }
}

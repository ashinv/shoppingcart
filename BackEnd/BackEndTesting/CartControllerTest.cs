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
    class CartControllerTest
    {
        CartsController cartsController;

        [SetUp]
        public void SetUp()
        {
            cartsController = new CartsController();
        }

        [Test]
        public void GetCartByIdTest()
        {
            IHttpActionResult cart = cartsController.GetCart(1);
            OkNegotiatedContentResult<Cart> contentResult = (OkNegotiatedContentResult<Cart>)cart;
            string actualOutput = contentResult.Content.title;
            Assert.AreEqual(actualOutput, "Fjallraven - Foldsack No. 1 Backpack, Fits 15 Laptops");
        }
        [Test]
        public void postcarttest()
        {
            Cart cart = new Cart();
            cart.id = 4;
            cart.title = "Mens Casual Slim Fit";
            cart.price = 15;
            cart.description="The color could be slightly different between on the screen and in practice. / Please note that body builds vary by person, therefore, detailed size information should be reviewed below on the product description.";
            cart.category="men's clothing";
            cart.image="https://fakestoreapi.com/img/71YXzeOuslL._AC_UY879_.jpg";
            cart.quantity = 1;
            cart.total = 15;
            IHttpActionResult result = cartsController.PostCart(cart);
            CreatedAtRouteNegotiatedContentResult<Cart> contentresult = (CreatedAtRouteNegotiatedContentResult<Cart>)result;
            Assert.IsNotNull(contentresult.Content.quantity);
        }
        [Test]
        public void PutCartTest()
        {
            Cart cart = new Cart();
            cart.id = 4;
            cart.title = "Mens Casual Slim Fit";
            cart.price = 16;
            cart.description = "The color could be slightly different between on the screen and in practice. / Please note that body builds vary by person, therefore, detailed size information should be reviewed below on the product description.";
            cart.category = "men's clothing";
            cart.image = "https://fakestoreapi.com/img/71YXzeOuslL._AC_UY879_.jpg";
            cart.quantity = 1;
            cart.total = 16;
            IHttpActionResult result = cartsController.PutCart(cart.id, cart);
            Assert.AreEqual(typeof(StatusCodeResult), result.GetType());

        }
        [Test]
        public void DeleteCartById()
        {
            IHttpActionResult result = cartsController.DeleteCart(4);
            Assert.AreEqual(typeof(OkNegotiatedContentResult<Cart>), result.GetType());
        }
    }
}

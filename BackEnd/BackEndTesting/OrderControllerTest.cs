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
    class OrderControllerTest
    {
        OrdersController ordersController;

        [SetUp]
        public void SetUp()
        {
            ordersController = new OrdersController();
        }

        [Test]
        public void GetOrderByIdTest()
        {
            IHttpActionResult order = ordersController.GetOrder(1);
            OkNegotiatedContentResult<Order> contentResult = (OkNegotiatedContentResult<Order>)order;
            decimal actualOutput = contentResult.Content.shipping;
            Assert.AreEqual(actualOutput, 10);
        }
        [Test]
        public void PostOrderTest()
        {
            Order order = new Order();
            order.subtotal = 290;
            order.shipping = 10;
            order.tax = 0;
            order.totalamt = 300;
            IHttpActionResult result = ordersController.PostOrder(order);
            CreatedAtRouteNegotiatedContentResult<Order> contentResult = (CreatedAtRouteNegotiatedContentResult<Order>)result;
            Assert.IsNotNull(contentResult.Content.totalamt);
        }
        
    }
}

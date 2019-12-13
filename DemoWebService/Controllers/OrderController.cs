using DemoWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoWebService.Controllers
{
    public class OrderController : ApiController
    {
        public IHttpActionResult GetOrderStatus()
        {
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string orderId = string.Empty;
            if (headers.Contains("OrderId"))
            {
                orderId = headers.GetValues("OrderId").First();
            }
            else
                throw new ApplicationException("OrderId Header cannot be empty");

            Order order = new Order()
            {
                OrderId = orderId,
                OrderStatus = "Approved"
            };

            return Content(HttpStatusCode.OK, order);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Foodzx.Power1.WebApi.Controllers
{
    public class PingController : ApiController
    {
        // GET api/ping
        public HttpResponseMessage Get()
        {
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);

            httpResponseMessage.Content = new StringContent("PONG.", Encoding.UTF8, "text/plain");

            return httpResponseMessage;
        }
    }
}

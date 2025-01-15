using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Foodzx.Power1.Framework.Common.DataModel;
using Foodzx.Power1.Framework.Common.Providers;

namespace Foodzx.Power1.WebApi.Controllers
{
    public class ContactController : ApiController
    {
        // GET api/contact
        [HttpGet]
        public HttpResponseMessage Get(string version)
        {
            ActionResultDataModel result = new ActionResultDataModel();

            try
            {

            }
            catch (Exception ex)
            {
                result = new ActionResultDataModel(ex);
            }


            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);

            httpResponseMessage.Content = new StringContent(ActionResultJsonProvider.GetJsonObject(result, null).ToString(), Encoding.UTF8, "application/json");

            return httpResponseMessage;
        }
    }
}

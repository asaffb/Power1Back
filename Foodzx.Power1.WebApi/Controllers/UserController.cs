using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Foodzx.Power1.Framework.Common.DataModel;
using Foodzx.Power1.Framework.Common.Providers;
using Foodzx.Power1.Framework.DataModel;
using Foodzx.Power1.Framework.Json;
using Foodzx.Power1.WebApi.Logic;
using Microsoft.SqlServer.Server;

namespace Foodzx.Power1.WebApi.Controllers
{
    public class UserController : ApiController
    {
        // GET api/user
        [HttpGet]
        [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
        public HttpResponseMessage Get(string version)
        {
            ActionResultDataModel result = new ActionResultDataModel();

            JsonObject data = null;

            try
            {
                ApiUserLogic apiUserLogic = new ApiUserLogic();

                (result, data) = apiUserLogic.GetUsers();


                /*
                JsonArray jsonArray = new JsonArray();


                // 1
                JsonObject jsonObject = new JsonObject();
                jsonObject.Add("id", new JsonString("1"))
                    .Add("userId", new JsonGuid(new Guid("{FA1342A8-4BFA-4DEA-9CEA-24A39EEFC754}")))
                    .Add("firstName", new JsonString("FirstName1"))
                    .Add("lastName", new JsonString("LastName1"))
                    .Add("fullName", new JsonString("Full Name1"));

                jsonArray.Add(jsonObject);

                // 2
                jsonObject = new JsonObject();
                jsonObject.Add("id", new JsonString("2"))
                    .Add("userId", new JsonGuid(new Guid("{36821F90-1262-49BA-844E-3820F465FD9D}")))
                    .Add("firstName", new JsonString("FirstName2"))
                    .Add("lastName", new JsonString("LastName2"))
                    .Add("fullName", new JsonString("Full Name2"));

                jsonArray.Add(jsonObject);

                data.Add("UserList", jsonArray);
                */
            }
            catch (Exception ex)
            {
                result = new ActionResultDataModel(ex);
            }


            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);

            httpResponseMessage.Content = new StringContent(ActionResultJsonProvider.GetJsonObject(result, data).ToString(), Encoding.UTF8, "application/json");

            return httpResponseMessage;
        }


        // POST api/user
        [HttpPost]
        [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
        public async Task<HttpResponseMessage> PostRawBufferManual()
        {
            ActionResultDataModel result = new ActionResultDataModel();

            //string format = "json";

            JsonObject data = null;

            try
            {
                string content = await Request.Content.ReadAsStringAsync();

                // Version
                string version = HttpUtility.ParseQueryString(content).Get("version");

                if (string.IsNullOrEmpty(version))
                {
                    version = "1";
                }


                /*
                // Format
                format = HttpUtility.ParseQueryString(content).Get("format");

                if (string.IsNullOrEmpty(format))
                {
                    format = "xml";
                }
                */


                // Action
                string action = HttpUtility.ParseQueryString(content).Get("action");

                if (string.IsNullOrEmpty(action))
                {
                    result = new ActionResultDataModel("Parameter 'action' is missing.");
                }



                ApiUserLogic apiUserLogic = new ApiUserLogic();

                string username = string.Empty;
                string firstName = string.Empty;
                string lastName = string.Empty;
                string email = string.Empty;

                UserDataModel userDataModel;


                // Parse parameters according to action
                if (result.IsOK)
                {
                    switch (action.ToLower())
                    {
                        case "create":

                            // Validate initial creation parameters

                            // Username
                            username = HttpUtility.ParseQueryString(content).Get("username");

                            if (string.IsNullOrEmpty(username))
                            {
                                result = new ActionResultDataModel("Parameter 'username' is missing.");
                            }

                            if (result.IsOK)
                            {
                                // FirstName
                                firstName = HttpUtility.ParseQueryString(content).Get("firstname");

                                if (string.IsNullOrEmpty(firstName))
                                {
                                    result = new ActionResultDataModel("Parameter 'firstname' is missing.");
                                }
                            }

                            if (result.IsOK)
                            {
                                // LastName
                                lastName = HttpUtility.ParseQueryString(content).Get("lastname");

                                if (string.IsNullOrEmpty(lastName))
                                {
                                    result = new ActionResultDataModel("Parameter 'lastname' is missing.");
                                }
                            }

                            if (result.IsOK)
                            {
                                // Email
                                email = HttpUtility.ParseQueryString(content).Get("email");

                                if (string.IsNullOrEmpty(email))
                                {
                                    result = new ActionResultDataModel("Parameter 'email' is missing.");
                                }
                            }

                            if (result.IsOK)
                            {
                                // Create user
                                userDataModel = new UserDataModel()
                                {
                                    Username = username,
                                    FirstName = firstName,
                                    LastName = lastName,
                                    Email = email
                                };

                                (result, data) = apiUserLogic.CreateUser(userDataModel);
                            }


                            break;

                        default:

                            result = new ActionResultDataModel("Action parameter '{0}' is not supported.", action);
                            break;

                    }
                }

                
                /*
                // Token
                string token = HttpUtility.ParseQueryString(content).Get("token");

                if (string.IsNullOrEmpty(token))
                {
                    result = new ActionResultDataModel("Parameter 'token' is missing.");
                }


                // Language Code
                string languageCode = string.Empty;

                if (result.IsOK)
                {
                    languageCode = HttpUtility.ParseQueryString(content).Get("languagecode");

                    if (string.IsNullOrEmpty(languageCode))
                    {
                        result = new ActionResultDataModel("Parameter 'languagecode' is missing.");
                    }
                }


                if (result.IsOK)
                {
                    ApiSaesLanguageManager apiSaesLanguageManager = new ApiSaesLanguageManager();

                    result = apiSaesLanguageManager.ProcessLanguageSet(token, languageCode);
                }
                */
            }
            catch (Exception ex)
            {
                result = new ActionResultDataModel(ex);
            }


            /*
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);

            switch (format.Trim().ToLower())
            {
                case "xml":

                    httpResponseMessage.Content = new StringContent(XmlSerializerProvider.GetActionResult(result), Encoding.UTF8, "text/xml");
                    break;

                case "lsl":

                    httpResponseMessage.Content = new StringContent(string.Concat("IsOK | ", result.IsOK ? "1" : "0", Environment.NewLine,
                        "ErrorMessage | ", result.ErrorMessage, Environment.NewLine), Encoding.UTF8, "text/plain");
                    break;

                default:

                    httpResponseMessage.Content = new StringContent(JsonSerializerProvider.GetActionResult(result), Encoding.UTF8, "application/json");
                    break;
            }
            */



            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);

            httpResponseMessage.Content = new StringContent(ActionResultJsonProvider.GetJsonObject(result, data).ToString(), Encoding.UTF8, "application/json");

            return httpResponseMessage;
        }
    }
}

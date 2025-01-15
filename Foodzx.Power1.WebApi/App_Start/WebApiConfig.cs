using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Foodzx.Power1.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Enable CORS - Reference: https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/enabling-cross-origin-requests-in-web-api
            config.EnableCors();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ContactApi",
                routeTemplate: "api/contact/{version}",
                defaults: new { controller = "contact" }
            );

            config.Routes.MapHttpRoute(
                name: "FileApi",
                routeTemplate: "api/file/{version}",
                defaults: new { controller = "file" }
            );

            config.Routes.MapHttpRoute(
                name: "MailboxApi",
                routeTemplate: "api/mailbox/{version}",
                defaults: new { controller = "mailbox" }
            );

            config.Routes.MapHttpRoute(
                name: "MailMessageApi",
                routeTemplate: "api/mailmessage/{version}",
                defaults: new { controller = "mailmessage" }
            );

            config.Routes.MapHttpRoute(
                name: "OrganizationApi",
                routeTemplate: "api/organization/{version}",
                defaults: new { controller = "organization" }
            );

            config.Routes.MapHttpRoute(
                name: "ProjectApi",
                routeTemplate: "api/project/{version}",
                defaults: new { controller = "project" }
            );

            config.Routes.MapHttpRoute(
                name: "UserApi",
                routeTemplate: "api/user/{version}",
                defaults: new { controller = "user" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

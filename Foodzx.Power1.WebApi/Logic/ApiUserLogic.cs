using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Foodzx.Power1.Framework;
using Foodzx.Power1.Framework.Common.DataModel;
using Foodzx.Power1.Framework.DataModel;
using Foodzx.Power1.Framework.Json;
using Foodzx.Power1.WebApi.Configuration;

namespace Foodzx.Power1.WebApi.Logic
{
    public class ApiUserLogic
    {
        public (ActionResultDataModel, JsonObject) GetUsers()
        {
            ActionResultDataModel result = new ActionResultDataModel();

            JsonObject jsonObject = new JsonObject();

            ConfigurationDataModel configurationDataModel = ConfigurationProvider.GetConfigurationDataModel();

            UserManager userManager = new UserManager();


            List<UserDataModel> userList;

            (result, userList) = userManager.GetAllUsers(configurationDataModel);


            JsonArray jsonArray = new JsonArray();

            if (result.IsOK)
            {
                JsonObject userJsonObject;

                int index = 0;

                foreach (UserDataModel currentUserDataModel in userList)
                {
                    index++;

                    userJsonObject = new JsonObject();
                    userJsonObject.Add("id", new JsonString(index.ToString()))
                        .Add("userId", new JsonGuid(currentUserDataModel.Id.Value))
                        .Add("usernname", new JsonString(currentUserDataModel.Username))
                        .Add("firstName", new JsonString(currentUserDataModel.FirstName))
                        .Add("lastName", new JsonString(currentUserDataModel.LastName))
                        .Add("email", new JsonString(currentUserDataModel.Email));


                    jsonArray.Add(userJsonObject);

                    /*
                    // 1
                    JsonObject userJsonObject = new JsonObject();
                    userJsonObject.Add("id", new JsonString("1"))
                        .Add("userId", new JsonGuid(new Guid("{FA1342A8-4BFA-4DEA-9CEA-24A39EEFC754}")))
                        .Add("firstName", new JsonString("FirstName1"))
                        .Add("lastName", new JsonString("LastName1"))
                        .Add("fullName", new JsonString("Full Name1"));

                    jsonArray.Add(userJsonObject);

                    // 2
                    userJsonObject = new JsonObject();
                    userJsonObject.Add("id", new JsonString("2"))
                        .Add("userId", new JsonGuid(new Guid("{36821F90-1262-49BA-844E-3820F465FD9D}")))
                        .Add("firstName", new JsonString("FirstName2"))
                        .Add("lastName", new JsonString("LastName2"))
                        .Add("fullName", new JsonString("Full Name2"));

                    jsonArray.Add(userJsonObject);
                    */
                }
            }

            jsonObject.Add("UserList", jsonArray);

            return (result, jsonObject);
        }

        public (ActionResultDataModel, JsonObject) CreateUser(UserDataModel userDataModel)
        {
            ActionResultDataModel result = new ActionResultDataModel();

            JsonObject jsonObject = new JsonObject();

            ConfigurationDataModel configurationDataModel = ConfigurationProvider.GetConfigurationDataModel();

            UserManager userManager = new UserManager();


            Guid userId;

            (result, userId) = userManager.CreateUser(userDataModel, configurationDataModel);


            if (result.IsOK)
            {
                jsonObject.Add("UserId", new JsonGuid(userId));
            }


            return (result, jsonObject);
        }
    }
}

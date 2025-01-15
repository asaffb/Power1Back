using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Foodzx.Power1.DataAccess.Base;
using Foodzx.Power1.Framework.Common.DataModel;
using Foodzx.Power1.Framework.DataAccess;
using Foodzx.Power1.Framework.DataModel;

namespace Foodzx.Power1.Framework.Providers
{
    public class UserProvider
    {
        public (ActionResultDataModel, List<UserDataModel>) GetAllUsers(MySqlDataAccessConnection mySqlDataAccessConnection)
        {
            ActionResultDataModel result = new ActionResultDataModel();

            List<UserDataModel> userList = new List<UserDataModel> ();

            UserDataAccess userDataAccess = new UserDataAccess(mySqlDataAccessConnection);

            userList = userDataAccess.GetAllUsers();

            return (result, userList);
        }

        public (ActionResultDataModel, Guid) CreateUser(UserDataModel userDataModel, MySqlDataAccessConnection mySqlDataAccessConnection)
        {
            ActionResultDataModel result = new ActionResultDataModel();

            Guid userId = Guid.Empty;

            UserDataAccess userDataAccess = new UserDataAccess(mySqlDataAccessConnection);

            // Generate user ID
            userDataModel.Id = Guid.NewGuid();


            int affectedRows = userDataAccess.InsertUser(userDataModel);

            if (affectedRows == 0)
            {
                result = new ActionResultDataModel("User was not created.");
            }
            else
            {
                userId = userDataModel.Id.Value;
            }

            return (result, userId);
        }
    }
}

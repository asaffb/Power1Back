using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodzx.Power1.DataAccess.Base;
using Foodzx.Power1.Framework.DataModel;

namespace Foodzx.Power1.Framework.DataAccess
{
    public class UserDataAccess : MySqlDataAccessBase<UserDataModel>
    {
        public UserDataAccess(MySqlDataAccessConnection connection) : base(connection)
        {

        }


        public List<UserDataModel> GetAllUsers()
        {
            List<UserDataModel> result = new List<UserDataModel>();

            result = this.GetFromQuery(UserDataModel.GetAllUsersQuery());

            return result;
        }


        public int InsertUser(UserDataModel userDataModel)
        {
            int result = 0;

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "UserId", userDataModel.Id },
                { "Username", userDataModel.Username },
                { "FirstName", userDataModel.FirstName },
                { "LastName", userDataModel.LastName },
                { "Email", userDataModel.Email }
            };

            result = this.ExecuteNonQuery(UserDataModel.GetInsertUserQuery(), parameters);

            return result;
        }


        public override UserDataModel CreateDataModel()
        {
            return new UserDataModel();
        }

        public override string GetTableName()
        {
            return "Users";
        }
    }
}

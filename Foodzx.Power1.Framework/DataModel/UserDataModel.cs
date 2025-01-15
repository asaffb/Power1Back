using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodzx.Power1.DataAccess.Base;

namespace Foodzx.Power1.Framework.DataModel
{
    public class UserDataModel : DataModelBase
    {
        public Guid? Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }


        public static string GetAllUsersQuery()
        {
            return "SELECT * FROM Users";
        }

        public static string GetInsertUserQuery()
        {
            return "INSERT INTO Users (UserId, Username, FirstName, LastName, Email) VALUES (@UserId, @Username, @FirstName, @LastName, @Email)";
        }


        public override void LoadFromReader(IDataReader dataReader)
        {
            this.Id = this.GetGuidFromDB(dataReader["UserId"]);

            this.Username = this.GetStringFromDB(dataReader["Username"]);

            this.FirstName = this.GetStringFromDB(dataReader["FirstName"]);

            this.LastName = this.GetStringFromDB(dataReader["LastName"]);

            this.Email = this.GetStringFromDB(dataReader["Email"]);
        }
    }
}

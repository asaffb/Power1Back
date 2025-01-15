using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodzx.Power1.DataAccess.Base;

namespace Foodzx.Power1.Framework.DataModel
{
    public class ContactDataModel : DataModelBase
    {
        public Guid? Id { get; set; }

        public Guid? OrganizationId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        /*
        public static string GetByTokenQuery()
        {
            return "SELECT * FROM ew_saesauthsview WHERE Token = @Token";
        }
        */



        public override void LoadFromReader(IDataReader dataReader)
        {
            this.Id = this.GetGuidFromDB(dataReader["ContactId"]);

            this.OrganizationId = this.GetGuidFromDB(dataReader["OrganizationId"]);

            this.FirstName = this.GetStringFromDB(dataReader["FirstName"]);

            this.LastName = this.GetStringFromDB(dataReader["LastName"]);

            /*
            this.Id = this.GetGuidFromDB(dataReader["SaesAuthId"].ToString());

            this.Token = dataReader["Token"].ToString();

            this.PrincipalID = GetUUIDFromDB(dataReader["PrincipalID"]);

            this.Name = dataReader["Name"].ToString();

            if (dataReader["UserPositionCode"] != null && dataReader["UserPositionCode"] != DBNull.Value)
            {
                this.UserPositionType = (SaesUserPositionTypes)Convert.ToInt32(dataReader["UserPositionCode"]);
            }
            else
            {
                this.UserPositionType = SaesUserPositionTypes.Undefined;
            }

            this.SaesProgramId = this.GetGuidFromDB(dataReader["SaesProgramId"].ToString());

            if (dataReader["CreatedOn"] != null && dataReader["CreatedOn"] != DBNull.Value)
            {
                this.CreatedOn = Convert.ToDateTime(dataReader["CreatedOn"]);
            }
            else
            {
                this.CreatedOn = null;
            }

            if (dataReader["SaesGroupId"] != null && dataReader["SaesGroupId"] != DBNull.Value)
            {
                this.SaesGroupId = this.GetGuidFromDB(dataReader["SaesGroupId"].ToString());
            }
            else
            {
                this.SaesGroupId = null;
            }

            if (dataReader["GroupName"] != null && dataReader["GroupName"] != DBNull.Value)
            {
                this.GroupName = dataReader["GroupName"].ToString();
            }
            else
            {
                this.GroupName = string.Empty;
            }
            */
        }


    }
}

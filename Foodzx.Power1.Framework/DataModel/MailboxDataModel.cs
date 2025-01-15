using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodzx.Power1.DataAccess.Base;

namespace Foodzx.Power1.Framework.DataModel
{
    public class MailboxDataModel : DataModelBase
    {
        public Guid? Id { get; set; }

        public string EmailAddress { get; set; }

        public string Pop3Host { get; set; }

        public int? Pop3Port { get; set; }

        public string Pop3Username { get; set; }

        public string Pop3Password { get; set; }

        public DateTime? CreatedOn { get; set; }


        public override void LoadFromReader(IDataReader dataReader)
        {
            this.Id = this.GetGuidFromDB(dataReader["MailboxId"]);

            this.EmailAddress = this.GetStringFromDB(dataReader["EmailAddress"]);

            this.Pop3Host = this.GetStringFromDB(dataReader["Pop3Host"]);

            this.Pop3Port = this.GetIntFromDB(dataReader["Pop3Port"]);

            this.Pop3Username = this.GetStringFromDB(dataReader["Pop3Username"]);

            this.Pop3Password = this.GetStringFromDB(dataReader["Pop3Password"]);

            if (dataReader["CreatedOn"] != null && dataReader["CreatedOn"] != DBNull.Value)
            {
                this.CreatedOn = Convert.ToDateTime(dataReader["CreatedOn"]);
            }
            else
            {
                this.CreatedOn = null;
            }
        }
    }
}

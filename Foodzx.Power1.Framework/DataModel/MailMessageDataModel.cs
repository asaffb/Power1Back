using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodzx.Power1.DataAccess.Base;

namespace Foodzx.Power1.Framework.DataModel
{
    public class MailMessageDataModel : DataModelBase
    {
        public Guid? Id { get; set; }

        public Guid? MailboxId { get; set; }

        public string Subject { get; set; }


        public string TextBody { get; set; }

        public string HtmlBody { get; set; }


        public override void LoadFromReader(IDataReader dataReader)
        {
            this.Id = this.GetGuidFromDB(dataReader["MailMessageId"]);

            this.MailboxId = this.GetGuidFromDB(dataReader["MailboxId"]);

            this.Subject = this.GetStringFromDB(dataReader["Subject"]);

            this.TextBody = this.GetStringFromDB(dataReader["TextBody"]);

            this.HtmlBody = this.GetStringFromDB(dataReader["HtmlBody"]);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodzx.Power1.DataAccess.Base;
using Foodzx.Power1.Framework.DataModel;

namespace Foodzx.Power1.Framework.DataAccess
{
    public class MailboxDataAccess : MySqlDataAccessBase<MailboxDataModel>
    {
        public MailboxDataAccess(MySqlDataAccessConnection connection) : base(connection)
        {

        }



        public override MailboxDataModel CreateDataModel()
        {
            return new MailboxDataModel();
        }

        public override string GetTableName()
        {
            return "Mailboxes";
        }
    }
}

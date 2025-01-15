using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodzx.Power1.DataAccess.Base;
using Foodzx.Power1.Framework.DataModel;

namespace Foodzx.Power1.Framework.DataAccess
{
    public class OrganizationDataAccess : MySqlDataAccessBase<OrganizationDataModel>
    {
        public OrganizationDataAccess(MySqlDataAccessConnection connection) : base(connection)
        {

        }



        public override OrganizationDataModel CreateDataModel()
        {
            return new OrganizationDataModel();
        }

        public override string GetTableName()
        {
            return "Organizations";
        }
    }
}

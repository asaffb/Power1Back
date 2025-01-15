using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodzx.Power1.DataAccess.Base;
using Foodzx.Power1.Framework.DataModel;

namespace Foodzx.Power1.Framework.DataAccess
{
    public class FileDataAccess : MySqlDataAccessBase<FileDataModel>
    {
        public FileDataAccess(MySqlDataAccessConnection connection) : base(connection)
        {

        }



        public override FileDataModel CreateDataModel()
        {
            return new FileDataModel();
        }

        public override string GetTableName()
        {
            return "Files";
        }
    }
}

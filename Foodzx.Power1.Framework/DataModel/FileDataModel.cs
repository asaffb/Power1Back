using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodzx.Power1.DataAccess.Base;

namespace Foodzx.Power1.Framework.DataModel
{
    public class FileDataModel : DataModelBase
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        public override void LoadFromReader(IDataReader dataReader)
        {
            this.Id = this.GetGuidFromDB(dataReader["ContactId"]);

            this.Name = this.GetStringFromDB(dataReader["Name"]);

            this.Description = this.GetStringFromDB(dataReader["Description"]);

        }
    }
}
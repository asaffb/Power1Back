using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodzx.Power1.DataAccess.Interfaces;

namespace Foodzx.Power1.Framework.Configuration
{
    public class FrameworkConfigurationDataModel : IDataAccessConfiguration
    {
        public string ConnectionString { get; set; }
    }
}

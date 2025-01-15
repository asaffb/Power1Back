using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foodzx.Power1.WebApi.Configuration
{
    public class ConfigurationProvider
    {
        public static ConfigurationDataModel GetConfigurationDataModel()
        {
            ConfigurationDataModel result = new ConfigurationDataModel()
            {
                ConnectionString = "server=localhost;uid=localdev;pwd=Pass@word100;database=dev_power1db"
            };

            return result;
        }
    }
}
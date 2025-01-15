using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodzx.Power1.DataAccess.Interfaces;
using Foodzx.Power1.Framework.Mail.Interfaces;

namespace Foodzx.Power1.MailPullerApp.Configuration
{
    public class ConfigurationDataModel : IMailConfiguration, IDataAccessConfiguration
    {
        public string Pop3MailServerHost { get; set; } = "pop.hostinger.com";

        public int Pop3Port { get; set; } = 995;

        public string Pop3UserName { get; set; } = "projects@foodxchange.ai";

        public string Pop3Password { get; set; } = "Foodz@2025";

        public string ConnectionString { get; set; } = "server=localhost;uid=localdev;pwd=Pass@word100;database=dev_power1db";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodzx.Power1.DataAccess;
using Foodzx.Power1.Framework.Mail;
using Foodzx.Power1.MailPullerApp.Configuration;

namespace Foodzx.Power1.MailPullerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConfigurationDataModel configurationDataModel = new ConfigurationDataModel();

            DataAccessManager dataAccessManager = new DataAccessManager();

            dataAccessManager.TestConnection(configurationDataModel);

            /*
            MailManager mailManager = new MailManager();

            mailManager.GetMessages(configurationDataModel);
            */

            Console.WriteLine("Done.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodzx.Power1.Framework.Mail.Interfaces
{
    public interface IMailConfiguration
    {
        string Pop3MailServerHost { get; }

        int Pop3Port { get; }

        string Pop3UserName { get; }

        string Pop3Password { get; }
    }
}

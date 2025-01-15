using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodzx.Power1.Framework.Mail.Interfaces;
using MailKit.Net.Pop3;
using MimeKit;

namespace Foodzx.Power1.Framework.Mail
{
    public class MailManager
    {
        public void GetMessages(IMailConfiguration mailConfiguration)
        {
            using (Pop3Client pop3Client = new Pop3Client())
            {
                pop3Client.Connect(mailConfiguration.Pop3MailServerHost, mailConfiguration.Pop3Port);

                pop3Client.Authenticate(mailConfiguration.Pop3UserName, mailConfiguration.Pop3Password);

                int messageCount = pop3Client.Count;

                if (messageCount > 0)
                {
                    MimeMessage mimeMessage = pop3Client.GetMessage(0);
                }

                pop3Client.Disconnect(true);
            }
        }
    }
}

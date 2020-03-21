using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public static class SendMailService
    {
        public static void InitEmailMessage(string email, string title)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(Startup.StaticConfig["EmailConfig:Admin"], "appbanking01@gmail.com"));
            message.To.Add(new MailboxAddress("Demo email", email));
            message.Subject = "My First Email";
            message.Body = new TextPart("plain")
            {
                Text = "Subject email"
            };
        }

        public static void SendMail()
        {

        }
    }
}

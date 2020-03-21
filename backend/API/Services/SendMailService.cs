using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    /// <summary>
    /// Send mail service
    /// </summary>
    public static class SendMailService
    {
        private static string admin = Startup.StaticConfig["EmailConfig:Admin"];
        private static string adminEmail = Startup.StaticConfig["EmailConfig:AdminEmail"];
        private static string adminPassword = Startup.StaticConfig["EmailConfig:AdminPassword"];
        private static string host = Startup.StaticConfig["EmailConfig:Host"];
        private static string port = Startup.StaticConfig["EmailConfig:Port"];

        /// <summary>
        /// Generate OTP
        /// </summary>
        /// <returns></returns>
        public static string GenerateOTP()
        {
            Random rnd = new Random();
            var otp = (rnd.Next(100000, 999999)).ToString();
            return otp;
        }

        /// <summary>
        /// Generate random string with 8 characters
        /// </summary>
        /// <returns></returns>
        public static string GenerateString()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Init email message
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static MimeMessage InitEmailMessage(string email, string subject, string content)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(admin, adminEmail));
            message.To.Add(new MailboxAddress(admin, email));
            message.Subject = subject;
            message.Body = new TextPart("plain")
            {
                Text = content
            };

            return message;
        }

        /// <summary>
        /// Send mail
        /// </summary>
        /// <param name="mimeMessage"></param>
        public static void SendMail(MimeMessage mimeMessage)
        {
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.CheckCertificateRevocation = false;
                client.Connect(host, Int32.Parse(port), true);

                //SMTP server authentication if needed
                client.Authenticate(adminEmail, adminPassword);

                client.Send(mimeMessage);

                client.Disconnect(true);
            }
        }
    }
}

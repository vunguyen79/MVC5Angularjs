using HomeCinema.Services.Abstract;
using HomeCinema.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Services
{
    public class MailService : IMailService
    {

        public Task SendMailAsync(NotificationContent email)
        {
            //return Task.Run(() =>
            //{
            //   SendMail(email);
            //});

            return Task.Run(() =>
            {
                SendEmailByOutDomain(email);
            });

        }

        public void SendMail(NotificationContent email)
        {
            string smtpFrom = ConfigurationManager.AppSettings["SMTP_FROM"];
            string smtpUser = ConfigurationManager.AppSettings["SMTP_USERNAME"];
            string smtpPassword = ConfigurationManager.AppSettings["SMTP_PASSWORD"];
            string smtpHost = ConfigurationManager.AppSettings["SMTP_HOST"];
            int smtpPort = int.Parse(ConfigurationManager.AppSettings["SMTP_PORT"]);
            bool smtpEnableSsl = bool.Parse(ConfigurationManager.AppSettings["SMTP_ENABLE_SSL"]);

            // Create an SMTP client with the specified host name and port.
            using (SmtpClient client = new SmtpClient(smtpHost, smtpPort))
            {
                // Create a network credential with your SMTP user name and password.
                client.Credentials = new NetworkCredential(smtpUser, smtpPassword);

                // Use SSL when accessing Amazon SES. The SMTP session will begin on an unencrypted connection, and then 
                // the client will issue a STARTTLS command to upgrade to an encrypted connection using SSL.
                client.EnableSsl = true;

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(smtpFrom);
                foreach (var item in email.SendTo)
                {
                    mailMessage.To.Add(item);
                }
                mailMessage.Subject = email.Subject;
                mailMessage.Body = email.Body;

                mailMessage.IsBodyHtml = true;

                client.Send(mailMessage);
            }
        }

        //Send Mail by OutDomain
        public void SendEmailByOutDomain(NotificationContent email)
        {
            try
            {
                string smtpFrom = ConfigurationManager.AppSettings["SMTP_FROM"];
                string smtpUser = ConfigurationManager.AppSettings["SMTP_USERNAME"];
                string smtpPassword = ConfigurationManager.AppSettings["SMTP_PASSWORD"];

                MailAddress from = new MailAddress(smtpFrom);
                MailMessage myMessage = new MailMessage();

                myMessage.From = from;
                foreach (var item in email.SendTo)
                {
                    myMessage.To.Add(item);
                }
                myMessage.Subject = email.Subject; ;
                myMessage.Body = email.Body;
                myMessage.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["SMTP_ENABLE_SSL"]);
                    smtp.Host = ConfigurationManager.AppSettings["SMTP_HOST"];
                    smtp.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_PORT"]);
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(smtpUser, smtpPassword);
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                    smtp.SendCompleted += (s, e) => { smtp.Dispose(); };
                    smtp.Send(myMessage);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


using Azure.Identity;
using JricaStudioWebApi.Services.Contracts;
using System.Net;
using System.Net.Mail;

namespace JricaStudioWebApi.Services
{
    /// <inheritdoc cref="IEmailSenderService"/>
    public class EmailSenderService : IEmailSenderService
    {
        private readonly string _username;
        private readonly string _password;

        public EmailSenderService(IConfiguration configuration)
        {
            _username = configuration.GetValue<string>("EmailUsername");
            _password = configuration.GetValue<string>("EmailPassword");
        }

        public async Task SendContactEmail(string fromEmail, string subject, string message)
        {
            MailMessage newMessage = new MailMessage();
            newMessage.From = new MailAddress(_username, "JRica.Studio Contact Form");
            newMessage.Subject = subject;
            newMessage.To.Add(new MailAddress(_username));
            newMessage.Body = message;
            newMessage.IsBodyHtml = true;

            var smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Port = 587,
                Credentials = new NetworkCredential(_username, _password),
                EnableSsl = true
            };
            try
            {
                await smtpClient.SendMailAsync(newMessage);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task SendNotificationEmail(string emailTo, string subject, string message)
        {


            MailMessage newMessage = new MailMessage();
            newMessage.From = new MailAddress(_username, "JRica.Studio Appointment Notifications");
            newMessage.Subject = subject;
            newMessage.To.Add(new MailAddress(emailTo));
            newMessage.Body = message;
            newMessage.IsBodyHtml = true;

            var smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Port = 587,
                Credentials = new NetworkCredential(_username, _password),
                EnableSsl = true
            };
            try
            {
                await smtpClient.SendMailAsync(newMessage);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task SendResetEmail(string emailTo, string subject, string message)
        {


            MailMessage newMessage = new MailMessage();
            newMessage.From = new MailAddress(_username, "JRica.Studio Accounts");
            newMessage.Subject = subject;
            newMessage.To.Add(new MailAddress(emailTo));
            newMessage.Body = message;
            newMessage.IsBodyHtml = true;

            var smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Port = 587,
                Credentials = new NetworkCredential(_username, _password),
                EnableSsl = true
            };
            try
            {
                await smtpClient.SendMailAsync(newMessage);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task SentConfirmContactMadeEmail(string toEmail, string subject, string message)
        {
            MailMessage newMessage = new MailMessage();
            newMessage.From = new MailAddress(_username, "JRica.Studio Accounts");
            newMessage.Subject = subject;
            newMessage.To.Add(new MailAddress(toEmail));
            newMessage.Body = message;
            newMessage.IsBodyHtml = true;

            var smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Port = 587,
                Credentials = new NetworkCredential(_username, _password),
                EnableSsl = true
            };
            try
            {
                await smtpClient.SendMailAsync(newMessage);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

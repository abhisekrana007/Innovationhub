using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MimeKit;
using NotificationService.Configuration;
using NotificationService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.Services
{
    public class EmailService : IEmailService
    {
        EmailSettings _emailSettings = null;
        public EmailService(IOptions<EmailSettings> options)
        {
            _emailSettings = options.Value;
        }

        public bool SendEmail(EmailData emailData)
        {
            try
            {
                MimeMessage emailMessage = new MimeMessage();

                MailboxAddress emailFrom = new MailboxAddress(_emailSettings.Name, _emailSettings.EmailId);
                emailMessage.From.Add(emailFrom);

                MailboxAddress emailTo = new MailboxAddress(emailData.EmailToName, emailData.EmailToId);
                emailMessage.To.Add(emailTo);

                emailMessage.Subject = emailData.EmailSubject;

                BodyBuilder emailBodyBuilder = new BodyBuilder();
                emailBodyBuilder.TextBody = emailData.EmailBody;
                emailMessage.Body = emailBodyBuilder.ToMessageBody();

                SmtpClient emailClient = new SmtpClient();
                emailClient.Timeout = 5000;
                //emailClient.Connect(_emailSettings.Host, _emailSettings.Port, _emailSettings.UseSSL);
                emailClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                emailClient.Authenticate(_emailSettings.EmailId, _emailSettings.Password);
                emailClient.Send(emailMessage);
                emailClient.Disconnect(true);
                emailClient.Dispose();

                return true;
            }
            catch(Exception ex)
            {
                //Log Exception Details
                return false;
            }
        }


        public bool SendUserWelcomeEmail(UserData userData)
        {
            try
            {
                MimeMessage emailMessage = new MimeMessage();

                MailboxAddress emailFrom = new MailboxAddress(_emailSettings.Name, _emailSettings.EmailId);
                emailMessage.From.Add(emailFrom);

                MailboxAddress emailTo = new MailboxAddress(userData.UserName, userData.UserEmailId);
                emailMessage.To.Add(emailTo);

                emailMessage.Subject = "Welcome To Our Project";

                string FilePath = Directory.GetCurrentDirectory() + "\\Templates\\WelcomeEmail.html";
                string EmailTemplateText = File.ReadAllText(FilePath);

                EmailTemplateText = string.Format(EmailTemplateText, userData.UserName, DateTime.Now.Date.ToShortDateString());

                BodyBuilder emailBodyBuilder = new BodyBuilder();
                emailBodyBuilder.HtmlBody = EmailTemplateText;
                emailMessage.Body = emailBodyBuilder.ToMessageBody();

                SmtpClient emailClient = new SmtpClient();
                emailClient.Connect(_emailSettings.Host, _emailSettings.Port, _emailSettings.UseSSL);
                emailClient.Authenticate(_emailSettings.EmailId, _emailSettings.Password);
                emailClient.Send(emailMessage);
                emailClient.Disconnect(true);
                emailClient.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                //Log Exception Details
                return false;
            }
        }

    }
}

using NotificationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.Services
{
    public interface IEmailService
    {
        bool SendEmail(EmailData emailData);
        
        bool SendUserWelcomeEmail(UserData userData);
    }
}

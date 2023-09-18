using Microsoft.AspNetCore.Mvc;
using NotificationService.Models;
using NotificationService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        IEmailService _emailService = null;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public bool SendEmail(EmailData emailData)
        {
            return _emailService.SendEmail(emailData);
        }


        [Route("SendUserWelcomeEmail")]
        [HttpPost]
        public bool SendUserWelcomeEmail([FromForm]UserData userData)
        {
            return _emailService.SendUserWelcomeEmail(userData);
        }
    }
}

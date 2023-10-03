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
        private readonly IEmailService _emailService;
        private readonly Consumer _consumer;
        public EmailController(IEmailService emailService,Consumer consumer)
        {
            _emailService = emailService;
            _consumer = consumer;
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

        [HttpGet]
        public IActionResult Get()
        {
            // Start the RabbitMQ consumer when making a GET request
            _consumer.ReceiveMessage();
            return Ok("New Project Is Recongnized in the platform");
        }
    }
}

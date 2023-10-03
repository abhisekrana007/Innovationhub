using System;
using System.Text;
using NotificationService.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
namespace NotificationService.Services
{
    public class Consumer
    {
        private readonly IEmailService _emailService;



        public Consumer(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public void ReceiveMessage()
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("ProjectNotification", durable: true, exclusive: false, autoDelete: false, arguments: null);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
                // Handle the received message, e.g., send an email
                _emailService.SendEmail(new EmailData { /* email data from message */ });
            };
            channel.BasicConsume("ProjectNotification", true, consumer);
            //Console.ReadLine();
        }
    }
}

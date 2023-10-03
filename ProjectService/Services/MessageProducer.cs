using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace ProjectService.Services
{
    public class MessageProducer
    {
        public void SendMessage()
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };



            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("ProjectNotification", durable: true, exclusive: false, autoDelete: false, arguments: null);

            var message = new { Name = "Producer", Message = "Message Sent" };
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));



            channel.BasicPublish("", "ProjectNotification", body: body);
        }

    }
}

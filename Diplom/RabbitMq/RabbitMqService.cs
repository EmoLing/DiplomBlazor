using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Diplom.RabbitMq
{
    public class RabbitMqService : IRabbitMqService
    {
        public void SendMessage(object obj)
        {
            var message = JsonSerializer.Serialize(obj);
            SendMessage(message);
        }

        public void SendMessage(string message)
        {
            // Не забудьте вынести значения "localhost" и "MyQueue"
            // в файл конфигурации
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 49158
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "Ads",
                           durable: false,
                           exclusive: false,
                           autoDelete: false,
                           arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                           routingKey: "Ads",
                           basicProperties: null,
                           body: body);

        }
    }
}

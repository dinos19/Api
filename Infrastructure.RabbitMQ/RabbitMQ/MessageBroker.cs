using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RabbitMQ
{
    public class MessageBroker : IMessageBroker
    {
        private static readonly string ExchangeName = "ApiExchange";
        private static readonly string RoutingKey = "ApiRoutingKey";
        private static readonly string QueueName = "Messages";
        private string RabbitMQUri { get; set; }

        public MessageBroker(IConfiguration configuration)
        {
            RabbitMQUri = configuration.GetConnectionString("RabbitMQConnectionString");
        }

        public Task<bool> PublishMessage(string UserId, string message)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri(RabbitMQUri);
            factory.ClientProvidedName = "Rabbit API Sender";

            IConnection cnn = factory.CreateConnection();
            IModel channel = cnn.CreateModel();
            var headers = new Dictionary<string, object> { { "UserId", UserId } };
            var properties = channel.CreateBasicProperties();
            properties.Headers = headers;
            channel.ExchangeDeclare(ExchangeName, ExchangeType.Headers);
            channel.QueueDeclare(QueueName, false, false, false, null);
            //channel.QueueBind(QueueName, ExchangeName, null, headers);

            byte[] messageBodyBytes = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(ExchangeName, RoutingKey, properties, messageBodyBytes);

            channel.Close();
            cnn.Close();

            return Task.FromResult<bool>(true);
        }
    }
}
using Data;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace ProducerSample.Services
{
    public class RabbitMQService
    {
        private readonly IConfiguration _configuration;

        public RabbitMQService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendMessage(SumModel sumModel)
        {
            var factory = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMQ:HostName"],
                UserName = _configuration["RabbitMQ:UserName"],
                Password = _configuration["RabbitMQ:Password"]
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "sum_queue",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                //string message = $"{sumModel.Number1},{sumModel.Number2}";
                string message = JsonConvert.SerializeObject(sumModel);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                    routingKey: "sum_queue",
                    basicProperties: null,
                    body: body);
                Console.WriteLine(message);
            }
        }
    }
}

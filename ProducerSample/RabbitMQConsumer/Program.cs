using Data;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMQConsumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "sum_queue",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    //var numbers = message.Split(',');
                    var sumModel = JsonConvert.DeserializeObject<SumModel>(message);

                    int sum = sumModel.Number1 + sumModel.Number2;
                    Console.WriteLine($"Sonuc: {sum}");

                };

                channel.BasicConsume(queue: "sum_queue",
                    autoAck: true,
                    consumer: consumer);

                Console.ReadLine();
            }
        }
    }
}
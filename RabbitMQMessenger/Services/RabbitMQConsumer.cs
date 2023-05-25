using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQMessenger.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQMessenger.Services
{
    public class RabbitMQConsumer
    {
        private readonly RabbitMQConfig rabbitMQConfig;

        public RabbitMQConsumer(RabbitMQConfig rabbitMQConfig)
        {
            this.rabbitMQConfig = rabbitMQConfig;
        }


        public static void SendMessage(string message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "http://localhost:15672",
                UserName = "guest",
                Password = "guest"
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "your_queue_name", durable: false, exclusive: false, autoDelete: false, arguments: null);

                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "", routingKey: "your_queue_name", basicProperties: null, body: body);
            }
        }


        //public void StartConsuming()
        //{
        //    var factory = new ConnectionFactory()
        //    {
        //        HostName = rabbitMQConfig.Hostname,
        //        UserName = rabbitMQConfig.Username,
        //        Password = rabbitMQConfig.Password
        //    };

        //    using var connection = factory.CreateConnection();
        //    using var channel = connection.CreateModel();
        //    var exchangeNAme = "demo_exchange";
        //    var routeKey = "demo-routing-Key";
        //    //channel.ExchangeDeclare(exchangeNAme, ExchangeType.Direct); //
        //    channel.QueueDeclare(queue: rabbitMQConfig.QueueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        //    //channel.QueueBind(rabbitMQConfig.QueueName, exchangeNAme, routeKey);

        //    var consumer = new EventingBasicConsumer(channel);
        //    consumer.Received += (model, args) =>
        //    {
        //        var body = args.Body.ToArray();
        //        var message = Encoding.UTF8.GetString(body);
        //        Console.WriteLine("Received message: {0}", message);
        //        channel.BasicAck(args.DeliveryTag, true);
        //    };

        //    channel.BasicConsume(queue: rabbitMQConfig.QueueName, autoAck: true, consumer: consumer);
        //}
    }
}

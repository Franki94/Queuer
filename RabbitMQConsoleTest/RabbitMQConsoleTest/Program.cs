using RabbitMQ.Client;
using System;

namespace RabbitMQConsoleTest
{
    class Program
    {
        private const string HostName = "localhost";
        private const string UserName = "guest";
        private const string Password = "guest";

        static void Main(string[] args)
        {
            var connectionFactory = new RabbitMQ.Client.ConnectionFactory() { HostName = HostName, UserName = UserName, Password = Password };
            var connection = connectionFactory.CreateConnection();
            var model = connection.CreateModel();
            //model.BasicPublish();

            model.QueueDeclare("MyQueue", true, false, false, null);
            Console.WriteLine("Queue creates");

            model.ExchangeDeclare("MyExchange", ExchangeType.Topic);
            Console.WriteLine("Exchange created");

            model.QueueBind("MyQueue", "MyExchange", "cars");
            Console.WriteLine("Hello World!");
        }
    }
}

using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitMQConsoleTest
{
    class Program
    {
        private const string HostName = "localhost";
        private const string UserName = "guest";
        private const string Password = "guest";

        private const string QueueName = "MyQueue";
        private const string ExchangeName = "";
        static void Main(string[] args)
        {
            Console.WriteLine("Starting RabbitMQ Message Sender");
            Console.WriteLine();
            Console.WriteLine();

            var connectionFactory = new RabbitMQ.Client.ConnectionFactory() { HostName = HostName, UserName = UserName, Password = Password };
            var connection = connectionFactory.CreateConnection();
            var model = connection.CreateModel();
            //model.BasicPublish();

            //model.QueueDeclare("MyQueue", true, false, false, null);
            //Console.WriteLine("Queue creates");

            //model.ExchangeDeclare("MyExchange", ExchangeType.Topic);
            //Console.WriteLine("Exchange created");

            //model.QueueBind("MyQueue", "MyExchange", "cars");
            //Console.WriteLine("Hello World!");

            var properties = model.CreateBasicProperties();
            properties.Persistent = false;

            //Serialize
            byte[] messageBuffer = Encoding.Default.GetBytes("This is my message");


            //Send Message
            model.BasicPublish(ExchangeName, QueueName, properties, messageBuffer);

            Console.WriteLine("Message sent");
            Console.ReadLine();
        }
    }
}

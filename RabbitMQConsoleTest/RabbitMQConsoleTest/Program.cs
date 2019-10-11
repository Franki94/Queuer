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
            Console.WriteLine("Hello World!");
        }
    }
}

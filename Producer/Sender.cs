using RabbitMQ.Client;
using System;
using System.Dynamic;
using System.Text;

namespace Producer
{
    class Sender
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("BasicTest", false, false, false, null);
                string message = "Getting started with .Net Core RabbitMQ . . .";
                var body = Encoding.UTF8.GetBytes(message);
                for (int i = 0; i < 5; i++)
                {
                    channel.BasicPublish("", "BasicTest", null, body);
                    Console.WriteLine("Sent message : {0} . . .", message);
                }
            }
            Console.WriteLine("Press [enter] to exit the Sender App...");
            Console.ReadLine();
        }
    }
}

using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ
{
    class Program
    {


        static string _hostName = "localhost";
        static string _userName = "guest";
        static string _password = "guest";
        static string _queueName = "Module1.Sample3";
        static string _exchangeName = "";


        static void Main(string[] args)
        {

            Console.WriteLine("Starting RabbitMQ Message Sender");
            Console.WriteLine();
            Console.WriteLine();

            var connectionFactory = new ConnectionFactory()
            {
                UserName = _userName,
                Password = _password,
                HostName = _hostName
            };

            var connection = connectionFactory.CreateConnection();
            var model = connection.CreateModel();
            var basicProperties = model.CreateBasicProperties();
            basicProperties.Persistent = false;

            byte[] messageBuffer = Encoding.Default.GetBytes("this is my message");

            using (model)
            {
                model.BasicPublish(_exchangeName, _queueName, basicProperties, messageBuffer);
            }

            Console.WriteLine("Message Sent");
            Console.ReadLine();
        }
    }
}

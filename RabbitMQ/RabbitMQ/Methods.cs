using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ
{
    public static class Methods
    {


        public static void MakeBasicQueue()
        {
            var connectionFactory = new ConnectionFactory()
            {
                UserName = "guest",
                Password = "guest",
                HostName = "localhost"
            };

            var connection = connectionFactory.CreateConnection();
            using (var model = connection.CreateModel())
            {
                model.QueueDeclare("RuntimeQueue", true, false, false, null);
                model.ExchangeDeclare("RuntimeExchange", ExchangeType.Topic);
                model.QueueBind("RuntimeQueue", "RuntimeExchange", "cars");

            }

        }

    }
}

using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class RabbitSender : IDisposable
    {

        const string HostName = "localhost";
        const string UserName = "guest";
        const string Password = "guest";
        const string QueueName = "Module2.Sample2";
        const string ExchangeName = "";
        const bool IsDurable = true;

        private ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _model;

        public RabbitSender()
        {
            _connectionFactory = new ConnectionFactory()
            {
                HostName = HostName, UserName = UserName, Password = Password

            };

            _connection = _connectionFactory.CreateConnection();
            _model = _connection.CreateModel();
        }

        internal void Send(string message)
        {

            var basicProperties = _model.CreateBasicProperties();
            basicProperties.Persistent = true;

            var body = Encoding.Default.GetBytes(message);

            _model.BasicPublish(ExchangeName, QueueName, basicProperties, body);
            
        }

        public void Dispose()
        {
            _connection.Dispose();
            _model.Dispose();
        }
    }
}

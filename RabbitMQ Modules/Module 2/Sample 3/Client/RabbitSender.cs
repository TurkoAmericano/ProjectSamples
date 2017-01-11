using RabbitMQ.Client;
using RabbitMQ.Client.Events;
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
        const string QueueName = "Module2.Sample7.Queue";
        const string ExchangeName = "";
        const bool IsDurable = true;

        private ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _model;
        private EventingBasicConsumer _consumer;
        private string _responseQueue;

        public RabbitSender()
        {
            _connectionFactory = new ConnectionFactory()
            {
                HostName = HostName,
                UserName = UserName,
                Password = Password

            };

            _connection = _connectionFactory.CreateConnection();
            _model = _connection.CreateModel();

            _consumer = new EventingBasicConsumer(_model);
            _responseQueue = _model.QueueDeclare().QueueName;

        }

        internal string Send(string message, TimeSpan timeOut)
        {
            var correlationToken = Guid.NewGuid().ToString();

            // Setup properties
            var properties = _model.CreateBasicProperties();
            properties.ReplyTo = _responseQueue;
            properties.CorrelationId = correlationToken;

            byte[] messageBuffer = Encoding.Default.GetBytes(message);

            var timeoutAt = DateTime.Now + timeOut;

            _model.BasicPublish("", QueueName, properties, messageBuffer);

            var responseMessage = string.Empty;

            while (DateTime.Now <= timeoutAt)
            {
                var result = _model.BasicGet(_responseQueue, true);
                if (result != null)
                {
                    Console.WriteLine(Encoding.Default.GetString(result.Body));
                }
            }

            throw new TimeoutException("The response was late");

        }

        public void Dispose()
        {
            if (_connection != null) _connection.Dispose();
            if (_model != null) _model.Dispose();
        }
    }
}

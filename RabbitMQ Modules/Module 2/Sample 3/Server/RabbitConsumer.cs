using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Server
{
    public class RabbitConsumer : IDisposable
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

        public delegate void OnReceiveMessage(string message);

        public bool Enabled { get; internal set; }

        public RabbitConsumer()
        {
            _connectionFactory = new ConnectionFactory()
            {
                HostName = HostName, 
                UserName = UserName,
                Password = Password

            };

            _connection = _connectionFactory.CreateConnection();
            _model = _connection.CreateModel();
            _model.BasicQos(0, 1, false);
        }

        internal void Start()
        {
            Console.WriteLine("Listening....");

            while (Enabled)
            {

                var result = _model.BasicGet(QueueName, false);

                if (result == null) continue;

                string message = Encoding.Default.GetString(result.Body);

                var response = string.Format("Processed message {0} : Response is good", message);
                Console.WriteLine(response);
                var replyProperties = _model.CreateBasicProperties();
                replyProperties.CorrelationId = result.BasicProperties.CorrelationId;
                byte[] messageBuffer = Encoding.Default.GetBytes(response);
                _model.BasicPublish("", result.BasicProperties.ReplyTo, replyProperties, messageBuffer);
                _model.BasicAck(result.DeliveryTag, false);
            }

        }

        public void Dispose()
        {
            _connection.Dispose();
            _model.Dispose();
        }
    }
}
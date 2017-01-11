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
        const string QueueName = "Module2.Sample2";
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
            var consumer = new EventingBasicConsumer(_model);

            consumer.Received += (ch, ea) =>
                {
                    var message = Encoding.Default.GetString(ea.Body);

                    Console.WriteLine("Message received - {0}", message);
                    
                };

            string consumerTag = _model.BasicConsume(QueueName, true, consumer);



        }

        public void Dispose()
        {
            _connection.Dispose();
            _model.Dispose();
        }
    }
}
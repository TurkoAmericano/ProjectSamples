using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.MessagePatterns;
using System;
using System.Text;

namespace Server
{
    public class RabbitConsumer : IDisposable
    {


        const string HostName = "localhost";
        const string UserName = "guest";
        const string Password = "guest";
        const string QueueName = "Module2.Sample3.Queue1";
        const string ExchangeName = "";
        const bool IsDurable = true;

        private ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _model;
        private Subscription _subscription;

        
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

            _subscription = new Subscription(_model, "Module2.Sample3.Queue1");

            var consumer = new ConsumeDelegate(Poll);
            consumer.Invoke();
            
        }

        private delegate void ConsumeDelegate;

        private void Poll()
        {
            var deliveryArgs = _subscription.Next();
            var message = Encoding.Default.GetString(deliveryArgs.Body);
            Console.WriteLine("Message received - {0}", message);
            _subscription.Ack(deliveryArgs);
        }

        public void Dispose()
        {
            _connection.Dispose();
            _model.Dispose();
        }
    }
}
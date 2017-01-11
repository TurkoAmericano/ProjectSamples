using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Starting RabbitMQ Message Sender");
            Console.WriteLine();
            Console.WriteLine();

            var messageCount = 0;

            Console.WriteLine("Press enter key to send message");


            while (true)
            {

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.Q)
                    break;

                if (key.Key != ConsoleKey.Enter) continue;

                var message = string.Format("Message {0}", messageCount);

                Console.WriteLine(string.Format("Sending - {0}", message));

                using (var sender = new RabbitSender())
                {
                    var response = sender.Send(message, new TimeSpan(0, 0, 3));
                    messageCount++;
                }

                Console.WriteLine();

            }
        }
    }
}

﻿using System;
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

                var message = string.Format("Message {0}", messageCount);

                Console.WriteLine(string.Format("Sending - {0}", message));

                using (var sender = new RabbitSender())
                {
                    sender.Send(message);
                }

                messageCount++;

            }
        }
    }
}

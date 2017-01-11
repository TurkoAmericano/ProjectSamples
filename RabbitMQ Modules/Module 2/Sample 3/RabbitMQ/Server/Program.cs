using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("RabbitMQ starting queue processor");
            Console.WriteLine();
            Console.WriteLine();

            var queueProcessor = new RabbitConsumer() { Enabled = true };

            using (queueProcessor)
            {
                queueProcessor.Start();

                Console.WriteLine("Listening....");
                Console.Read();
            }

            

        }
    }
}

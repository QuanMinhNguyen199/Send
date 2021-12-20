// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using System.Text;

namespace Send
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "SampleK", durable: false, exclusive: false, autoDelete: false, arguments: null);
                string message = "I'm from the host queue";
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "", routingKey: "SampleK", basicProperties: null, body:body);
                Console.WriteLine("Sent {0}",message);
            }
            Console.WriteLine("Press [Enter] to exit !");
            Console.ReadLine();

        }
    }
}

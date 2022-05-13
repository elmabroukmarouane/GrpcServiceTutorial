using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace ConsoleGrpcServiceTutorial
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Enter the name request ...");
            var name = Console.ReadLine();
            Console.WriteLine("Enter your message ...");
            var message = Console.ReadLine();
            using (var channel = GrpcChannel.ForAddress("https://localhost:5001"))
            {
                var client = new Greeter.GreeterClient(channel);
                var reply = await client.CallServiceGrpcAsync(new CallServiceGrpcoRequest
                {
                    Name = name,
                    Message = message
                });
                Console.WriteLine("Message from GRPC Call Service : " + reply.Message);
                Console.WriteLine("Press any key to exit ...");
                Console.ReadLine();
            }
        }
    }
}

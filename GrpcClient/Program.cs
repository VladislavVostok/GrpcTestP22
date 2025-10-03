using Grpc.Net.Client;
using GrpcServer;
using System.Linq.Expressions;


namespace GrpcClient
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			var channel = GrpcChannel.ForAddress("https://localhost:7236");

			var client = new Greeter.GreeterClient(channel);

			var reply = await client.SayHelloAsync(
						new HelloRequest { Name = "gRPC Client" }
					);


			Console.WriteLine("Greating: " + reply.Message);
			Console.ReadKey();

			var client2 = new Calculator.CalculatorClient(channel);

			var addResp = await client2.AddAsync(new ArithmeticRequest
			{
				FOper = 23.45,
				SOper = 134.12,
			});

			Console.WriteLine("Calculator: " + addResp.Result);
			Console.ReadKey();

		}
	}
}

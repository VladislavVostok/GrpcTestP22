using Grpc.Net.Client;
using GrpcChatServer;

namespace GrpcChatClient
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var channel = GrpcChannel.ForAddress("https://localhost:7029");
			//var client = new Chat.(channel);
		}
	}
}

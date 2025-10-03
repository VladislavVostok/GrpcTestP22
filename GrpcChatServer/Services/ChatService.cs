using Grpc.Core;

namespace GrpcChatServer.Services
{
	public class ChatService : Chat.ChatBase
	{
		private static readonly List<IServerStreamWriter<ChatMessage>> _subsribers = new();
		private readonly ILogger<ChatService> _logger;
		public ChatService(ILogger<ChatService> logger) {
			_logger = logger;
		}

		public override async Task JoinChat(IAsyncStreamReader<ChatMessage> requestStream, IServerStreamWriter<ChatMessage> responseStream, ServerCallContext context)
		{
			_subsribers.Add(responseStream);

			try
			{
				while (await requestStream.MoveNext())
				{
					var message = requestStream.Current;
					foreach (var subscriber in _subsribers)
					{
						try
						{
							await subscriber.WriteAsync(message);
						}
						catch (Exception ex)
						{
							_logger.LogError(ex, $"Сообщение не отправлено {requestStream.Current.User}!");
						}
					}
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Здесь нам втирают какую-то дичь!");
			}
			finally {
				_subsribers.Remove(responseStream);
			}
		}
	}
}

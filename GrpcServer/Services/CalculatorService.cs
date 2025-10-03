using Grpc.Core;
using GrpcServer;

namespace GrpcServer.Services
{
	public class CalculatorService : Calculator.CalculatorBase
	{
		private readonly ILogger<CalculatorService> _logger;
		public CalculatorService(ILogger<CalculatorService> logger)
		{
			_logger = logger;
		}

		public override Task<ArithmeticResponse> Add(ArithmeticRequest request, ServerCallContext context)
		{
			var result = request.FOper + request.SOper;
			_logger.LogInformation("ќпераци€ сложени€ на сервере выполнилась блест€ще!");
			return Task.FromResult(new ArithmeticResponse { Result = result });

		}

		public override Task<ArithmeticResponse> Substract(ArithmeticRequest request, ServerCallContext context)
		{
			var result = request.FOper + request.SOper;
			_logger.LogInformation("ќпераци€ сложени€ на сервере выполнилась блест€ще!");
			return Task.FromResult(new ArithmeticResponse { Result = result });

		}

		public override Task<ArithmeticResponse> Multiply(ArithmeticRequest request, ServerCallContext context)
		{
			var result = request.FOper + request.SOper;
			_logger.LogInformation("ќпераци€ сложени€ на сервере выполнилась блест€ще!");
			return Task.FromResult(new ArithmeticResponse { Result = result });

		}
		public override Task<ArithmeticResponse> Devided(ArithmeticRequest request, ServerCallContext context)
		{
			var result = request.FOper + request.SOper;
			_logger.LogInformation("ќпераци€ сложени€ на сервере выполнилась блест€ще!");
			return Task.FromResult(new ArithmeticResponse { Result = result });

		}
	}
}

/*using Microsoft.AspNetCore.Mvc;

namespace WeatherAggregator.Authentication
{
	public class ApiKeyEndpointFilter : IEndpointFilter
	{
		private readonly IConfiguration _configuration;

		public ApiKeyEndpointFilter(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public async ValueTask<object> InvokeAsync(
			EndpointFilterInvocationContext context,
			EndpointFilterDelegate next)
		{
			if (!context.HttpContext.Request.Headers.TryGetValue(AuthConstants.ApiKeyHeaderName, out
					var extractedApiKey))
			{
				return new UnauthorizedHttpObjectResult("Api Key missing");
			}
			var apiKey = _configuration.GetValue<string>(AuthConstants.ApiKeySectionName);
			if (!apiKey.Equals(extractedApiKey))
			{
				return new UnauthorizedHttpObjectResult("Invalid Api Key");
			}
			return await next(context);
		}
	}
}*/

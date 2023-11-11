using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAggregator.Authentication
{
	public class WeatherApiKeyAuthFilter : IAuthorizationFilter
	{
		private readonly IConfiguration _configuration;

		public WeatherApiKeyAuthFilter(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void OnAuthorization(AuthorizationFilterContext context)
		{
			if (!context.HttpContext.Request.Headers.TryGetValue(AuthConstants.WApiKeyHeaderName, out
					var extractedApiKey))
			{
				context.Result = new UnauthorizedObjectResult("Api Key was not provided");
				return;
			}
			var apiKey = _configuration.GetValue<string>(AuthConstants.WApiKeySectionName);
			if (!apiKey.Equals(extractedApiKey))
			{
				context.Result = new UnauthorizedObjectResult("Invalid Api Key");
				return;
			}
		}
	}
}

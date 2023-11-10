﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WeatherAggregator.Authentication
{
	public class ApiKeyAuthFilter : IAuthorizationFilter
	{
		private readonly IConfiguration _configuration;

		public ApiKeyAuthFilter(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void OnAuthorization(AuthorizationFilterContext context)
		{
			if (!context.HttpContext.Request.Headers.TryGetValue(AuthConstants.ApiKeyHeaderName, out
					var extractedApiKey))
			{
				context.Result = new UnauthorizedObjectResult("Api Key was not provided");
				return;
			}
			var apiKey = _configuration.GetValue<string>(AuthConstants.ApiKeySectionName);
			if (!apiKey.Equals(extractedApiKey))
			{
				context.Result = new UnauthorizedObjectResult("Invalid Api Key");
				return;
			}
		}
	}
}

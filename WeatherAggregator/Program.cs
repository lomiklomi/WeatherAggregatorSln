using WeatherAggregator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using WeatherAggregator.Authentication;
using Microsoft.Extensions.Logging.Console;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllers(/*x => x.Filters.Add<ApiKeyAuthFilter>()*/).AddNewtonsoftJson().
AddXmlDataContractSerializerFormatters();

builder.Services.AddScoped<ApiKeyAuthFilter>();

builder.Services.Configure<MvcNewtonsoftJsonOptions>(opts => {
	opts.SerializerSettings.NullValueHandling
	= Newtonsoft.Json.NullValueHandling.Ignore;
});

builder.Services.Configure<MvcOptions>(opts => {
	opts.RespectBrowserAcceptHeader = true;
	opts.ReturnHttpNotAcceptable = true;
});

builder.Services.AddSwaggerGen(c => {
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "Weather", Version = "v1" });

	c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
	{
		Description = "The Api Key to access the Api",
		Type = SecuritySchemeType.ApiKey,
		Name = "x-api-key",
		In = ParameterLocation.Header,
		Scheme = "ApiKeyScheme"
	});
	var scheme = new OpenApiSecurityScheme
	{
		Reference = new OpenApiReference
		{
			Type = ReferenceType.SecurityScheme,
			Id = "ApiKey"
		},
		In = ParameterLocation.Header
	};
	var requirment = new OpenApiSecurityRequirement
	{
		{ scheme, new List<string>() }
	};
	c.AddSecurityRequirement(requirment);
});

//builder.Services.AddTransient<IApiKeyValidation, ApiKeyValidation>();

var app = builder.Build();

app.Logger.LogInformation("Adding Routes");

app.MapControllers();

app.UseSwagger();

app.UseSwaggerUI(options => {
	options.SwaggerEndpoint("/swagger/v1/swagger.json", "Weather");
});


// app.UseMiddleware<ApiKeyAuthMiddleware>();

app.UseAuthorization();

app.MapGet("/Test", async (ILogger<Program> logger, HttpResponse response) =>
{
	logger.LogInformation("Testing logging in Program.cs");
	await response.WriteAsync("Testing");
});

app.Run();

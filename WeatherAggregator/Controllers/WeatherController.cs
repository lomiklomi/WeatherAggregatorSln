using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net;
using WeatherAggregator.Models;
using System.Text.Json;

using static System.Console;
using Microsoft.AspNetCore.Http.HttpResults;
using WeatherAggregator.Authentication;

namespace WeatherAggregator.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class WeatherController : ControllerBase
	{
		string APIKey = "acd39150654a20a2175354a387cb163c";
		string APIWeatherKey = "41b2b2d407da44b4869201200230811";
		string APITomorrowKey = "1Z4rivuCVVyKsRoGsXXGAtERoLP0Jt3d";

		[HttpGet("/openWeatherApi/{name}")]
		[ServiceFilter(typeof(ApiKeyAuthFilter))]
		public WeatherInfo.Root? GetOpenWeather(string name)
		{
			using (System.Net.WebClient web = new System.Net.WebClient())
			{
				string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", name, APIKey);
				var json = web.DownloadString(url);
				WeatherInfo.Root? info = JsonConvert.DeserializeObject<WeatherInfo.Root>(json);
				return info;
			}
		}

		[HttpGet("/WeatherApi/{name}")]
		public Weather.WeatherRoot? GetWeather(string name)
		{
			using (System.Net.WebClient web = new System.Net.WebClient())
			{
				string url = string.Format("http://api.weatherapi.com/v1/current.json?key={0}&q={1}&aqi=no", APIWeatherKey, name);
				var json = web.DownloadString(url);
				Weather.WeatherRoot? info = JsonConvert.DeserializeObject<Weather.WeatherRoot>(json);
				return info;
			}
		}

		[HttpGet("/TomorrowApi/{name}")]
		public TomorrowWeather.TomorrowRoot? GetTomorrowsWeather(string name)
		{
			using (System.Net.WebClient web = new System.Net.WebClient())
			{
				string url = string.Format("https://api.tomorrow.io/v4/timelines?location={0}&fields=temperature&timesteps=1h&units=metric&apikey={1}", name, APITomorrowKey);
				var json = web.DownloadString(url);
				TomorrowWeather.TomorrowRoot? info = JsonConvert.DeserializeObject<TomorrowWeather.TomorrowRoot>(json);
				return info;
			}
		}

		[HttpGet("services")]
		public Services.ServiceRoot? GetWeatherServices()
		{
			string flagWeather = "true";
			string flagOpenApi = "true";
			string flagTomorrow = "true";
			Services.ServiceRoot? sr = new Services.ServiceRoot();

			System.Net.WebClient client = new System.Net.WebClient();
			try
			{
				string result = client.DownloadString("https://api.openweathermap.org/data/2.5/weather?q=London&appid=acd39150654a20a2175354a387cb163c");
				flagOpenApi = "true";
			}
			catch (System.Net.WebException ex)
			{
				flagOpenApi = "false";
			}

			try
			{
				string result = client.DownloadString("http://api.weatherapi.com/v1/current.json?key=41b2b2d407da44b4869201200230811&q=London&aqi=no");
				flagWeather = "true";
			}
			catch (System.Net.WebException ex)
			{
				flagWeather = "false";
			}

			try
			{
				string result = client.DownloadString("https://api.tomorrow.io/v4/timelines?location=London&fields=temperature&timesteps=1h&units=metric&apikey=1Z4rivuCVVyKsRoGsXXGAtERoLP0Jt3d");
				flagTomorrow = "true";
			}
			catch (System.Net.WebException ex)
			{
				flagTomorrow = "false";
			}

			sr = new Services.ServiceRoot
			{
				OpenWeather = new Services.OpenWeather { isActive = flagOpenApi },
				Weather = new Services.WeatherApi { isActive = flagWeather },
				TomorrowWeather = new Services.TomorrowWeather { isActive = flagTomorrow }
			};
			return sr;
		}

		

		DateTime ConvertDateTime(long sec)
		{
			DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
			day = day.AddSeconds(sec).ToLocalTime();

			return day;
		}
	}
}

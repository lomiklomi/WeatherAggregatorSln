namespace WeatherAggregator.Models
{
	public class Services
	{
		public class OpenWeather
		{
			public string? isActive { get; set; } = "true";
		}
		public class TomorrowWeather
		{
			public string isActive { get; set; } = "true";
		}
		public class WeatherApi
		{
			public string isActive { get; set; } = "true";
		}

		public class ServiceRoot
		{
			public OpenWeather? OpenWeather { get; set; }
			public TomorrowWeather? TomorrowWeather { get; set; }
			public WeatherApi? Weather { get; set; }
		}
	}
}

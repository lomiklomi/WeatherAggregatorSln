using static WeatherAggregator.Models.WeatherInfo;

namespace WeatherAggregator.Models
{
	public class Weather
	{
		public class Condition
		{
			public string text { get; set; }
			public string icon { get; set; }
			public int code { get; set; }
		}

		public class Current
		{
			public int last_updated_epoch { get; set; }
			public string last_updated { get; set; }
			public double temp_c { get; set; }
			public double temp_f { get; set; }
			public int is_day { get; set; }
			public Condition condition { get; set; }
			public double wind_mph { get; set; }
			public double wind_kph { get; set; }
			public int wind_degree { get; set; }
			public string wind_dir { get; set; }
			public double pressure_mb { get; set; }
			public double pressure_in { get; set; }
			public double precip_mm { get; set; }
			public double precip_in { get; set; }
			public int humidity { get; set; }
			public int cloud { get; set; }
			public double feelslike_c { get; set; }
			public double feelslike_f { get; set; }
			public double vis_km { get; set; }
			public double vis_miles { get; set; }
			public double uv { get; set; }
			public double gust_mph { get; set; }
			public double gust_kph { get; set; }
		}

		public class Location
		{
			public string name { get; set; }
			public string region { get; set; }
			public string country { get; set; }
			public double lat { get; set; }
			public double lon { get; set; }
			public string tz_id { get; set; }
			public int localtime_epoch { get; set; }
			public string localtime { get; set; }
		}

		public class WeatherRoot
		{
			public Location location { get; set; }
			public Current current { get; set; }
		}
	}
}
/*
{
	"location": {
		"name": "London",
        "region": "City of London, Greater London",
        "country": "United Kingdom",
        "lat": 51.52,
        "lon": -0.11,
        "tz_id": "Europe/London",
        "localtime_epoch": 1699474449,
        "localtime": "2023-11-08 20:14"

	},
    "current": {
		"last_updated_epoch": 1699473600,
        "last_updated": "2023-11-08 20:00",
        "temp_c": 7.0,
        "temp_f": 44.6,
        "is_day": 0,
        "condition": {
			"text": "Clear",
            "icon": "//cdn.weatherapi.com/weather/64x64/night/113.png",
            "code": 1000

		},
        "wind_mph": 3.8,
        "wind_kph": 6.1,
        "wind_degree": 280,
        "wind_dir": "W",
        "pressure_mb": 1002.0,
        "pressure_in": 29.59,
        "precip_mm": 0.0,
        "precip_in": 0.0,
        "humidity": 93,
        "cloud": 0,
        "feelslike_c": 5.5,
        "feelslike_f": 41.9,
        "vis_km": 10.0,
        "vis_miles": 6.0,
        "uv": 1.0,
        "gust_mph": 7.3,
        "gust_kph": 11.7

	}
}
*/
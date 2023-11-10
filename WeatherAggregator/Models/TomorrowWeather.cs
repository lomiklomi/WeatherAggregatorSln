namespace WeatherAggregator.Models
{
	public class TomorrowWeather
	{
		public class Data
		{
			public List<Timeline> timelines { get; set; }
		}

		public class Interval
		{
			public DateTime startTime { get; set; }
			public Values values { get; set; }
		}

		public class TomorrowRoot
		{
			public Data data { get; set; }
		}

		public class Timeline
		{
			public string timestep { get; set; }
			public DateTime endTime { get; set; }
			public DateTime startTime { get; set; }
			public List<Interval> intervals { get; set; }
		}

		public class Values
		{
			public double temperature { get; set; }
		}
	}
}

/*
{"data":
{
	"timelines":
		[{"timestep":
			"1h",
			 endTime":
				"2023-11-13T21:00:00Z",
				"startTime":"2023-11-08T21:00:00Z",
				"intervals":
					[{"startTime":
						"2023-11-08T21:00:00Z",
						"values":{"temperature":9.63}
					 }, 
					{"startTime":
						"2023-11-08T22:00:00Z",
						"values":{"temperature":8.31}
					},{"startTime":"2023-11-08T23:00:00Z","values":{"temperature":7.25}},{"startTime":"2023-11-09T00:00:00Z","values":{"temperature":6.37}},{"startTime":"2023-11-09T01:00:00Z","values":{"temperature":6.11}},{"startTime":"2023-11-09T02:00:00Z","values":{"temperature":5.23}},{"startTime":"2023-11-09T03:00:00Z","values":{"temperature":4.79}},{"startTime":"2023-11-09T04:00:00Z"
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CodeSnippets.BCL
{
    public static class Json
    {
        public static string Serialize()
        {
            var rng = new Random();
            WeatherForecast weatherForecast = new WeatherForecast
            {
                Location = "Hangzhou",
                Temperature = rng.Next(-10, 45),
                Date = DateTimeOffset.UtcNow,
            };
            return JsonSerializer.Serialize(weatherForecast);
        }

        public static string GetSummary()
        {
            var json = "{\"Location\":\"Hangzhou\",\"Temperature\":4,\"Date\":\"2019-11-19T11:55:46.0310797+00:00\"}";
            var weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(json);
            return $"{weatherForecast.Location} {weatherForecast.Date.ToLocalTime().ToString("yyyy年MM月dd日")}的温度是{weatherForecast.Temperature} ℃";
        }
        class WeatherForecast
        {
            public string Location { get; set; }
            public int Temperature { get; set; }
            public DateTimeOffset Date { get; set; }
        }
    }
}

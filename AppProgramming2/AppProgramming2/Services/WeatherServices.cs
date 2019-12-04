using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppProgramming2.Models;
using Newtonsoft.Json.Linq;
using Xamarin.Essentials;

namespace AppProgramming2.Services
{
    public class WeatherServices
    {
        public string GetWeather(double lat, double lon)
        {
            string latstr = lat.ToString().Replace(",",".");
            string lonstr = lon.ToString().Replace(",",".");
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.openweathermap.org");

            HttpResponseMessage response = client.GetAsync($"/data/2.5/weather?lat={latstr}&lon={lonstr}&APPID=e43896063a255cf7922d414c0d78d9d2").Result;

            var result =  response.Content.ReadAsStringAsync().Result;
            Debug.WriteLine(result);
            return result;
        }
    }
}
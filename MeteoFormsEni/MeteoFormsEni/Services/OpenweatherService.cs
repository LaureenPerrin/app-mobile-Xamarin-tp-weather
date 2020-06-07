using System;
using System.Threading.Tasks;
using RestSharp;
using webservices.Models;

namespace MeteoFormsEni.Services
{
    public class OpenweatherService
    {
        public static async Task<IRestResponse<OpenWeatherMap>> GetCity(string cityName)
        {
            var client = new RestClient("https://api.openweathermap.org/data/2.5");

            var request = new RestRequest("/weather?units=metric&appid=a749c68b1d6b747844f278d71e4c718d", Method.GET);
            request.AddQueryParameter("q", cityName);
            request.RequestFormat = DataFormat.Json;
            
            // execute the request
            return await client.ExecuteGetAsync<OpenWeatherMap>(request);
        }
    }
}
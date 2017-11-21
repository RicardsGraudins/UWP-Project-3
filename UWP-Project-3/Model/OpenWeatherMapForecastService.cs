using System;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using static UWP_Project_3.Data.OpenWeatherMapForecast;

namespace UWP_Project_3.Model
{
    public class OpenWeatherMapForecastService
    {
        public async static Task<RootObject> GetForecast(double lat, double lon)
        {
            var http = new HttpClient();
            var url = String.Format("http://api.openweathermap.org/data/2.5/forecast?lat={0}&lon={1}&appid=eb64922b26737fc56879e068cef3ba9b", lat, lon);
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(ms);

            return data;
        }//GetForecast
    }//OpenWeatherMapForecastService
}//UWP

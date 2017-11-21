using System;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using static UWP_Project_3.Data.OpenWeatherMap;

namespace UWP_Project_3.Model
{
    public class OpenWeatherMapService
    {
        //Adapted from https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
        //             https://stackoverflow.com/questions/4836683/when-to-use-datacontract-and-datamember-attributes
        public async static Task<RootObject> GetWeather(double lat, double lon)
        {
            var http = new HttpClient();
            var url = String.Format("http://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&appid=eb64922b26737fc56879e068cef3ba9b", lat, lon);
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(ms);

            return data;
        }//GetWeather
    }//OpenWeatherMapService
}//UWP

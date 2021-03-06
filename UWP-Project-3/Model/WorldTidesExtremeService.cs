﻿using System;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using static UWP_Project_3.Data.WorldTidesExtremes;

namespace UWP_Project_3.Model
{
    public class WorldTidesExtremeService
    {
        public async static Task<RootObjectExtreme> GetMaxMinTides(double lat, double lon)
        {
            var http = new HttpClient();
            var url = String.Format("https://www.worldtides.info/api?extremes&lat={0}&lon={1}&key=05c658b6-2b86-4f46-9aa5-85f286aa471b", lat, lon);
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObjectExtreme));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObjectExtreme)serializer.ReadObject(ms);

            return data;
        }//GetMaxMinTides

        //Using Weather Fisher API https://github.com/RicardsGraudins/Weather-Fisher-API
        public async static Task<RootObjectExtreme> GetCounty(string county)
        {
            var http = new HttpClient();
            var url = String.Format("https://worldtidesforecast20171125090607.azurewebsites.net/?county={0}", county);
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();

            RootObjectExtreme deserializedObject = new RootObjectExtreme();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedObject.GetType());
            deserializedObject = ser.ReadObject(ms) as RootObjectExtreme;

            return deserializedObject;
        }//GetCounty
    }//WorldTidesExtremeService
}//UWP
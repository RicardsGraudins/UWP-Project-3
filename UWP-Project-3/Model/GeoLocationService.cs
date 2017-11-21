using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace UWP_Project_3.Model
{
    //Adapted from https://docs.microsoft.com/en-us/uwp/api/windows.devices.geolocation.geolocator
    //             https://docs.microsoft.com/en-us/windows/uwp/maps-and-location/get-location
    public class GeoLocationService
    {
        public async static Task<Geoposition> GetPosition()
        {
            try
            {
                var accessStatus = await Geolocator.RequestAccessAsync();
                if (accessStatus != GeolocationAccessStatus.Allowed)
                {
                    throw new GPSException("GPS not enabled.");
                }
                var geolocator = new Geolocator { DesiredAccuracyInMeters = 0 };
                var position = await geolocator.GetGeopositionAsync();
                return position;
            }//try
            catch (GPSException)
            {
                Debug.WriteLine("GPS not enabled.");
                return null;
            }//catch
        }//GetPosition

        public class GPSException : Exception
        {
            public String Message { get; set; }

            public GPSException(String msg)
            {
                Message = msg;
            }
        }//GPSException
    }//GeoLocationService
}//UWP
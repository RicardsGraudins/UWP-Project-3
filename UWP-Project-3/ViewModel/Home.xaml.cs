using System;
using System.Diagnostics;
using System.Threading.Tasks;
using UWP_Project_3.Model;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using static UWP_Project_3.Data.OpenWeatherMap;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP_Project_3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        public String latitudecord { get; set; }
        public String longitudecord { get; set; }
        public Home()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
            {
                //loading animaton
                CurrentWeather();
            }
            else
            {
                CurrentWeather();
            }
            base.OnNavigatedTo(e);
        }//OnNavigatedTo

        //Adapted from https://docs.microsoft.com/en-us/uwp/api/windows.devices.geolocation.geolocator
        //             https://docs.microsoft.com/en-us/windows/uwp/maps-and-location/get-location
        public class locationManager
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
        }//locationManager

        public class GPSException : Exception
        {
            public String Message { get; set; }

            public GPSException(String msg)
            {
                Message = msg;
            }
        }//GPSException

        //ref https://msdn.microsoft.com/en-us/library/system.windows.media.imaging.bitmapimage(v=vs.110).aspx
        //    https://stackoverflow.com/questions/32314799/uwp-image-uri-in-application-folder
        public async void CurrentWeather()
        {
            var currentPosition = await locationManager.GetPosition();
            RootObject myWeather = await OpenWeatherMapService.GetWeather(currentPosition.Coordinate.Point.Position.Latitude, currentPosition.Coordinate.Point.Position.Longitude);
            string icon = String.Format("ms-appx:///Assets/Weather/{0}.png", myWeather.weather[0].icon);
            //take away 273.15 from temp to convert to celsius from kelvin
            WeatherBlock.Text = myWeather.name + " - " + (myWeather.main.temp - 273.15) + " - " + myWeather.weather[0].description + " - " + myWeather.weather[0].icon;
            //WeatherImage.Source = new BitmapImage(new Uri(this.BaseUri, "ms-appx://UWP-Project-3/Assets/Weather/01n.png"));
            WeatherImage.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
        }//CurrentWeather
    }//Home
}//UWP

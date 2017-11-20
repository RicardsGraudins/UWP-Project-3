using System;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Diagnostics;
using static UWP_Project_3.OpenWeatherMap;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_Project_3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public String latitudecord { get; set; }
        public String longitudecord { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
        }//MainPage

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
                catch(GPSException)
                {
                    Debug.WriteLine("GPS not enabled.");
                    return null;
                }//catch
            }//GetPosition
        }//locationManager

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            //var position = await locationManager.GetPosition();
            var currentLocation = await locationManager.GetPosition();
            //latitudecord = "Latitude: " + position.Coordinate.Latitude.ToString("0.0000000000");
            //longitudecord = "Longitude: " + position.Coordinate.Longitude.ToString("0.0000000000");
            longitudecord = currentLocation.Coordinate.Point.Position.Longitude.ToString("0.00");
            latitudecord = currentLocation.Coordinate.Point.Position.Latitude.ToString("0.00");
            textBlock.Text = latitudecord;
            textBlock1.Text = longitudecord;
        }//button_Click

        public class GPSException : Exception
        {
            public String Message { get; set; }

            public GPSException(String msg)
            {
                Message = msg;
            }
        }//GPSException

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            var currentPosition = await locationManager.GetPosition();
            RootObject myWeather = await OpenWeatherMap.GetWeather(currentPosition.Coordinate.Point.Position.Latitude, currentPosition.Coordinate.Point.Position.Longitude);
            //RootObject myWeather = await OpenWeatherMap.GetWeather(32.77, -97.79);
            //take away 273 from temp to convert to celsius from kelvin
            textBlock2.Text = myWeather.name + " - " + (myWeather.main.temp - 273) + " - " + myWeather.weather[0].description;
            //ref https://msdn.microsoft.com/en-us/library/system.windows.media.imaging.bitmapimage(v=vs.110).aspx
            string icon = String.Format("ms-appx:///Assets/Weather/{0}.png", myWeather.weather[0].icon);
            WeatherImage.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
        }
    }//main
}//UWP_Project_3
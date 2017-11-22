using System;
using UWP_Project_3.Model;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using static UWP_Project_3.Data.OpenWeatherMap;
using static UWP_Project_3.Data.WorldTidesExtremes;

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
                CurrentTidesExtreme();
            }
            else
            {
                CurrentWeather();
                CurrentTidesExtreme();
            }
            base.OnNavigatedTo(e);
        }//OnNavigatedTo

        //ref https://msdn.microsoft.com/en-us/library/system.windows.media.imaging.bitmapimage(v=vs.110).aspx
        //    https://stackoverflow.com/questions/32314799/uwp-image-uri-in-application-folder
        public async void CurrentWeather()
        {
            var currentPosition = await GeoLocationService.GetPosition();
            RootObject myWeather = await OpenWeatherMapService.GetWeather(currentPosition.Coordinate.Point.Position.Latitude, currentPosition.Coordinate.Point.Position.Longitude);
            string icon = String.Format("ms-appx:///Assets/Weather/{0}.png", myWeather.weather[0].icon);
            //take away 273.15 from temp to convert to celsius from kelvin
            WeatherBlock.Text = myWeather.name + " - " + (myWeather.main.temp - 273.15) + " - " + myWeather.weather[0].description + " - " + myWeather.weather[0].icon;
            //WeatherImage.Source = new BitmapImage(new Uri(this.BaseUri, "ms-appx://UWP-Project-3/Assets/Weather/01n.png"));
            WeatherImage.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
        }//CurrentWeather

        public async void CurrentTidesExtreme()
        {
            var currentPosition = await GeoLocationService.GetPosition();
            RootObjectExtreme myTides = await Model.WorldTidesExtremeService.GetMaxMinTides(currentPosition.Coordinate.Point.Position.Latitude, currentPosition.Coordinate.Point.Position.Longitude);
            TidesBlock.Text = string.Format("{0}, {1}, {2}", myTides.extremes[0].height, myTides.extremes[0].type, myTides.extremes[0].dt);
        }//CurrentTidesExtreme
    }//Home
}//UWP
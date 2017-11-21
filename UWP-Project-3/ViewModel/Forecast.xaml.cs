using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using static UWP_Project_3.Data.OpenWeatherMapForecast;
using UWP_Project_3.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP_Project_3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Forecast : Page
    {
        public Forecast()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
            {
                Status.Text = "Clicked Refresh!"; //loading animation here
                ForecastWeather();
            }
            else
            {
                Status.Text = "Navigated to Forecast";
                ForecastWeather();
            }
            base.OnNavigatedTo(e);
        }//OnNavigatedTo

        public async void ForecastWeather()
        {
            var currentPosition = await GeoLocationService.GetPosition();
            RootObject myForecast = await Model.OpenWeatherMapForecastService.GetForecast(currentPosition.Coordinate.Point.Position.Latitude, currentPosition.Coordinate.Point.Position.Longitude);
            ForecastBlock.Text = string.Format("{0}", myForecast.list[0].dt);
            ForecastBlock1.Text = string.Format("{0}", myForecast.list[0].weather[0].main);
            ForecastBlock2.Text = string.Format("{0}", myForecast.list[0].weather[0].description);
            ForecastBlock3.Text = string.Format("{0}", myForecast.list[0].main.temp);
            ForecastBlock4.Text = string.Format("{0}", myForecast.list[0].wind.speed);
            //graph
        }//ForecastWeather
    }//Forecast
}//UWP

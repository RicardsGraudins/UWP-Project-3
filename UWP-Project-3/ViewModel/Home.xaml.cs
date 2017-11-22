using System;
using System.Linq;
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
        //    https://stackoverflow.com/questions/16010804/getting-only-time-of-a-datetime-object
        public async void CurrentWeather()
        {
            var currentPosition = await GeoLocationService.GetPosition();
            RootObject myWeather = await OpenWeatherMapService.GetWeather(currentPosition.Coordinate.Point.Position.Latitude, currentPosition.Coordinate.Point.Position.Longitude);

            //Display weather image
            string icon = String.Format("ms-appx:///Assets/Weather/{0}.png", myWeather.weather[0].icon);
            WeatherImage.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));

            //Display location
            LocationBlock.Text = myWeather.name;

            //Display weather description
            DescriptionBlock.Text = FirstCharToUpper(myWeather.weather[0].description);

            //Display temperature
            TemperatureBlock.Text = string.Format("{0}", myWeather.main.temp);

            //Display wind speed
            WindBlock.Text = string.Format("{0} m/s", myWeather.wind.speed);

            //Display time of sunrise and sunset
            var srTime = getDate(myWeather.sys.sunrise);
            var ssTime = getDate(myWeather.sys.sunset);
            var sunRise = srTime.ToString("H:mm");
            var sunSet = ssTime.ToString("H:mm");
            SunRiseBlock.Text = string.Format("{0}", sunRise);
            SunSetBlock.Text = string.Format("{0}", sunSet);
        }//CurrentWeather

        public async void CurrentTidesExtreme()
        {
            var currentPosition = await GeoLocationService.GetPosition();
            RootObjectExtreme myTides = await Model.WorldTidesExtremeService.GetMaxMinTides(currentPosition.Coordinate.Point.Position.Latitude, currentPosition.Coordinate.Point.Position.Longitude);

            //WorldTides JSON provides 7 high/low tides - only going to use 4 on this page, ideally 2 high & 2 low for the same day
            //Set variables for the time of high/low tides
            var tideTime = "";
            var tide = getDate(myTides.extremes[0].dt);
            var tide1 = getDate(myTides.extremes[1].dt);
            var tide2 = getDate(myTides.extremes[2].dt);
            var tide3 = getDate(myTides.extremes[3].dt);

            //Display tide type - high/low
            TideTypeBlock.Text = myTides.extremes[0].type;
            TideTypeBlock1.Text = myTides.extremes[1].type;
            TideTypeBlock2.Text = myTides.extremes[2].type;
            TideTypeBlock3.Text = myTides.extremes[3].type;

            //Display the time of high/low tides
            tideTime = tide.ToString("dddd H:mm");
            TideTimeBlock.Text = tideTime;
            tideTime = tide1.ToString("dddd H:mm");
            TideTimeBlock1.Text = tideTime;
            tideTime = tide2.ToString("dddd H:mm");
            TideTimeBlock2.Text = tideTime;
            tideTime = tide3.ToString("dddd H:mm");
            TideTimeBlock3.Text = tideTime;

            //display the station that retrieved worldtides data
            //api currently not retrieving station
            WorldTidesStation.Text = string.Format("WorldTides Station: {0}", myTides.station);
        }//CurrentTidesExtreme

        DateTime getDate(double millisecond)
        {
            DateTime day = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(millisecond).ToLocalTime();

            return day;
        }//getDate

        //ref https://stackoverflow.com/questions/4135317/make-first-letter-of-a-string-upper-case-with-maximum-performance
        public static string FirstCharToUpper(string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }//FirstCharToUpper
    }//Home
}//UWP
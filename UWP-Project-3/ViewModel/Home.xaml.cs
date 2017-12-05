using System;
using UWP_Project_3.Model;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using static UWP_Project_3.Data.OpenWeatherMap;
using static UWP_Project_3.Data.WorldTidesExtremes;
using static UWP_Project_3.Model.SharedMethods;

namespace UWP_Project_3
{
    public sealed partial class Home : Page
    {
        SharedMethods myMethods = new SharedMethods();
        public Home()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
            {
                //Loading animaton
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

        //Ref https://msdn.microsoft.com/en-us/library/system.windows.media.imaging.bitmapimage(v=vs.110).aspx
        //    https://stackoverflow.com/questions/32314799/uwp-image-uri-in-application-folder
        public async void CurrentWeather()
        {
            try
            {
                var currentPosition = await GeoLocationService.GetPosition();
                RootObject myWeather = await OpenWeatherMapService.GetWeather(currentPosition.Coordinate.Point.Position.Latitude, currentPosition.Coordinate.Point.Position.Longitude);

                //Set labels
                Label0.Text = "Location";
                Label1.Text = "Description";
                Label2.Text = "Temperature";
                Label3.Text = "Wind Speed";
                Label4.Text = "Sun Rise";
                Label5.Text = "Sun Set";

                //Display weather image
                string icon = String.Format("ms-appx:///Assets/Weather/{0}.png", myWeather.weather[0].icon);
                WeatherImage.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));

                //Display location
                LocationBlock.Text = myWeather.name;

                //Display weather description
                DescriptionBlock.Text = FirstCharToUpper(myWeather.weather[0].description);

                //Display temperature
                TemperatureBlock.Text = string.Format("{0}°C", myWeather.main.temp);

                //Display wind speed
                WindBlock.Text = string.Format("{0} m/s", myWeather.wind.speed);

                //Display time of sunrise and sunset
                var srTime = myMethods.getDate(myWeather.sys.sunrise);
                var ssTime = myMethods.getDate(myWeather.sys.sunset);
                var sunRise = srTime.ToString("H:mm");
                var sunSet = ssTime.ToString("H:mm");
                SunRiseBlock.Text = string.Format("{0}", sunRise);
                SunSetBlock.Text = string.Format("{0}", sunSet);
            }
            catch
            {
                WorldTidesStation.Text = "Error retrieving data";
                myMethods.EnableGPSDialog();
            }
        }//CurrentWeather

        public async void CurrentTidesExtreme()
        {
            try
            {
                var currentPosition = await GeoLocationService.GetPosition();
                RootObjectExtreme myTides = await Model.WorldTidesExtremeService.GetMaxMinTides(currentPosition.Coordinate.Point.Position.Latitude, currentPosition.Coordinate.Point.Position.Longitude);

                //WorldTides JSON provides 7 high/low tides - only going to use 4 on this page, ideally 2 high & 2 low for the same day
                //Set variables for the time of high/low tides
                var tideTime = "";
                var tide = myMethods.getDate(myTides.extremes[0].dt);
                var tide1 = myMethods.getDate(myTides.extremes[1].dt);
                var tide2 = myMethods.getDate(myTides.extremes[2].dt);
                var tide3 = myMethods.getDate(myTides.extremes[3].dt);

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

                //Display the station that retrieved worldtides data
                WorldTidesStation.Text = string.Format("WorldTides Station: {0}", myTides.station);
            }//Try
            catch
            {
                //Popup already displayed by currentWeather
            }//Catch
        }//CurrentTidesExtreme
    }//Home
}//UWP
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System;
using UWP_Project_3.Model;
using Windows.UI.Xaml.Media.Imaging;
using static UWP_Project_3.Data.OpenWeatherMapForecast;
using static UWP_Project_3.Model.SharedMethods;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP_Project_3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Forecast : Page
    {
        SharedMethods myMethods = new SharedMethods();
        public Forecast()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
            {
                //Status.Text = "Clicked Refresh!"; //loading animation here
                ForecastWeather();
            }
            else
            {
                //Status.Text = "Navigated to Forecast";
                ForecastWeather();
            }
            base.OnNavigatedTo(e);
        }//OnNavigatedTo

        public async void ForecastWeather()
        {
            var currentPosition = await GeoLocationService.GetPosition();
            RootObject myForecast = await Model.OpenWeatherMapForecastService.GetForecast(currentPosition.Coordinate.Point.Position.Latitude, currentPosition.Coordinate.Point.Position.Longitude);
            /*
            ForecastBlock.Text = string.Format("{0}", myForecast.list[0].dt);
            ForecastBlock1.Text = string.Format("{0}", myForecast.list[0].weather[0].main);
            ForecastBlock2.Text = string.Format("{0}", myForecast.list[0].weather[0].description);
            ForecastBlock3.Text = string.Format("{0}", myForecast.list[0].main.temp);
            ForecastBlock4.Text = string.Format("{0}", myForecast.list[0].wind.speed);
            //graph
            */

            //Setting & displaying date
            var date0 = myMethods.getDate(myForecast.list[0].dt);
            var date0String = date0.ToString("ddd dd MMM");
            Date0.Text = date0String;
            var date1 = myMethods.getDate(myForecast.list[1].dt);
            var date1String = date1.ToString("ddd dd MMM");
            Date1.Text = date1String;
            var date2 = myMethods.getDate(myForecast.list[2].dt);
            var date2String = date2.ToString("ddd dd MMM");
            Date2.Text = date2String;
            var date3 = myMethods.getDate(myForecast.list[3].dt);
            var date3String = date3.ToString("ddd dd MMM");
            Date3.Text = date3String;
            var date4 = myMethods.getDate(myForecast.list[4].dt);
            var date4String = date4.ToString("ddd dd MMM");
            Date4.Text = date4String;
            var date5 = myMethods.getDate(myForecast.list[5].dt);
            var date5String = date5.ToString("ddd dd MMM");
            Date5.Text = date5String;
            var date6 = myMethods.getDate(myForecast.list[6].dt);
            var date6String = date6.ToString("ddd dd MMM");
            Date6.Text = date6String;
            var date7 = myMethods.getDate(myForecast.list[7].dt);
            var date7String = date7.ToString("ddd dd MMM");
            Date7.Text = date7String;
            var date8 = myMethods.getDate(myForecast.list[8].dt);
            var date8String = date8.ToString("ddd dd MMM");
            Date8.Text = date8String;
            var date9 = myMethods.getDate(myForecast.list[9].dt);
            var date9String = date9.ToString("ddd dd MMM");
            Date9.Text = date9String;
            var date10 = myMethods.getDate(myForecast.list[10].dt);
            var date10String = date10.ToString("ddd dd MMM");
            Date10.Text = date10String;
            var date11 = myMethods.getDate(myForecast.list[11].dt);
            var date11String = date11.ToString("ddd dd MMM");
            Date11.Text = date11String;
            var date12 = myMethods.getDate(myForecast.list[12].dt);
            var date12String = date12.ToString("ddd dd MMM");
            Date12.Text = date12String;
            var date13 = myMethods.getDate(myForecast.list[13].dt);
            var date13String = date13.ToString("ddd dd MMM");
            Date13.Text = date13String;
            var date14 = myMethods.getDate(myForecast.list[14].dt);
            var date14String = date14.ToString("ddd dd MMM");
            Date14.Text = date14String;
            var date15 = myMethods.getDate(myForecast.list[15].dt);
            var date15String = date15.ToString("ddd dd MMM");
            Date15.Text = date15String;

            //Setting images variables
            string icon0 = String.Format("ms-appx:///Assets/Weather/{0}.png", myForecast.list[0].weather[0].icon);
            string icon1 = String.Format("ms-appx:///Assets/Weather/{0}.png", myForecast.list[1].weather[0].icon);
            string icon2 = String.Format("ms-appx:///Assets/Weather/{0}.png", myForecast.list[2].weather[0].icon);
            string icon3 = String.Format("ms-appx:///Assets/Weather/{0}.png", myForecast.list[3].weather[0].icon);
            string icon4 = String.Format("ms-appx:///Assets/Weather/{0}.png", myForecast.list[4].weather[0].icon);
            string icon5 = String.Format("ms-appx:///Assets/Weather/{0}.png", myForecast.list[5].weather[0].icon);
            string icon6 = String.Format("ms-appx:///Assets/Weather/{0}.png", myForecast.list[6].weather[0].icon);
            string icon7 = String.Format("ms-appx:///Assets/Weather/{0}.png", myForecast.list[7].weather[0].icon);
            string icon8 = String.Format("ms-appx:///Assets/Weather/{0}.png", myForecast.list[8].weather[0].icon);
            string icon9 = String.Format("ms-appx:///Assets/Weather/{0}.png", myForecast.list[9].weather[0].icon);
            string icon10 = String.Format("ms-appx:///Assets/Weather/{0}.png", myForecast.list[10].weather[0].icon);
            string icon11 = String.Format("ms-appx:///Assets/Weather/{0}.png", myForecast.list[11].weather[0].icon);
            string icon12 = String.Format("ms-appx:///Assets/Weather/{0}.png", myForecast.list[12].weather[0].icon);
            string icon13 = String.Format("ms-appx:///Assets/Weather/{0}.png", myForecast.list[13].weather[0].icon);
            string icon14 = String.Format("ms-appx:///Assets/Weather/{0}.png", myForecast.list[14].weather[0].icon);
            string icon15 = String.Format("ms-appx:///Assets/Weather/{0}.png", myForecast.list[15].weather[0].icon);

            //Displaying Images
            WeatherImage0.Source = new BitmapImage(new Uri(icon0, UriKind.Absolute));
            WeatherImage1.Source = new BitmapImage(new Uri(icon1, UriKind.Absolute));
            WeatherImage2.Source = new BitmapImage(new Uri(icon2, UriKind.Absolute));
            WeatherImage3.Source = new BitmapImage(new Uri(icon3, UriKind.Absolute));
            WeatherImage4.Source = new BitmapImage(new Uri(icon4, UriKind.Absolute));
            WeatherImage5.Source = new BitmapImage(new Uri(icon5, UriKind.Absolute));
            WeatherImage6.Source = new BitmapImage(new Uri(icon6, UriKind.Absolute));
            WeatherImage7.Source = new BitmapImage(new Uri(icon7, UriKind.Absolute));
            WeatherImage8.Source = new BitmapImage(new Uri(icon8, UriKind.Absolute));
            WeatherImage9.Source = new BitmapImage(new Uri(icon9, UriKind.Absolute));
            WeatherImage10.Source = new BitmapImage(new Uri(icon10, UriKind.Absolute));
            WeatherImage11.Source = new BitmapImage(new Uri(icon11, UriKind.Absolute));
            WeatherImage12.Source = new BitmapImage(new Uri(icon12, UriKind.Absolute));
            WeatherImage13.Source = new BitmapImage(new Uri(icon13, UriKind.Absolute));
            WeatherImage14.Source = new BitmapImage(new Uri(icon14, UriKind.Absolute));
            WeatherImage15.Source = new BitmapImage(new Uri(icon15, UriKind.Absolute));

            //Displaying max temp
            MaxTemp0.Text = string.Format("{0}°C", myForecast.list[0].main.temp_max);
            MaxTemp1.Text = string.Format("{0}°C", myForecast.list[1].main.temp_max);
            MaxTemp2.Text = string.Format("{0}°C", myForecast.list[2].main.temp_max);
            MaxTemp3.Text = string.Format("{0}°C", myForecast.list[3].main.temp_max);
            MaxTemp4.Text = string.Format("{0}°C", myForecast.list[4].main.temp_max);
            MaxTemp5.Text = string.Format("{0}°C", myForecast.list[5].main.temp_max);
            MaxTemp6.Text = string.Format("{0}°C", myForecast.list[6].main.temp_max);
            MaxTemp7.Text = string.Format("{0}°C", myForecast.list[7].main.temp_max);
            MaxTemp8.Text = string.Format("{0}°C", myForecast.list[8].main.temp_max);
            MaxTemp9.Text = string.Format("{0}°C", myForecast.list[9].main.temp_max);
            MaxTemp10.Text = string.Format("{0}°C", myForecast.list[10].main.temp_max);
            MaxTemp11.Text = string.Format("{0}°C", myForecast.list[11].main.temp_max);
            MaxTemp12.Text = string.Format("{0}°C", myForecast.list[12].main.temp_max);
            MaxTemp13.Text = string.Format("{0}°C", myForecast.list[13].main.temp_max);
            MaxTemp14.Text = string.Format("{0}°C", myForecast.list[14].main.temp_max);
            MaxTemp15.Text = string.Format("{0}°C", myForecast.list[15].main.temp_max);

            //Displaying min temp
            MinTemp0.Text = string.Format("{0}°C", myForecast.list[0].main.temp_min);
            MinTemp1.Text = string.Format("{0}°C", myForecast.list[1].main.temp_min);
            MinTemp2.Text = string.Format("{0}°C", myForecast.list[2].main.temp_min);
            MinTemp3.Text = string.Format("{0}°C", myForecast.list[3].main.temp_min);
            MinTemp4.Text = string.Format("{0}°C", myForecast.list[4].main.temp_min);
            MinTemp5.Text = string.Format("{0}°C", myForecast.list[5].main.temp_min);
            MinTemp6.Text = string.Format("{0}°C", myForecast.list[6].main.temp_min);
            MinTemp7.Text = string.Format("{0}°C", myForecast.list[7].main.temp_min);
            MinTemp8.Text = string.Format("{0}°C", myForecast.list[8].main.temp_min);
            MinTemp9.Text = string.Format("{0}°C", myForecast.list[9].main.temp_min);
            MinTemp10.Text = string.Format("{0}°C", myForecast.list[10].main.temp_min);
            MinTemp11.Text = string.Format("{0}°C", myForecast.list[11].main.temp_min);
            MinTemp12.Text = string.Format("{0}°C", myForecast.list[12].main.temp_min);
            MinTemp13.Text = string.Format("{0}°C", myForecast.list[13].main.temp_min);
            MinTemp14.Text = string.Format("{0}°C", myForecast.list[14].main.temp_min);
            MinTemp15.Text = string.Format("{0}°C", myForecast.list[15].main.temp_min);

            //Displaying weather description
            Desc0.Text = FirstCharToUpper(myForecast.list[0].weather[0].description);
            Desc1.Text = FirstCharToUpper(myForecast.list[1].weather[0].description);
            Desc2.Text = FirstCharToUpper(myForecast.list[2].weather[0].description);
            Desc3.Text = FirstCharToUpper(myForecast.list[3].weather[0].description);
            Desc4.Text = FirstCharToUpper(myForecast.list[4].weather[0].description);
            Desc5.Text = FirstCharToUpper(myForecast.list[5].weather[0].description);
            Desc6.Text = FirstCharToUpper(myForecast.list[6].weather[0].description);
            Desc7.Text = FirstCharToUpper(myForecast.list[7].weather[0].description);
            Desc8.Text = FirstCharToUpper(myForecast.list[8].weather[0].description);
            Desc9.Text = FirstCharToUpper(myForecast.list[9].weather[0].description);
            Desc10.Text = FirstCharToUpper(myForecast.list[10].weather[0].description);
            Desc11.Text = FirstCharToUpper(myForecast.list[11].weather[0].description);
            Desc12.Text = FirstCharToUpper(myForecast.list[12].weather[0].description);
            Desc13.Text = FirstCharToUpper(myForecast.list[13].weather[0].description);
            Desc14.Text = FirstCharToUpper(myForecast.list[14].weather[0].description);
            Desc15.Text = FirstCharToUpper(myForecast.list[15].weather[0].description);

            //Displaying wind speed
            Speed0.Text = string.Format("{0} m/s", myForecast.list[0].wind.speed);
            Speed1.Text = string.Format("{0} m/s", myForecast.list[1].wind.speed);
            Speed2.Text = string.Format("{0} m/s", myForecast.list[2].wind.speed);
            Speed3.Text = string.Format("{0} m/s", myForecast.list[3].wind.speed);
            Speed4.Text = string.Format("{0} m/s", myForecast.list[4].wind.speed);
            Speed5.Text = string.Format("{0} m/s", myForecast.list[5].wind.speed);
            Speed6.Text = string.Format("{0} m/s", myForecast.list[6].wind.speed);
            Speed7.Text = string.Format("{0} m/s", myForecast.list[7].wind.speed);
            Speed8.Text = string.Format("{0} m/s", myForecast.list[8].wind.speed);
            Speed9.Text = string.Format("{0} m/s", myForecast.list[9].wind.speed);
            Speed10.Text = string.Format("{0} m/s", myForecast.list[10].wind.speed);
            Speed11.Text = string.Format("{0} m/s", myForecast.list[11].wind.speed);
            Speed12.Text = string.Format("{0} m/s", myForecast.list[12].wind.speed);
            Speed13.Text = string.Format("{0} m/s", myForecast.list[13].wind.speed);
            Speed14.Text = string.Format("{0} m/s", myForecast.list[14].wind.speed);
            Speed15.Text = string.Format("{0} m/s", myForecast.list[15].wind.speed);

            //Displaying cloud cover %
            Cloud0.Text = string.Format("{0} %", myForecast.list[0].clouds.all);
            Cloud1.Text = string.Format("{0} %", myForecast.list[1].clouds.all);
            Cloud2.Text = string.Format("{0} %", myForecast.list[2].clouds.all);
            Cloud3.Text = string.Format("{0} %", myForecast.list[3].clouds.all);
            Cloud4.Text = string.Format("{0} %", myForecast.list[4].clouds.all);
            Cloud5.Text = string.Format("{0} %", myForecast.list[5].clouds.all);
            Cloud6.Text = string.Format("{0} %", myForecast.list[6].clouds.all);
            Cloud7.Text = string.Format("{0} %", myForecast.list[7].clouds.all);
            Cloud8.Text = string.Format("{0} %", myForecast.list[8].clouds.all);
            Cloud9.Text = string.Format("{0} %", myForecast.list[9].clouds.all);
            Cloud10.Text = string.Format("{0} %", myForecast.list[10].clouds.all);
            Cloud11.Text = string.Format("{0} %", myForecast.list[11].clouds.all);
            Cloud12.Text = string.Format("{0} %", myForecast.list[12].clouds.all);
            Cloud13.Text = string.Format("{0} %", myForecast.list[13].clouds.all);
            Cloud14.Text = string.Format("{0} %", myForecast.list[14].clouds.all);
            Cloud15.Text = string.Format("{0} %", myForecast.list[15].clouds.all);

            //Displaying pressure
            HPA0.Text = string.Format("{0} hPA", myForecast.list[0].main.pressure);
            HPA1.Text = string.Format("{0} hPA", myForecast.list[1].main.pressure);
            HPA2.Text = string.Format("{0} hPA", myForecast.list[2].main.pressure);
            HPA3.Text = string.Format("{0} hPA", myForecast.list[3].main.pressure);
            HPA4.Text = string.Format("{0} hPA", myForecast.list[4].main.pressure);
            HPA5.Text = string.Format("{0} hPA", myForecast.list[5].main.pressure);
            HPA6.Text = string.Format("{0} hPA", myForecast.list[6].main.pressure);
            HPA7.Text = string.Format("{0} hPA", myForecast.list[7].main.pressure);
            HPA8.Text = string.Format("{0} hPA", myForecast.list[8].main.pressure);
            HPA9.Text = string.Format("{0} hPA", myForecast.list[9].main.pressure);
            HPA10.Text = string.Format("{0} hPA", myForecast.list[10].main.pressure);
            HPA11.Text = string.Format("{0} hPA", myForecast.list[11].main.pressure);
            HPA12.Text = string.Format("{0} hPA", myForecast.list[12].main.pressure);
            HPA13.Text = string.Format("{0} hPA", myForecast.list[13].main.pressure);
            HPA14.Text = string.Format("{0} hPA", myForecast.list[14].main.pressure);
            HPA15.Text = string.Format("{0} hPA", myForecast.list[15].main.pressure);
        }//ForecastWeather
    }//Forecast
}//UWP
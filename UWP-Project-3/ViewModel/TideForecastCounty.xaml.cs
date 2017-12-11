using System;
using UWP_Project_3.Model;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using static UWP_Project_3.Data.WorldTidesExtremes;

namespace UWP_Project_3.ViewModel
{
    public sealed partial class TideForecastCounty : Page
    {
        SharedMethods myMethods = new SharedMethods();
        public TideForecastCounty()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
            {
                //OnNavigatedTo with parameter display the forecast
                string county = e.Parameter.ToString();
                //string county2 = "";
                double lat = 0;
                double lon = 0;

                Date0.Text = county;

                //Lat & lon cords taken from google
                switch (county)
                {
                    case "Carlow":
                        lat = 52.83;
                        lon = -6.93;
                        ForecastTides(lat, lon);
                        break;

                    case "Cavan":
                        lat = 53.97;
                        lon = -7.29;
                        ForecastTides(lat, lon);
                        break;

                    case "Clare":
                        lat = 52.90;
                        lon = -8.98;
                        ForecastTides(lat, lon);
                        break;

                    case "Cork":
                        lat = 51.89;
                        lon = -8.48;
                        ForecastTides(lat, lon);
                        break;

                    case "Donegal":
                        lat = 54.65;
                        lon = -8.10;
                        ForecastTides(lat, lon);
                        break;

                    case "Dublin":
                        lat = 53.34;
                        lon = -6.26;
                        ForecastTides(lat, lon);
                        break;

                    case "Galway":
                        lat = 53.27;
                        lon = -9.06;
                        ForecastTides(lat, lon);
                        break;

                    case "Kerry":
                        lat = 52.15;
                        lon = -9.56;
                        ForecastTides(lat, lon);
                        break;

                    case "Kildare":
                        lat = 53.15;
                        lon = -6.60;
                        ForecastTides(lat, lon);
                        break;

                    case "Kilkenny":
                        lat = 52.65;
                        lon = -7.24;
                        ForecastTides(lat, lon);
                        break;

                    case "Laois":
                        lat = 52.99;
                        lon = -7.33;
                        ForecastTides(lat, lon);
                        break;

                    case "Carrick-on-Shannon":
                        lat = 53.94;
                        lon = -8.08;
                        ForecastTides(lat, lon);
                        break;

                    case "Limerick":
                        lat = 52.66;
                        lon = -8.63;
                        ForecastTides(lat, lon);
                        break;

                    case "Longford":
                        lat = 53.72;
                        lon = -7.79;
                        ForecastTides(lat, lon);
                        break;

                    case "Louth":
                        lat = 53.92;
                        lon = -6.48;
                        ForecastTides(lat, lon);
                        break;

                    case "Mayo":
                        lat = 54.01;
                        lon = -9.42;
                        ForecastTides(lat, lon);
                        break;

                    case "Meath":
                        lat = 53.60;
                        lon = -6.65;
                        ForecastTides(lat, lon);
                        break;

                    case "Monaghan":
                        lat = 54.24;
                        lon = -6.96;
                        ForecastTides(lat, lon);
                        break;

                    case "Offaly":
                        lat = 53.09;
                        lon = -7.90;
                        ForecastTides(lat, lon);
                        break;

                    case "Roscommon":
                        lat = 53.75;
                        lon = -8.26;
                        ForecastTides(lat, lon);
                        break;

                    case "Sligo":
                        lat = 54.27;
                        lon = -8.47;
                        ForecastTides(lat, lon);
                        break;

                    case "Tipperary":
                        lat = 52.47;
                        lon = -8.16;
                        ForecastTides(lat, lon);
                        break;

                    case "Waterford":
                        lat = 52.25;
                        lon = -7.11;
                        ForecastTides(lat, lon);
                        break;

                    case "Westmeath":
                        lat = 53.53;
                        lon = -7.46;
                        ForecastTides(lat, lon);
                        break;

                    case "Wexford":
                        lat = 52.33;
                        lon = -6.46;
                        ForecastTides(lat, lon);
                        break;

                    case "Wicklow":
                        lat = 52.98;
                        lon = -6.36;
                        ForecastTides(lat, lon);
                        break;

                    default:
                        break;
                }//Switch
                /* Weather Fisher API
                switch (county)
                {
                    case "Carlow":
                        county2 = "Carlow";
                        ForecastTidesWeatherFisher(county2);
                        break;

                    case "Cavan":
                        county2 = "Cavan";
                        ForecastTidesWeatherFisher(county2);
                        break;

                    case "Clare":
                        county2 = "Clare";
                        ForecastTidesWeatherFisher(county2);
                        break;

                    case "Cork":
                        county2 = "Cork";
                        ForecastTidesWeatherFisher(county2);
                        break;

                    case "Donegal":
                        county2 = "Donegal";
                        ForecastTidesWeatherFisher(county2);
                        break;

                    case "Dublin":
                        county2 = "Dublin";
                        ForecastTidesWeatherFisher(county2);
                        break;

                    case "Galway":
                        county2 = "Galway";
                        ForecastTidesWeatherFisher(county2);
                        break;

                    case "Kerry":
                        county2 = "Kerry";
                        ForecastTidesWeatherFisher(county2);
                        break;

                    case "Kildare":
                        county2 = "Kildare";
                        ForecastTidesWeatherFisher(county2);
                        break;

                    case "Kilkenny":
                        county2 = "Kilkenny";
                        ForecastTidesWeatherFisher(county2);
                        break;

                    case "Laois":
                        county2 = "Laois";
                        ForecastTidesWeatherFisher(county2);
                        break;

                    case "Carrick-on-Shannon":
                        county2 = "Leitrim";
                        ForecastTidesWeatherFisher(county2);
                        break;

                    case "Limerick":
                        county2 = "Limerick";
                        ForecastTidesWeatherFisher(county2);
                        break;

                    case "Longford":
                        county2 = "Longford";
                        ForecastTidesWeatherFisher(county2);
                        break;

                    case "Louth":
                        county2 = "Louth";
                        ForecastTidesWeatherFisher(county2);
                        break;

                    case "Mayo":
                        county2 = "Mayo";
                        ForecastTidesWeatherFisher(county2);
                        break;

                    case "Meath":
                        county2 = "Meath";
                        ForecastTidesWeatherFisher(county2);
                        break;

                    case "Monaghan":
                        county2 = "Monaghan";
                        ForecastTidesWeatherFisher(county2);
                        break;

                    case "Offaly":
                        county2 = "Offaly";
                        ForecastTidesWeatherFisher(county2);
                        break;

                    case "Roscommon":
                        county2 = "Roscommon";
                        ForecastTidesWeatherFisher(county2);
                        break;

                    case "Sligo":
                        county2 = "Sligo";
                        ForecastTidesWeatherFisher(county2);
                        break;

                    case "Tipperary":
                        county2 = "Tipperary";
                        ForecastTidesWeatherFisher(county2);
                        break;

                    case "Waterford":
                        county2 = "Waterford";
                        ForecastTidesWeatherFisher(county2);
                        break;

                    case "Westmeath":
                        county2 = "Westmeath";
                        ForecastTidesWeatherFisher(county2);
                        break;

                    case "Wexford":
                        county2 = "Wexford";
                        ForecastTidesWeatherFisher(county2);
                        break;

                    case "Wicklow":
                        county2 = "Wicklow";
                        ForecastTidesWeatherFisher(county2);
                        break;

                    default:
                        break;
                }//Switch
                */
            }
            else
            {
                //Do nothing
            }
            base.OnNavigatedTo(e);
        }//OnNavigatedTo

        public async void ForecastTides(double lat, double lon)
        {
            try
            {
                RootObjectExtreme myTides = await Model.WorldTidesExtremeService.GetMaxMinTides(lat, lon);

                var tideTime = "";
                var tide = myMethods.getDate(myTides.extremes[0].dt);
                var tide1 = myMethods.getDate(myTides.extremes[1].dt);
                var tide2 = myMethods.getDate(myTides.extremes[2].dt);
                var tide3 = myMethods.getDate(myTides.extremes[3].dt);
                var tide4 = myMethods.getDate(myTides.extremes[4].dt);
                var tide5 = myMethods.getDate(myTides.extremes[5].dt);
                var tide6 = myMethods.getDate(myTides.extremes[6].dt);

                //Display tide date
                tideTime = tide.ToString("ddd dd MMM");
                Date0.Text = tideTime;
                tideTime = tide1.ToString("ddd dd MMM");
                Date1.Text = tideTime;
                tideTime = tide2.ToString("ddd dd MMM");
                Date2.Text = tideTime;
                tideTime = tide3.ToString("ddd dd MMM");
                Date3.Text = tideTime;
                tideTime = tide4.ToString("ddd dd MMM");
                Date4.Text = tideTime;
                tideTime = tide5.ToString("ddd dd MMM");
                Date5.Text = tideTime;
                tideTime = tide6.ToString("ddd dd MMM");
                Date6.Text = tideTime;

                //Display the time of high/low tides
                tideTime = tide.ToString("t");
                Time0.Text = tideTime;
                tideTime = tide1.ToString("t");
                Time1.Text = tideTime;
                tideTime = tide2.ToString("t");
                Time2.Text = tideTime;
                tideTime = tide3.ToString("t");
                Time3.Text = tideTime;
                tideTime = tide4.ToString("t");
                Time4.Text = tideTime;
                tideTime = tide5.ToString("t");
                Time5.Text = tideTime;
                tideTime = tide6.ToString("t");
                Time6.Text = tideTime;

                //Display tide type
                Tide0.Text = myTides.extremes[0].type;
                Tide1.Text = myTides.extremes[1].type;
                Tide2.Text = myTides.extremes[2].type;
                Tide3.Text = myTides.extremes[3].type;
                Tide4.Text = myTides.extremes[4].type;
                Tide5.Text = myTides.extremes[5].type;
                Tide6.Text = myTides.extremes[6].type;

                //Display tide height
                Height0.Text = String.Format("{0} m", myTides.extremes[0].height);
                Height1.Text = String.Format("{0} m", myTides.extremes[1].height);
                Height2.Text = String.Format("{0} m", myTides.extremes[2].height);
                Height3.Text = String.Format("{0} m", myTides.extremes[3].height);
                Height4.Text = String.Format("{0} m", myTides.extremes[4].height);
                Height5.Text = String.Format("{0} m", myTides.extremes[5].height);
                Height6.Text = String.Format("{0} m", myTides.extremes[6].height);

                WorldTidesStation.Text = "WorldTides Station: Undefined";

                if (myTides.station != null)
                {
                    WorldTidesStation.Text = string.Format("WorldTides Station: {0}", myTides.station);
                }
            }//Try
            catch
            {
                myMethods.WorldTidesError();
            }//Catch
        }//ForecastTides

        public async void ForecastTidesWeatherFisher(string county)
        {
            try
            {
                RootObjectExtreme myTides = await Model.WorldTidesExtremeService.GetCounty(county);

                var tideTime = "";
                var tide = myMethods.getDate(myTides.extremes[0].dt);
                var tide1 = myMethods.getDate(myTides.extremes[1].dt);
                var tide2 = myMethods.getDate(myTides.extremes[2].dt);
                var tide3 = myMethods.getDate(myTides.extremes[3].dt);
                var tide4 = myMethods.getDate(myTides.extremes[4].dt);
                var tide5 = myMethods.getDate(myTides.extremes[5].dt);
                var tide6 = myMethods.getDate(myTides.extremes[6].dt);

                //Display tide date
                tideTime = tide.ToString("ddd dd MMM");
                Date0.Text = tideTime;
                tideTime = tide1.ToString("ddd dd MMM");
                Date1.Text = tideTime;
                tideTime = tide2.ToString("ddd dd MMM");
                Date2.Text = tideTime;
                tideTime = tide3.ToString("ddd dd MMM");
                Date3.Text = tideTime;
                tideTime = tide4.ToString("ddd dd MMM");
                Date4.Text = tideTime;
                tideTime = tide5.ToString("ddd dd MMM");
                Date5.Text = tideTime;
                tideTime = tide6.ToString("ddd dd MMM");
                Date6.Text = tideTime;

                //Display the time of high/low tides
                tideTime = tide.ToString("t");
                Time0.Text = tideTime;
                tideTime = tide1.ToString("t");
                Time1.Text = tideTime;
                tideTime = tide2.ToString("t");
                Time2.Text = tideTime;
                tideTime = tide3.ToString("t");
                Time3.Text = tideTime;
                tideTime = tide4.ToString("t");
                Time4.Text = tideTime;
                tideTime = tide5.ToString("t");
                Time5.Text = tideTime;
                tideTime = tide6.ToString("t");
                Time6.Text = tideTime;

                //Display tide type
                Tide0.Text = myTides.extremes[0].type;
                Tide1.Text = myTides.extremes[1].type;
                Tide2.Text = myTides.extremes[2].type;
                Tide3.Text = myTides.extremes[3].type;
                Tide4.Text = myTides.extremes[4].type;
                Tide5.Text = myTides.extremes[5].type;
                Tide6.Text = myTides.extremes[6].type;

                //Display tide height
                Height0.Text = String.Format("{0} m", myTides.extremes[0].height);
                Height1.Text = String.Format("{0} m", myTides.extremes[1].height);
                Height2.Text = String.Format("{0} m", myTides.extremes[2].height);
                Height3.Text = String.Format("{0} m", myTides.extremes[3].height);
                Height4.Text = String.Format("{0} m", myTides.extremes[4].height);
                Height5.Text = String.Format("{0} m", myTides.extremes[5].height);
                Height6.Text = String.Format("{0} m", myTides.extremes[6].height);

                WorldTidesStation.Text = "WorldTides Station: Undefined";

                if (myTides.station != null)
                {
                    WorldTidesStation.Text = string.Format("WorldTides Station: {0}", myTides.station);
                }
            }//Try
            catch
            {
                myMethods.WeatherFisherAPIError();
            }
        }//ForestTidesWeatherFisher
    }//TideForecastCounty
}//UWP
﻿using Windows.UI.Xaml.Controls;

namespace UWP_Project_3.ViewModel
{
    public sealed partial class Search : Page
    {
        public Search()
        {
            this.InitializeComponent();
        }

        //On selection changed - get city input and navigate to the page WeatherForecastCounty with the county input
        //API uses the Irish names for some counties
        //ref https://en.wikipedia.org/wiki/ISO_3166-2:IE
        private void cityInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string city;

            switch (cityInput.SelectedIndex)
            {
                case 0:
                    city = "Carlow";
                    this.Frame.Navigate(typeof(WeatherForecastCounty), city);
                    break;

                case 1:
                    city = "Cavan";
                    this.Frame.Navigate(typeof(WeatherForecastCounty), city);
                    break;

                case 2:
                    city = "An Clár";
                    this.Frame.Navigate(typeof(WeatherForecastCounty), city);
                    break;

                case 3:
                    city = "Cork";
                    this.Frame.Navigate(typeof(WeatherForecastCounty), city);
                    break;

                case 4:
                    city = "Donegal";
                    this.Frame.Navigate(typeof(WeatherForecastCounty), city);
                    break;

                case 5:
                    city = "Dublin";
                    this.Frame.Navigate(typeof(WeatherForecastCounty), city);
                    break;

                case 6:
                    city = "Gaillimh";
                    this.Frame.Navigate(typeof(WeatherForecastCounty), city);
                    break;

                case 7:
                    city = "Ciarraí";
                    this.Frame.Navigate(typeof(WeatherForecastCounty), city);
                    break;

                case 8:
                    city = "Kildare";
                    this.Frame.Navigate(typeof(WeatherForecastCounty), city);
                    break;

                case 9:
                    city = "Kilkenny";
                    this.Frame.Navigate(typeof(WeatherForecastCounty), city);
                    break;

                case 10:
                    city = "Laois";
                    this.Frame.Navigate(typeof(WeatherForecastCounty), city);
                    break;

                //API doesn't have entry for Leitrim / Liatroim / Liatroma
                //Therefore using largest city in Leitrim - Carrick-on-Shannon
                case 11:
                    city = "Carrick-on-Shannon";
                    this.Frame.Navigate(typeof(WeatherForecastCounty), city);
                    break;

                case 12:
                    city = "Luimneach";
                    this.Frame.Navigate(typeof(WeatherForecastCounty), city);
                    break;

                case 13:
                    city = "Longford";
                    this.Frame.Navigate(typeof(WeatherForecastCounty), city);
                    break;

                case 14:
                    city = "Louth";
                    this.Frame.Navigate(typeof(WeatherForecastCounty), city);
                    break;

                case 15:
                    city = "Maigh Eo";
                    this.Frame.Navigate(typeof(WeatherForecastCounty), city);
                    break;

                case 16:
                    city = "An Mhí";
                    this.Frame.Navigate(typeof(WeatherForecastCounty), city);
                    break;

                case 17:
                    city = "Monaghan";
                    this.Frame.Navigate(typeof(WeatherForecastCounty), city);
                    break;

                case 18:
                    city = "Uíbh Fhailí";
                    this.Frame.Navigate(typeof(WeatherForecastCounty), city);
                    break;

                case 19:
                    city = "Roscommon";
                    this.Frame.Navigate(typeof(WeatherForecastCounty), city);
                    break;

                case 20:
                    city = "Sligo";
                    this.Frame.Navigate(typeof(WeatherForecastCounty), city);
                    break;

                case 21:
                    city = "Tipperary";
                    this.Frame.Navigate(typeof(WeatherForecastCounty), city);
                    break;

                case 22:
                    city = "Waterford";
                    this.Frame.Navigate(typeof(WeatherForecastCounty), city);
                    break;

                case 23:
                    city = "An Iarmhí";
                    this.Frame.Navigate(typeof(WeatherForecastCounty), city);
                    break;

                case 24:
                    city = "Loch Garman";
                    this.Frame.Navigate(typeof(WeatherForecastCounty), city);
                    break;

                case 25:
                    city = "Wicklow";
                    this.Frame.Navigate(typeof(WeatherForecastCounty), city);
                    break;

                default:
                    break;
            }//switch
        }//SelectionChanged

        private void cityInput2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string city;

            switch (cityInput2.SelectedIndex)
            {
                case 0:
                    city = "Carlow";
                    this.Frame.Navigate(typeof(TideForecastCounty), city);
                    break;

                case 1:
                    city = "Cavan";
                    this.Frame.Navigate(typeof(TideForecastCounty), city);
                    break;

                case 2:
                    city = "Clare";
                    this.Frame.Navigate(typeof(TideForecastCounty), city);
                    break;

                case 3:
                    city = "Cork";
                    this.Frame.Navigate(typeof(TideForecastCounty), city);
                    break;

                case 4:
                    city = "Donegal";
                    this.Frame.Navigate(typeof(TideForecastCounty), city);
                    break;

                case 5:
                    city = "Dublin";
                    this.Frame.Navigate(typeof(TideForecastCounty), city);
                    break;

                case 6:
                    city = "Galway";
                    this.Frame.Navigate(typeof(TideForecastCounty), city);
                    break;

                case 7:
                    city = "Kerry";
                    this.Frame.Navigate(typeof(TideForecastCounty), city);
                    break;

                case 8:
                    city = "Kildare";
                    this.Frame.Navigate(typeof(TideForecastCounty), city);
                    break;

                case 9:
                    city = "Kilkenny";
                    this.Frame.Navigate(typeof(TideForecastCounty), city);
                    break;

                case 10:
                    city = "Laois";
                    this.Frame.Navigate(typeof(TideForecastCounty), city);
                    break;

                case 11:
                    city = "Carrick-on-Shannon";
                    this.Frame.Navigate(typeof(TideForecastCounty), city);
                    break;

                case 12:
                    city = "Limerick";
                    this.Frame.Navigate(typeof(TideForecastCounty), city);
                    break;

                case 13:
                    city = "Longford";
                    this.Frame.Navigate(typeof(TideForecastCounty), city);
                    break;

                case 14:
                    city = "Louth";
                    this.Frame.Navigate(typeof(TideForecastCounty), city);
                    break;

                case 15:
                    city = "Mayo";
                    this.Frame.Navigate(typeof(TideForecastCounty), city);
                    break;

                case 16:
                    city = "Meath";
                    this.Frame.Navigate(typeof(TideForecastCounty), city);
                    break;

                case 17:
                    city = "Monaghan";
                    this.Frame.Navigate(typeof(TideForecastCounty), city);
                    break;

                case 18:
                    city = "Offaly";
                    this.Frame.Navigate(typeof(TideForecastCounty), city);
                    break;

                case 19:
                    city = "Roscommon";
                    this.Frame.Navigate(typeof(TideForecastCounty), city);
                    break;

                case 20:
                    city = "Sligo";
                    this.Frame.Navigate(typeof(TideForecastCounty), city);
                    break;

                case 21:
                    city = "Tipperary";
                    this.Frame.Navigate(typeof(TideForecastCounty), city);
                    break;

                case 22:
                    city = "Waterford";
                    this.Frame.Navigate(typeof(TideForecastCounty), city);
                    break;

                case 23:
                    city = "Westmeath";
                    this.Frame.Navigate(typeof(TideForecastCounty), city);
                    break;

                case 24:
                    city = "Wexford";
                    this.Frame.Navigate(typeof(TideForecastCounty), city);
                    break;

                case 25:
                    city = "Wicklow";
                    this.Frame.Navigate(typeof(TideForecastCounty), city);
                    break;

                default:
                    break;
            }//Switch
        }//SectionChanged
    }//Search
}//UWP
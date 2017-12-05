using System;
using System.Linq;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace UWP_Project_3.Model
{
    public class SharedMethods
    {
        //Ref https://stackoverflow.com/questions/16010804/getting-only-time-of-a-datetime-object
        public DateTime getDate(double millisecond)
        {
            DateTime day = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(millisecond).ToLocalTime();

            return day;
        }//GetDate

        //Ref https://stackoverflow.com/questions/4135317/make-first-letter-of-a-string-upper-case-with-maximum-performance
        public static string FirstCharToUpper(string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }//FirstCharToUpper

        //Ref https://docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/dialogs
        public async void EnableGPSDialog()
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Error!",
                Content = "Location service must be enabled to use this application.",
                PrimaryButtonText = "Settings",
                SecondaryButtonText = "Close"
            };

            ContentDialogResult result = await dialog.ShowAsync();
            //Go to settings if primary button clicked
            if (result == ContentDialogResult.Primary)
            {
                await Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-location"));
            }
            else
            {
                //Close the dialog
            }
        }//EnableGPSDialog

        //Ref https://docs.microsoft.com/en-us/uwp/api/windows.ui.popups
        public async void WorldTidesError()
        {
            var message = new Windows.UI.Popups.MessageDialog("Unable to retrieve data from https://www.worldtides.info/");
            await message.ShowAsync();
        }

        public async void OpenWeatherMapError()
        {
            var message = new Windows.UI.Popups.MessageDialog("Unable to retrieve data from https://openweathermap.org/");
            await message.ShowAsync();
        }
    }//SharedMethods
}//UWP
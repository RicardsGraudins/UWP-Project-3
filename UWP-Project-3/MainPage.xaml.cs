using System;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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

        public class locationManager
        {
            public async static Task<Geoposition> GetPosition()
            {
                    var accessStatus = await Geolocator.RequestAccessAsync();
                    if (accessStatus != GeolocationAccessStatus.Allowed) throw new Exception();
                    var geolocator = new Geolocator { DesiredAccuracyInMeters = 0 };
                    var position = await geolocator.GetGeopositionAsync();
                    return position;
            }//GetPosition
        }//locationManager

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            var position = await locationManager.GetPosition();
            latitudecord = "Latitude: " + position.Coordinate.Latitude.ToString("0.0000000000");
            longitudecord = "Longitude: " + position.Coordinate.Longitude.ToString("0.0000000000");
            textBlock.Text = latitudecord;
            textBlock1.Text = longitudecord;
        }//button_Click
    }//main
}//UWP_Project_3

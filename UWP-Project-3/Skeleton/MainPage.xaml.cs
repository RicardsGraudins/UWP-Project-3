using UWP_Project_3.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWP_Project_3
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MyFrame.Navigate(typeof(Home));
            Home.IsSelected = true;
        }//MainPage

        //Open/close the splitview
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }//Menu_Click

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            //Refresh data on the selected page
            if (Home.IsSelected)
            {
                MyFrame.Navigate(typeof(Home), "a");
            }
            else if (Forecast.IsSelected)
            {
                MyFrame.Navigate(typeof(Forecast), "a");
            }
            else if (Search.IsSelected)
            {
                MyFrame.Navigate(typeof(Search), "a");
            }
        }//RefreshButton_Click

        //Navigate to pages via splitview
        private void Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Home.IsSelected)
            {
                MyFrame.Navigate(typeof(Home));
                TitleTextBlock.Text = "Home";
                if (MySplitView.IsPaneOpen == true)
                {
                    MySplitView.IsPaneOpen = false;
                }
            }
            else if (Forecast.IsSelected)
            {
                MyFrame.Navigate(typeof(Forecast));
                TitleTextBlock.Text = "Forecast";
                if (MySplitView.IsPaneOpen == true)
                {
                    MySplitView.IsPaneOpen = false;
                }
            }
            else if (Search.IsSelected)
            {
                MyFrame.Navigate(typeof(Search));
                TitleTextBlock.Text = "Search";
                if (MySplitView.IsPaneOpen == true)
                {
                    MySplitView.IsPaneOpen = false;
                }
            }
        }//Menu_SelectionChanged
    }//Main
}//UWP_Project_3
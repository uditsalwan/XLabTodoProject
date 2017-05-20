
using Plugin.Geolocator;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoDetailInputPage : ContentPage
    {
        public ToDoDetailInputPage()
        {
            InitializeComponent();
            BindingContext = new ToDoDetailInputPageViewModel(this);
            myDateTime.MinimumDate = DateTime.Now;
        }

        private async void CurrentLocation_Clicked(object sender, EventArgs e)
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = Constants.GeoLocatorDesiredAccuracy;

            ButtonCurrentLocation.IsEnabled = false;
            if (locator.IsGeolocationEnabled && locator.IsGeolocationAvailable)
            {
                var position = await locator.GetPositionAsync(timeoutMilliseconds: Constants.GeoPositionAsyncTimeOut);
                //await locator.StopListeningAsync();

                if (position == null)
                {
                    ButtonCurrentLocation.IsEnabled = true;
                    return;
                }
                ButtonCurrentLocation.IsVisible = false;
                LabelGPS.IsVisible = true;
                LabelGPS.Text = position.Latitude + Constants.DelimiterComma + position.Longitude;
            }
            else
            {
                ButtonCurrentLocation.IsEnabled = true;
                await DisplayAlert(AppResources.GPSDisable, AppResources.EnableGPSMessage, AppResources.OK);
            }
        }
    }
}

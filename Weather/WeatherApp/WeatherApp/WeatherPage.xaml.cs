using System;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class WeatherPage : ContentPage
    {
        public WeatherPage()
        {
            InitializeComponent();
            this.Title = "Sample Weather App";
            getWeatherByZipCodeBtn.Clicked += GetWeatherByZipCodeBtn_Clicked;
            getWeatherByCityBtn.Clicked += GetWeatherByCityBtn_Clicked;

            //Set the default binding to a default object for now
            this.BindingContext = new Weather();
        }
        
        private async void GetWeatherByZipCodeBtn_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(zipCodeEntry.Text))
            {
                Weather weather = await Core.GetWeather(zipCodeEntry.Text);
                if (weather != null)
                {
                    this.BindingContext = weather;
                    getWeatherByZipCodeBtn.Text = "Search Again";
                }
            }
        }

        private async void GetWeatherByCityBtn_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cityEntry.Text))
            {
                Weather weather = await Core.GetWeatherByCity(cityEntry.Text);
                if (weather != null)
                {
                    this.BindingContext = weather;
                    getWeatherByCityBtn.Text = "Search Again";
                }
            }
        }
    }
}
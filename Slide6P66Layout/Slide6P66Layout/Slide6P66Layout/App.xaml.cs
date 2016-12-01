using Slide6P66Layout.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Slide6P66Layout
{
    // http://stackoverflow.com/questions/27709788/stick-layout-in-xamarin-forms-to-bottom

    public partial class App : Application
    {
        public static List<City> CityList { get; set; }

        public App()
        {
            CityList = new List<City>();
            CreateCityList();
            MainPage = new NavigationPage(new Slide6P66Layout.MainPage(DateTime.Now.ToString("u")));
        }

        void CreateCityList()
        {
            App.CityList.Add(new City("New York") { });
            App.CityList.Add(new City("Paris") { });
            App.CityList.Add(new City("Tokyo") { });
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

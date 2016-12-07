using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

// Adding Facial Recognition to Your Mobile Apps
// https://blog.xamarin.com/adding-facial-recognition-to-your-mobile-apps/
// https://github.com/pierceboggan/smarter-apps

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace InvoiceIt
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new InvoiceIt.InvoicesPage())
            {
                BarBackgroundColor = Color.FromHex("#03A9F4"),
                BarTextColor = Color.White
            };
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

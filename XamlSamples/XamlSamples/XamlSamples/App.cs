using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XamlSamples
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application

            // Part 1
            MainPage = new XamlSamples.SharedResourcesPage();
            //MainPage = new XamlSamples.XamlPlusCodePage();
            // Part 2
            //MainPage = new XamlSamples.GridDemoPage();
            //MainPage = new XamlSamples.AbsoluteDemoPage();

            //MainPage = new ContentPage
            //{
            //    Content = new StackLayout
            //    {
            //        VerticalOptions = LayoutOptions.Center,
            //        Children = {
            //            new Label {
            //                HorizontalTextAlignment = TextAlignment.Center,
            //                Text = "Welcome to Xamarin Forms!"
            //            }
            //        }
            //    }
            //};
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

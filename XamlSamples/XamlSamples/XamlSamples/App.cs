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
            //MainPage = new XamlSamples.Part1.HelloXamlPage();
            MainPage = new XamlSamples.Part1.XamlPlusCodePage();

            // Part 2
            //MainPage = new XamlSamples.Part2.GridDemoPage();
            //MainPage = new XamlSamples.Part2.AbsoluteDemoPage();
            //MainPage = new XamlSamples.Part2.XamlPlusCodePage();

            // Part 3
            //MainPage = new XamlSamples.Part3.SharedResourcesPage();
            //MainPage = new XamlSamples.Part3.StaticConstantsPage();
            //MainPage = new XamlSamples.Part3.RelativeLayoutPage();

            // Part 4
            //MainPage = new XamlSamples.Part4.SliderBindingsPage();
            //MainPage = new XamlSamples.Part4.SliderTransformsPage();
            //MainPage = new XamlSamples.Part4.ListViewDemoPage();

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

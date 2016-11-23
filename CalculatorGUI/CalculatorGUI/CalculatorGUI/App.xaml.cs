using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CalculatorGUI
{
    public partial class App : Application
    {
        public App()
        {
            //var page = new ContentPage();
            //var layout = new StackLayout();
            //var label = new Label();
            //layout.Children.Add(label);
            //page.Content = layout;

            InitializeComponent();

            MainPage = new CalculatorGUI.MainPage();

      //      MainPage = new ContentPage(
      //              Children = {
      //new Label {Text = "Hello World!"},
      //new Button {Text = "Click Me!" }
      //      }
      //          );
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

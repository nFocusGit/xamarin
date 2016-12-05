using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace NavigationBasic
{
    public partial class App : Application
    {
        private TabbedPage tabbedPage = new TabbedPage();
        //Page pageTabbedA = new PageTabbedA();
        //Page pageTabbed1 = new PageTabbed1();

        private NavigationPage navigationPageLetters = new NavigationPage();
        private NavigationPage navigationPageNumbers = new NavigationPage();



        public App()
        {
            InitializeComponent();

            MainPage = tabbedPage;
            //tabbedPage.Children.Add(pageTabbedA);
            //tabbedPage.Children.Add(pageTabbed1);

            //tabbedPage.Children.Add(navigationPageLetters);
            //tabbedPage.Children.Add(navigationPageNumbers);
        }

        protected override async void OnStart()
        {
            Page pageTabbedA = new PageTabbedA();
            Page pageTabbed1 = new PageTabbed1();

            navigationPageLetters.Title = "Page A";
            navigationPageNumbers.Title = "Page 1";

            await navigationPageLetters.PushAsync(pageTabbedA);
            await navigationPageNumbers.PushAsync(pageTabbed1);

            
            tabbedPage.Children.Add(navigationPageLetters);
            tabbedPage.Children.Add(navigationPageNumbers);
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

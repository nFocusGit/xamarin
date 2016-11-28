using INotifyPropertyChangedMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using INotifyPropertyChangedMVVM.Pages;
using Xamarin.Forms;

namespace INotifyPropertyChangedMVVM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            // create viewModel
            MyViewModel myViewModel = new MyViewModel();
            MainPage = new MyPage(myViewModel);
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

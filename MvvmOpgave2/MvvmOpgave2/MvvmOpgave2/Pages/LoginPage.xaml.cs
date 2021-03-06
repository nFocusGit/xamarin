﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmOpgave2.ViewModels;
using Xamarin.Forms;
using System.Text.RegularExpressions;

namespace MvvmOpgave2.Pages
{
    public partial class LoginPage : ContentPage
    {
        private LoginModel loginModel;

        public LoginPage(LoginModel loginModel)
        {
            InitializeComponent();
            //waterfall.Source = new ImageSource("waterfall");
            this.loginModel = loginModel;
            BindingContext = this.loginModel;

            okButton.SetBinding(Button.IsEnabledProperty, "LoginButtonEnabled", BindingMode.OneWay);
            //// type safe
            //loginEntry.SetBinding<LoginModel>(Entry.TextProperty, vm => vm.Pin, BindingMode.OneWayToSource);
        }

    }
}

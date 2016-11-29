using System;
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

        public LoginPage()
        {
            InitializeComponent();
        }

        public LoginPage(LoginModel loginModel)
        {
            this.loginModel = loginModel;
            BindingContext = this.loginModel;
            InitializeComponent();

            okButton.SetBinding(Button.IsEnabledProperty, "LoginButtonEnabled", BindingMode.OneWay);
            //// type safe
            loginEntry.SetBinding<LoginModel>(Entry.TextProperty, vm => vm.Pin, BindingMode.OneWayToSource);
        }

    }
}

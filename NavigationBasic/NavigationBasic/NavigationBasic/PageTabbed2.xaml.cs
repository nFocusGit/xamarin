using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NavigationBasic
{
    public partial class PageTabbed2 : ContentPage
    {
        public PageTabbed2()
        {
            InitializeComponent();
            Title = "PageTabbed 2";
        }

        private async void PushToRoot(object sender, EventArgs e)
        {
            //var pageTabbed2 = new PageTabbed2();
            await Navigation.PopAsync();
            //we could as well write like this
            //await Navigation.PushAsync(new Page2());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NavigationBasic
{
    public partial class PageTabbed1 : ContentPage
    {
        public PageTabbed1()
        {
            InitializeComponent();
            Title = "PageTabbed 1";
        }

        private async void PushPage2(object sender, EventArgs e)
        {
            var pageTabbed2 = new PageTabbed2();
            await Navigation.PushAsync(pageTabbed2);
            //we could as well write like this
            //await Navigation.PushAsync(new Page2());
        }
    }
}

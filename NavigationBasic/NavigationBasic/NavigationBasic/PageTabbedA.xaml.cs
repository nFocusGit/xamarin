using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NavigationBasic
{
    public partial class PageTabbedA : ContentPage
    {
        public PageTabbedA()
        {
            InitializeComponent();
            Title = "PageTabbed A";
        }

        private async void PushPageB(object sender, EventArgs e)
        {
            Page pageTabbedB = new PageTabbedB();
            await Navigation.PushAsync(pageTabbedB);
            //we could as well write like this
            //await Navigation.PushAsync(new Page2());
        }
    }
}

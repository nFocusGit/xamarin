using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculatorGUI
{
    public partial class MainPage : ContentPage
    {
        public string MyText{ get; set; }

        public MainPage()
        {
            InitializeComponent();
            Button h = new Button();
        }

        void OnClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            MyText += button.Text;
            display.Text = MyText;
        }
    }
}

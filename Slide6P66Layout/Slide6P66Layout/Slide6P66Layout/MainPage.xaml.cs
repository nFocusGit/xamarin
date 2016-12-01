using Slide6P66Layout.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Slide6P66Layout
{
    public partial class MainPage : ContentPage
    {
        private List<ICity> CityList;

        public MainPage(string date)
        {
            //this.CityList = (List < ICity >) cityList;

            InitializeComponent();
            dateLabel.Text = date;


            //cityListView.ItemsSource = this.CityList;
            //BindingContext = cityListView;
            //var newDataTemplate = new DataTemplate(typeof(NewView));
            //cityListView.ItemTapped = 
        }

        async void OnShowWeather(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowWeatherPage());
        }

        //async void OnNavigateButtonClicked(object sender, EventArgs e)
        //{
        //    var contact = new Contact
        //    {
        //        Name = "Jane Doe",
        //        Age = 30,
        //        Occupation = "Developer",
        //        Country = "USA"
        //    };

        //    var secondPage = new SecondPage();
        //    secondPage.BindingContext = contact;
        //    await Navigation.PushAsync(secondPage);
        //}
    }
}

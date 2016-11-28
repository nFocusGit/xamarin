using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INotifyPropertyChangedMVVM.ViewModels;
using Xamarin.Forms;

namespace INotifyPropertyChangedMVVM.Pages
{
    public partial class MyPage : ContentPage
    {
        private MyViewModel myViewModel;

        public MyPage()
        {
            InitializeComponent();
        }

        public MyPage(MyViewModel myViewModel)
        {
            this.myViewModel = myViewModel;

            BindingContext = this.myViewModel;
            
            InitializeComponent();

            okButton.SetBinding(Button.IsEnabledProperty, "FornavnOk", BindingMode.OneWay);

            // type safe
            fornavnEntry.SetBinding<MyViewModel>(Entry.TextProperty, vm => vm.Fornavn, BindingMode.OneWayToSource);
        }
    }
}

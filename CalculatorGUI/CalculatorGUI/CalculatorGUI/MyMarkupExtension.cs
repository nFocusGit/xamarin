using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;

namespace CalculatorGUI
{
    public class MyMarkupExtension : IMarkupExtension
    {
        public int X { get; set; }
        public int Y { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return (X + Y).ToString();
        }
    }
}

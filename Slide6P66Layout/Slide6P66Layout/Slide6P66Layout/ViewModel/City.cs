using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slide6P66Layout.ViewModel
{
    public class City : ICity
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public City(string name)
        {
            this.name = name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slide03
{
    public class Animal
    {
        private string name;
        private int legs;
        private int eyes;

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

        public int Legs
        {
            get
            {
                return legs;
            }

            set
            {
                legs = value;
            }
        }

        public int Eyes
        {
            get
            {
                return eyes;
            }

            set
            {
                eyes = value;
            }
        }

        public Animal(string name, int legs, int eyes)
        {
            this.Name = name;
            this.Legs = legs;
            this.Eyes = eyes;
        }

    }
}

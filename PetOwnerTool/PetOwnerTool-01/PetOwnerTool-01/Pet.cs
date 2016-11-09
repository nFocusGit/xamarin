using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slide03
{
    public class Pet
    {
        private string name;
        private Animal animal;

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

        public Animal Animal
        {
            get
            {
                return animal;
            }

            set
            {
                animal = value;
            }
        }

        public Pet(string name, Animal animal)
        {
            this.Name = name;
            this.Animal = animal;
        }
    }
}

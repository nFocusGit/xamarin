using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetOwnerTool_01
{
    public class Pet
    {
        public string name;
        public Animal animal;

        public Pet(string name, Animal animal)
        {
            this.name = name;
            this.animal = animal;
        }
    }
}

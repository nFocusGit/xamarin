using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetOwnerTool_01
{
    public class Person
    {
        public string name;
        public Pet pet;

        public Person(string name, Pet pet)
        {
            this.name = name;
            this.pet = pet;
        }
    }
}

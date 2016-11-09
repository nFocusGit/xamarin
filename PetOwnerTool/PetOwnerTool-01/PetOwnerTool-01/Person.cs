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
        public DateTime birthday;
        public Pet pet;

        public Person(string name, DateTime birthday, Pet pet)
        {
            this.name = name;
            this.birthday = birthday;
            this.pet = pet;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slide03
{
    public class Person
    {
        private string name;
        private DateTime birthday;
        private Pet pet;

        public string Name { get { return name; } set { name = value; } }
        public DateTime Birthday { get { return birthday; } set { birthday = value; } }
        public Pet Pet { get { return pet; } set { pet = value; } }

        public Person(string name, DateTime birthday, Pet pet)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Pet = pet;
        }

        public Person(string name, Pet pet)
        {
            this.Name = name;
            this.Pet = pet;
        }

        public Person(string name)
        {
            this.Name = name;
        }

        public Person(string name, string petName, string petAnimalType)
        {
            this.Name = name;
            Animal a = new Animal(petAnimalType);
            Pet p = new Pet(petName, a);
            p.Name = petName;
        }

        public int GetAge()
        {
            DateTime now = DateTime.Now;
            int result = now.Year - birthday.Year;
            return result;
        }

        public int GetNumberOfEyes()
        {
            int result = pet.Animal.Eyes;
            return result;
        }
    }
}

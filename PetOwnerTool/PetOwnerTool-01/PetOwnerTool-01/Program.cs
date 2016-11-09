using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetOwnerTool_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animalDog = new Animal("Dog", 4, 2);
            Animal animalCat = new Animal("Cat", 4, 2);
            Animal animalHuman = new Animal("Homosapien", 2, 2);

            Pet petDog = new Pet("Doggy", animalDog);
            Pet petCat = new Pet("Miawer", animalCat);
            Pet petHuman = new Pet("Arthur", animalHuman);
            
            Person person1 = new Person("Maximus", new DateTime(1910, 1, 18), petDog);
            Person person2 = new Person("Minnie", new DateTime(2010, 2, 18), petCat);
            Person person3 = new Person("Devil", new DateTime(3010, 3, 18), petHuman);

            List<Person> persons = new List<Person>();
            persons.Add(person1);
            persons.Add(person2);
            persons.Add(person3);

            foreach (var item in persons)
            {
                Console.WriteLine("Persons name: " + item.name 
                    + "\nBirthday: " + item.birthday.ToString("D") 
                    + "\nPet name: " + item.pet.name + " type: " + item.pet.animal.name + "\n");
            }

            Console.ReadKey();
        }
    }
}

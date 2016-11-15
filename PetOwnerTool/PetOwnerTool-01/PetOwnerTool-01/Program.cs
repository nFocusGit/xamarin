using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static PetOwnerTool_01.IntExtension;

namespace Slide03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------start PetOwnerTool...");
            PetOwnerTool();
            Console.WriteLine("-----------------------------end PetOwnerTool...");
            Console.ReadKey();

            Console.WriteLine("\n-----------------------------start VectorTool...");
            VectorTool();
            Console.WriteLine("-----------------------------end VectorTool...");
            Console.ReadKey();

            Console.WriteLine("\n-----------------------------start IntExtension...");
            var value = 3;
            Console.WriteLine(value.MultiplyValue());
            Console.WriteLine("-----------------------------end IntExtension...");
            Console.ReadKey();
        }

        private static void VectorTool()
        {
            Vector3D v1 = new Vector3D(1, 0, 2);
            Vector3D v2 = new Vector3D(0, 1, 3);

            Console.WriteLine("Length of v1: " + v1.CalculateLength());
            Console.WriteLine("Length of v2: " + v2.CalculateLength());

            var v3 = v1.AddVector(v2);
            Console.WriteLine("\nv1 + v2 = v3\nLength of v3: " + v3.CalculateLength());
        }
        

        private static void PetOwnerTool()
        {
            Animal animalDog = new Animal("Dog", 4, 1);
            Animal animalCat = new Animal("Cat", 4, 2);
            Animal animalHuman = new Animal("Homosapien", 2, 3);

            Pet petDog = new Pet("Doggy", animalDog);
            Pet petCat = new Pet("Miawer", animalCat);
            Pet petHuman = new Pet("Arthur", animalHuman);

            Person person1 = new Person("Maximus", new DateTime(1999, 1, 18), petDog);
            Person person2 = new Person("Minnie", new DateTime(2001, 2, 18), petCat);
            Person person3 = new Person("Devil", new DateTime(666, 6, 6), petHuman);

            List<Person> persons = new List<Person>();
            persons.Add(person1);
            persons.Add(person2);
            persons.Add(person3);

            PrintPersons(persons);

            //Console.ReadKey();
            //Animal newAnimal = new Animal("New Animal", 5, 10);
            //Pet newPet = new Pet("New Pet", newAnimal);
            //Person newPerson = new Person("New Person Name", newPet.Name, newAnimal.Name);
            //persons.Add(newPerson);
            //PrintPersons(persons);

            Person personObservable = new Person("Mr.Observable");
            personObservable.NameChanged += PersonNameChanged;
            personObservable.Name = "Mr.Hello";

        }


            public static void PersonNameChanged(object sender, string e)
            {
                Console.WriteLine("Name has been changed " + e);
            }

        private static void PrintPersons(List<Person> persons)
        {
            foreach (var item in persons)
            {
                Console.WriteLine("Name: " + item.Name
                    + " Birthday: " + item.Birthday.ToString("D") + " Age: " + item.GetAge()
                    + "\nHas a Pet called '" + item.Pet.Name + "' and is a " + item.Pet.Animal.Name
                    + " with " + item.GetNumberOfEyes() + " eye(s).\n");
            }
        }
    }

}

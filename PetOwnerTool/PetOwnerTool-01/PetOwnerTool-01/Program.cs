using System;
using System.Collections.Generic;
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
            Animal animalHuman = new Animal("Human", 2, 2);

            Pet petDog = new Pet("Wuffwuff", animalDog);
            Pet petCat = new Pet("Miawer", animalCat);
            Pet petHuman = new Pet("Arrgh", animalHuman);

            Person person1 = new Person("Max", petDog);
            Person person2 = new Person("Minnie", petCat);
            Person person3 = new Person("Devil", petHuman);

            Console.ReadKey();
        }
    }
}

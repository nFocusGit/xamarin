using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xamarin.Course.LINQ
{
    public class SnooperList<T> : IEnumerable<T>
    {
        private readonly List<T> list;

        public SnooperList(List<T> list)
        {
            this.list = list;
        }

        public T this[int index]
        {
            get { return list[index]; }
        }

        public event EventHandler Enumerated;

        public IEnumerator<T> GetEnumerator()
        {
            Enumerated?.Invoke(this, new EventArgs());
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    class Program
    {
        private static async Task<string> MainAsync()
        {
            return await Task.Run(() => GetText());   
        }

        private static async Task<string> GetText()
        {
            await Task.Delay(5000);
            return "finished...";
        }

        static void Main(string[] args)
        {
            // http://www.csharpstar.com/async-await-keyword-csharp/
            //////////////////////////Test Async...
            Console.WriteLine("Async started...");
            Task<string> value = MainAsync();
            Console.WriteLine("Async ended...press a key to continue...");
            Console.ReadKey();
            ///////////////////////////////////////////////////////////
            var pets = new SnooperList<Pet>(new List<Pet>()
            {
                new Pet("Rudolph the Goldfish", new AnimalKind("Goldfish", AnimalType.Fish, eyes: 2, legs: 0)),
                new Pet("Hugo", new AnimalKind("Dog", AnimalType.Bird)),
                new Pet("Kaptajn Kaper", new AnimalKind("Parrot", AnimalType.Bird)),
                new Pet("Mr. Hammer Jr.", new AnimalKind("Millipede", AnimalType.Fish, eyes: 2, legs: 1000)),
                new Pet("Ms. Silk", new AnimalKind("Spider", AnimalType.Bird, eyes: 6, legs: 8))
            });

            var people = new SnooperList<Person>(new List<Person>()
            {
                new Person("Anders And", 1934),
                new Person("Mr. Hammer", 1975, pets[3]),
                new Person("Sørøver John", 1969, pets[2]),
                new Person("Bent Tonse", 1973, pets[0]),
                new Person("Fyrst Walter", 1965),
                new Person("Gentleman Finn", 1972, pets[4]),
                new Person("Newton Dynamose", 1657)
            });

            // Register handlers, so we will know when the lists are enumerated
            pets.Enumerated += (s, e) => Console.WriteLine("*** Pets enumerated ***");
            people.Enumerated += (s, e) => Console.WriteLine("*** People enumerated ***");

            Console.WriteLine("Before calling any LINQ methods");
            var query = pets.Where(pet => pet.Kind.Legs > 2);
            Console.WriteLine("After Where");
            query = query.OrderBy(pet => pet.Name);
            Console.WriteLine("After OrderBy");
            var query2 = query.Select(pet => pet.Kind.Name);
            Console.WriteLine("After Select");

            int items = query2.Count();
            Console.WriteLine("After Count");

            foreach (var item in query)
            {
                Console.WriteLine(item.Name);
            }

            Console.ReadKey();
            //////////////////////// find Person born in 1972
            var findPerson1972 = from p in people
                                 where p.BirthYear.ToString() == "1972"
                                 select p;
            foreach (var item in findPerson1972)
            {
                Console.WriteLine(item.Name);

            }
            Console.ReadKey();
            //////////////////////// find all Persons 
            var findAllPersons = from p in people
                                 orderby p.Name //descending
                                 select p;
            foreach (var item in findAllPersons)
            {
                Console.WriteLine(item.Name);

            }
            Console.ReadKey();
            //////////////////////// find Fish Pets 
            var findFishPets = from p in pets
                               where p.Kind.Type == AnimalType.Fish
                               select p;
            foreach (var item in findFishPets)
            {
                Console.WriteLine(item.Kind.Name + " Type: " + item.Kind.Type);

            }
            Console.ReadKey();
            //////////////////////// find Pets with more than 2 eyes
            var findPetsWithMoreThan2Eyes = from p in people
                                            where (p.Pet != null) && p.Pet.Kind.Eyes > 2
                                            select p;
            foreach (var item in findPetsWithMoreThan2Eyes)
            {
                Console.WriteLine(item.Name + " Pet: " + item.Pet.Name + " Eyes: " + item.Pet.Kind.Eyes);

            }
            Console.ReadKey();
            //////////////////////// Sort by Pet type and Person name
            var findSortedByPetTypeAndPersons = from p in people
                                                where p.Pet != null
                                                orderby p.Pet.Kind.Type, p.Name
                                                select p;
            foreach (var item in findSortedByPetTypeAndPersons)
            {
                Console.WriteLine("Pet type: " + item.Pet.Kind.Type + " Owner: " + item.Name);

            }
            Console.ReadKey();
            //////////////////////// Group by Pet type
            var findPetGroups = from p in people
                                where p.Pet != null
                                group p by p.Pet.Kind.Type into g
                                select new { PetType = g.Key, Name = g};
            foreach (var item in findPetGroups)
            {
                Console.WriteLine("Pet type: " + item.PetType);
                foreach (var person in item.Name)
                {
                    Console.WriteLine("Person Name: " + person.Name);
                }

            }
            Console.ReadKey();
        }
    }
}

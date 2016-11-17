using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
        static void Main(string[] args)
        {
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
        }
    }
}

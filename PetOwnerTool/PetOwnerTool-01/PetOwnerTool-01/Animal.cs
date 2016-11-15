using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slide03
{
    public enum AnimalType { Bird, Fish }

    public class Animal
    {
        private readonly AnimalType animalType;
        private string name;
        private int legs;
        private int eyes;
        
        public Animal(string name, int legs, int eyes)
        {
            this.animalType = AnimalType.Fish;
            this.Name = name;
            this.Legs = legs;
            this.Eyes = eyes;
        }

        public Animal(string name)
        {
            this.animalType = AnimalType.Fish;
            this.Name = name;
            this.Legs = 0;
            this.Eyes = 0;
        }

        public string Name
        { get { return name; } set { name = value; } }

        public int Legs
        { get { return legs; } set { legs = value; } }

        public int Eyes
        { get { return eyes; } set { eyes = value; } }

        public AnimalType AnimalType
        { get { return animalType; } }
    }
}

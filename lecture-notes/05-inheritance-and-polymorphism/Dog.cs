using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplar
{
    public class Dog : Animal
    {
        // Adding a new field
        private string _colour;

        public Dog(string name, int age, string colour) : base(name, age) // The base class's constructor
        {
            this._colour = colour;
        }

        // Overriding the base class's implementation
        public override void Eat() { /*...*/ }

        // Its own class method
        public void Bark() { /*...*/ }

        public override string Name { get => name; set => name = value; }
        public string Colour { get => _colour; set => _colour = value; }
    }
}

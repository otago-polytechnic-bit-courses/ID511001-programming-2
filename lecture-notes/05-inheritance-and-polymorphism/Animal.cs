using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplar
{
    public class Animal
    {
        protected string name;
        protected int age;

        public Animal(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        // virtual - derived classes can override the base class implementation
        public virtual void Eat() { /*...*/ }
        public virtual void Sleep() { /*...*/ }

        public virtual string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
    }
}

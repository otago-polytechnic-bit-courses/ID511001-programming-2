using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplar
{
    public class Dog
    {
        // Fields
        public string name;
        public int age;

        // Constructor
        public Dog(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        // Methods
        public string Bark() => "Woof woof!";
        public string DisplayInfo() => $"Name: {name}, Age: {age}";

        // Instead of DisplayInfo(), you can also use ToString() method
        public override string ToString() => $"Name: {name}, Age: {age}";
    }
}

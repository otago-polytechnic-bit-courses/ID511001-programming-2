using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplar
{
    public class Circle : IShape
    {
        private double _radius;

        public Circle(double radius)
        {
            _radius = radius;
        }

        public double Area() => Math.PI * Math.Pow(_radius, 2);
        public double Perimeter() => 2 * Math.PI * _radius;
    }
}

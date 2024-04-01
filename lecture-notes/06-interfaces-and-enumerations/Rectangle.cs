using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplar
{
    public class Rectangle : IShape
    {
        private double _width;
        private double _height;

        public Rectangle(double width, double height)
        {
            _width = width;
            _height = height;
        }

        public double Area() => _width * _height;
        public double Perimeter() => 2 * (_width + _height);
    }
}

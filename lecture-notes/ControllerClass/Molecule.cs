using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerClass
{
    public class Molecule
    {
        private const int SIZE = 10;

        private Point position;
        private Color colour;
        private Graphics graphics;
        private Random random;
        private Brush brush;

        public Molecule(Point position, Color colour, Graphics graphics, Random random)
        {
            this.position = position;
            this.colour = colour;
            this.graphics = graphics;
            this.random = random;
        }

        public void Draw()
        {
            graphics.FillEllipse(new SolidBrush(colour), new Rectangle(position.X, position.Y, SIZE, SIZE));

            // or

            // graphics.FillEllipse(brush, position.X, position.Y, SIZE, SIZE);
        }
    }
}

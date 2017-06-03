using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezkolizyjne_skrzyzowanie
{
    abstract class Car
    {
        public int Speed { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Space { get; set; }

        public Car(int speed = 0, int length = 0, int width = 0, int space = 0)
        {
            Speed = speed;
            Length = length;
            Width = width;
            Space = space;
        }
    }
}

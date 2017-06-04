using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezkolizyjne_skrzyzowanie
{
    class Intersection
    {
        public Intersection() { }

        public static List<List<int>> Poziom = new List<List<int>>();
        public static List<List<int>> Pion = new List<List<int>>();
        public static int carsHorizontal { get; set; }
        public static int carsVertical { get; set; }
        public static int radius = 10;
        public static bool busy = false;
    }
}

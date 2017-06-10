/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;

namespace bezkolizyjne_skrzyzowanie
{
    class Mini : Truck
    {
         string Place;
        public int Length, Speed, Space;
        public int Id;

        Form Form123;
        public Button item = new Button();
        public Mutex Mut = new Mutex();
        //carSurface[0] - width, carSurface[1] - height
        List<int> carSurface = new List<int>();
        public Intersection Intersection = new Intersection();
        private bool occupyIntersection = false;
        private bool afterIntersection = false;
        public Mini(Intersection intersection, string place, int speed, int height, int width, int space, int x, int y, Form form1, Mutex mut): base()
        {
            Mut = mut;
            Intersection = intersection;
            item.Width = width;
            item.Height = height;
            item.BackColor = Color.Pink;
            Form123 = form1;
            Place = place;
            Speed = speed;
            Space = space;
            item.Left = x - item.Width / 2;
            item.Top = y - item.Height / 2;
            if (place == "pion")
            {
                Id = Intersection.Pion.Count;
                Length = height + space;
            }
            else
            {
                Length = width + space;
                Id = Intersection.Poziom.Count;
            }
            //carSurface.Add(0); //x_start
            //carSurface.Add(0); //y_start
            //carSurface.Add(width); //x_end
            //carSurface.Add(length + 2 * space); //y_end
            //intersection.BusyArea.Add(carSurface);
        }
    }
}
*/

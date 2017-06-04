using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace bezkolizyjne_skrzyzowanie
{
    class Truck : Intersection
    {
        string Place;
        public  int Length;
        public int Id;

        Form Form123;
        public Button item = new Button();
        //carSurface[0] - width, carSurface[1] - height
        List<int> carSurface = new List<int>();
        public Intersection Intersection;
        private bool occupyIntersection = false;
        private bool afterIntersection = false;

        public Truck(Intersection intersection, string place, int speed, int height, int width, int space, int x, int y, Form form1): base()
        {
            Intersection = intersection;
            item.Width = width;
            item.Height = height;
            item.BackColor = Color.Pink;
            Form123 = form1;
            Place = place;
            item.Left = x - item.Width / 2;
            item.Top = y - item.Height / 2;
            Length = height + 2 * space;
            if (place == "pion")
            {
                Id = Intersection.Pion.Count;
            } 
            else
            {
                Id = Intersection.Poziom.Count;
            }
            //carSurface.Add(0); //x_start
            //carSurface.Add(0); //y_start
            //carSurface.Add(width); //x_end
            //carSurface.Add(length + 2 * space); //y_end
            //intersection.BusyArea.Add(carSurface);
        }

        public delegate void moveBd(Button btn);
        void moveButton(Button btn)
        {
            int x = btn.Left;
            int y = btn.Top;
            if (Place == "pion")
            {
                if (Intersection.Pion.Count < Id + 1)
                {
                    carSurface.Add(y); //y_start
                    carSurface.Add(y + Length); //y_end
                    Intersection.Pion.Add(carSurface);
                }

                if (Id > 0 && (!Intersection.busy || Intersection.Pion[Id][1] < (Form123.Height / 2) - Intersection.radius) && (Intersection.Pion[Id - 1][0] > Intersection.Pion[Id][1]))
                {

                    btn.Location = new Point(x, y + 1);
                    Intersection.Pion[Id][0] = y + 1;
                    Intersection.Pion[Id][1] = y + 1 + Length;
                    item.Text = "nth";

                }
                else if (Id == 0 && (!Intersection.busy || Intersection.Pion[Id][1] < (Form123.Height / 2) - Intersection.radius))
                {
                    btn.Location = new Point(x, y + 1);

                    Intersection.Pion[Id][0] = y;
                    Intersection.Pion[Id][1] = y + Length;
                }
                else if (occupyIntersection)
                {
                    btn.Location = new Point(x, y + 1);
                    Intersection.busy = true;
                    Intersection.Pion[Id][0] = y;
                    Intersection.Pion[Id][1] = y + Length;
                    item.Text = "lock";
                }
                else if (Intersection.Pion[Id][0] > (Form123.Height / 2) + Intersection.radius + 40)
                {
                    btn.Location = new Point(x, y +1);
                    Intersection.Pion[Id][0] = y;
                    Intersection.Pion[Id][1] = y + Length;
                }
                if (!Intersection.busy && Intersection.Pion[Id][1] > (Form123.Height / 2) - Intersection.radius)
                {
                    Intersection.busy = true;
                    occupyIntersection = true;
                    item.Text = "lock";
                }
                if (occupyIntersection && ((Form123.Height / 2) + Intersection.radius + 40 < Intersection.Pion[Id][0]))
                {
                    Intersection.busy = false;
                    occupyIntersection = false;
                    item.Text = "unlock";

                }
            }
            else if (Place == "poziom")
            {
                if (Intersection.Poziom.Count < Id + 1)
                {
                    carSurface.Add(x); //y_start
                    carSurface.Add(x + Length); //y_end
                    Intersection.Poziom.Add(carSurface);
                } 
                if (Id > 0 && (!Intersection.busy || Intersection.Poziom[Id][1] < (Form123.Width / 2) - Intersection.radius) && (Intersection.Poziom[Id - 1][0] > Intersection.Poziom[Id][1]))
                {
                    
                    btn.Location = new Point(x + 1, y);
                    Intersection.Poziom[Id][0] = x + 1;
                    Intersection.Poziom[Id][1] = x + 1 + Length;
                    item.Text = "nth";

                } else if (Id == 0 && (!Intersection.busy || Intersection.Poziom[Id][1] < (Form123.Width / 2) - Intersection.radius))
                {
                    btn.Location = new Point(x + 1, y);

                    Intersection.Poziom[Id][0] = x;
                    Intersection.Poziom[Id][1] = x + Length;
                } else if (occupyIntersection)
                {
                    btn.Location = new Point(x + 1, y);
                    Intersection.busy = true;
                    Intersection.Poziom[Id][0] = x;
                    Intersection.Poziom[Id][1] = x + Length;
                    item.Text = "lock";
                } else if (Intersection.Poziom[Id][0] > (Form123.Width / 2) + Intersection.radius + 40)
                {
                    btn.Location = new Point(x + 1, y);
                    Intersection.Poziom[Id][0] = x;
                    Intersection.Poziom[Id][1] = x + Length;
                }
                if (!Intersection.busy && Intersection.Poziom[Id][1] > (Form123.Width / 2) - Intersection.radius)
                {
                    Intersection.busy = true;
                    occupyIntersection = true;
                    item.Text = "lock";
                }
                if (occupyIntersection && ((Form123.Width / 2) + Intersection.radius + 40 < Intersection.Poziom[Id][0]))
                {
                    Intersection.busy = false;
                    occupyIntersection = false;
                    item.Text = "unlock";
                    
                }
            }
        }

        public void Go()
        {
            while (item.Location.X < Form123.Width && item.Location.Y < Form123.Height)
            {

                item.Invoke(new moveBd(moveButton), this.item);
                Thread.Sleep(5);
            }
        }

    }
}

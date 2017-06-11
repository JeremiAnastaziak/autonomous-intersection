using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace bezkolizyjne_skrzyzowanie
{
    class Truck : Intersection
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

        public Truck(Intersection intersection, string place, int speed, int height, int width, int space, int x, int y, Form form1, Mutex mut): base()
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
        }

        public void allowDriveForward(string carPosition, Button button, int x, int y, int speed)
        {
            if (carPosition == "pion")
            {
                button.Location = new Point(x, y + speed);
                Intersection.Pion[Id][0] = y;
                Intersection.Pion[Id][1] = y + Length;
                item.Text = y.ToString();
            } 
            else
            {
                button.Location = new Point(x + speed, y);
                Intersection.Poziom[Id][0] = x;
                Intersection.Poziom[Id][1] = x + Length;
                item.Text = x.ToString();
            }
        }

        public void tryDriveForward(List<List<int>> positionList, Button button, int x, int y)
        {
            if (Id == 0 || positionList[Id - 1][0] >= positionList[Id][1] + Speed)
            {
                if (!Intersection.busy || positionList[Id][1] - Space < (Form123.Height / 2) - Intersection.radius - 10)
                {
                    allowDriveForward(Place, button, x, y, Speed);
                }
                else if (positionList[Id][0] > Form123.Height) {
                    allowDriveForward(Place, button, x, y, 1000);
                }
                else if (positionList[Id][0] > (Form123.Height / 2))
                {
                    allowDriveForward(Place, button, x, y, Speed);
                }
                else if (occupyIntersection)
                {
                    Intersection.busy = true;
                    allowDriveForward(Place, button, x, y, Speed);
                } 
            }

            if (!Intersection.busy && positionList[Id][1] > (Form123.Height / 2) - Intersection.radius)
            {
                Intersection.busy = true;
                occupyIntersection = true;
            }
            if (occupyIntersection && ((Form123.Height / 2) < positionList[Id][0]))
            {
                Intersection.busy = false;
                occupyIntersection = false;
            }
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
                tryDriveForward(Intersection.Pion, btn, x, y);
            }
            else if (Place == "poziom")
            {
                if (Intersection.Poziom.Count < Id + 1)
                {
                    carSurface.Add(x); //x_start
                    carSurface.Add(x + Length); //x_end
                    Intersection.Poziom.Add(carSurface);
                }
                tryDriveForward(Intersection.Poziom, btn, x, y);
            }
        }

        public void Go()
        {
            while (true)
            {
                Intersection.mut.WaitOne();

                item.Invoke(new moveBd(moveButton), this.item);

                Intersection.mut.ReleaseMutex();

                Thread.Sleep(500);
            }
        }
    }
}

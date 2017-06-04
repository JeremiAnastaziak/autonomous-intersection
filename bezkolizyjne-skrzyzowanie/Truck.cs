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
    class Truck: Button
    {
        string Place;
        Form Form123;
        public Truck(string place, int speed, int length, int width, int space, int x, int y, Form form1): base()
        {
            Width = width;
            Height = length;
            BackColor = Color.Pink;
            Form123 = form1;
            Place = place;
            Left = x - Width / 2;
            Top = y - Height / 2;
        }

        public delegate void moveBd(Button btn);
        void moveButton(Button btn)
        {
            int x = btn.Location.X;
            int y = btn.Location.Y;
            if (Place == "pion")
            {
                btn.Location = new Point(x, y + 1);
            } else
            {
                btn.Location = new Point(x + 1, y);
            }
        }

        public void Go()
        {
            while (Location.X < Form123.Width && Location.Y < Form123.Height)
            {

                Invoke(new moveBd(moveButton), this);
                Thread.Sleep(5);
            }
        }

    }
}

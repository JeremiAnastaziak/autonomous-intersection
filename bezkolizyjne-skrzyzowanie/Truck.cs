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
    class Truck: Car
    {
        public Button Car = new Button();
        public Truck(int Speed, int Length, int Width, int Space)
        {
            Car.Width = Width;
            Car.Height = Length;
            Car.BackColor = Color.Pink;

        }

        public void Move()
        {
            if(true)
            {
                Car.Left += 10;
                Thread.Sleep(1000);
            }
        }

    }
}

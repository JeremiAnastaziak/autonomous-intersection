using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bezkolizyjne_skrzyzowanie
{
    //public partial class Form1 : Form
    //{
    //    public Form1()
    //    {
    //        InitializeComponent();
    //        InitializeMyButton();

    //    }

    //    private void InitializeMyButton()
    //    {
    //        // Create and initialize a Button.
    //        Button horizontalRoad = new Button();
    //        Button verticalRoad = new Button();
    //        int roadWidth = 30;
    //        horizontalRoad.Width = ClientRectangle.Width;
    //        horizontalRoad.BackColor = Color.DarkGray;
    //        horizontalRoad.Top = (ClientRectangle.Height / 2) - (roadWidth / 2);
    //        horizontalRoad.Height = roadWidth;
    //        verticalRoad.Height = ClientRectangle.Height;
    //        verticalRoad.BackColor = Color.DarkGray;
    //        verticalRoad.Left = (ClientRectangle.Width / 2) - (roadWidth / 2);
    //        verticalRoad.Width = roadWidth;

    //        // Add the button to the form.
    //        Controls.Add(horizontalRoad);
    //        Controls.Add(verticalRoad);
    //    }


    //    //Truck car1 = new Truck(1, 100, 50, 20);
    //    //Controls.Add(car1.Car);

    //    //Thread Thr = new Thread(car1.Move);
    //    //Thr.Start();

    //    private delegate void moveBd(Button btn);
    //        void moveButton(Button btn)
    //        {
    //            int x = btn.Location.X;
    //            int y = btn.Location.Y;
    //            btn.Location = new Point(x + 1, y);
    //        }

    //        private void Go()
    //        {
    //        Button button1 = new Button();

    //        while ((button1.Location.X + button1.Size.Width) < this.Size.Width)
    //            {
    //                Invoke(new moveBd(moveButton), button1);
    //                Thread.Sleep(50);
    //            }
    //        }

    //}
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeIntersection();
        }

        private void InitializeIntersection()
        {
            // Create and initialize a Button.
            Button horizontalRoad = new Button();
            Button verticalRoad = new Button();
            int roadWidth = 30;
            horizontalRoad.Width = ClientRectangle.Width;
            horizontalRoad.BackColor = Color.DarkGray;
            horizontalRoad.Top = (ClientRectangle.Height / 2) - (roadWidth / 2);
            horizontalRoad.Height = roadWidth;
            verticalRoad.Height = ClientRectangle.Height;
            verticalRoad.BackColor = Color.DarkGray;
            verticalRoad.Left = (ClientRectangle.Width / 2) - (roadWidth / 2);
            verticalRoad.Width = roadWidth;

            // Add the button to the form.
            Controls.Add(horizontalRoad);
            Controls.Add(verticalRoad);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread thr = new Thread(Go);
            thr.Start();
        }

        private delegate void moveBd(Button btn);
        void moveButton(Button btn)
        {
            int x = btn.Location.X;
            int y = btn.Location.Y;
            btn.Location = new Point(x + 1, y);
        }

        private void Go()
        {
            while ((button1.Location.X + button1.Size.Width) < this.Size.Width)
            {

                Invoke(new moveBd(moveButton), button1);
                Thread.Sleep(50);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

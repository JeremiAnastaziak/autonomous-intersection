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
            int roadWidth = 20;
            horizontalRoad.Width = ClientRectangle.Width;
            horizontalRoad.BackColor = Color.DarkGray;
            horizontalRoad.Top = (ClientRectangle.Height / 2) - (roadWidth / 2);
            horizontalRoad.Height = roadWidth;
            horizontalRoad.SendToBack();
            verticalRoad.Height = roadWidth;
            verticalRoad.BackColor = Color.DarkGray;
            verticalRoad.Top = (ClientRectangle.Height / 2) - (roadWidth / 2);
            verticalRoad.Left = (ClientRectangle.Width / 2) - (roadWidth / 2);
            verticalRoad.Width = roadWidth;
            verticalRoad.SendToBack();


            // Add the button to the form.
            //Controls.Add(horizontalRoad);
            Controls.Add(verticalRoad);
        }
        Intersection intersection = new Intersection();
        public static Mutex mut = new Mutex();

        //generowanie auta w pionie
        private void button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randSpeed = rnd.Next(1, 4);
            Truck car = new Truck(intersection, "pion", randSpeed, 100, 50, 10, (ClientRectangle.Width / 2), 0, this, mut);
            Controls.Add(car.item);
            Thread thr = new Thread(car.Go);
            thr.Start();

        }
        //generowanie auta w poziomie
        private void button3_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randSpeed = rnd.Next(1, 4);
            Truck car = new Truck(intersection, "poziom", randSpeed, 50, 100, 10, 0, (ClientRectangle.Height / 2), this, mut);
            Controls.Add(car.item);
            Thread thr = new Thread(car.Go);
            thr.Start();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

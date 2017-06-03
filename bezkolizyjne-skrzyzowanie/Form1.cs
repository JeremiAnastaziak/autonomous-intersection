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
            InitializeMyButton();
        }

        private void InitializeMyButton()
        {
            // Create and initialize a Button.
            Button horizontalRoad = new Button();
            Button verticalRoad = new Button();
            int roadWidth = 30;
            horizontalRoad.Width = ClientRectangle.Width;
            horizontalRoad.BackColor = Color.DarkGray;
            horizontalRoad.Top = (ClientRectangle.Height / 2) - (roadWidth/2);
            horizontalRoad.Height = roadWidth;
            verticalRoad.Height = ClientRectangle.Height;
            verticalRoad.BackColor = Color.DarkGray;
            verticalRoad.Left = (ClientRectangle.Width / 2) - (roadWidth/2);
            verticalRoad.Width = roadWidth;

            // Add the button to the form.
            Controls.Add(horizontalRoad);
            Controls.Add(verticalRoad);

        }
    }
}

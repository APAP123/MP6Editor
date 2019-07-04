using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP6Editor
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void drawTest1_OnMouseWheelUpwards(MouseEventArgs e)
        {
            drawTest1.Board_OnMouseWheelUpwards(e);
        }

        private void drawTest1_OnMouseWheelDownwards(MouseEventArgs e)
        {
            drawTest1.Board_OnMouseWheelDownwards(e);
        }

        private void drawTest1_MouseClick(object sender, MouseEventArgs e)
        {
            drawTest1.Board_OnMouseClick(e);
            updateDisplayInfo();
        }

        //Updates on-screen information
        private void updateDisplayInfo()
        {
            label_SelectedSpace.Text = "" + drawTest1.SelectedSpace;
            textBox_X.Text = "" + drawTest1.Board[drawTest1.SelectedSpace].X;
            textBox_Y.Text = "" + drawTest1.Board[drawTest1.SelectedSpace].Y;
            textBox_Z.Text = "" + drawTest1.Board[drawTest1.SelectedSpace].Z;
        }//end updateDisplayInfo()
    }
}

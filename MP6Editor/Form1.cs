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
            //Clear previous links
            listBox_Links.Items.Clear();

            if(drawTest1.SelectedSpace > -1)
            {
                label_SelectedSpace.Text = "ID#: " + drawTest1.SelectedSpace;
                textBox_X.Text = "" + drawTest1.Board[drawTest1.SelectedSpace].X;
                textBox_Y.Text = "" + drawTest1.Board[drawTest1.SelectedSpace].Y;
                textBox_Z.Text = "" + drawTest1.Board[drawTest1.SelectedSpace].Z;
                comboBox_Type.SelectedIndex = drawTest1.Board[drawTest1.SelectedSpace].type;

                //Add SelectedSpace's links to the listBox
                for (int i = 0; i < drawTest1.Board[drawTest1.SelectedSpace].links.Count; i++)
                {
                    listBox_Links.Items.Add(drawTest1.Board[drawTest1.SelectedSpace].links[i]);
                }
                
            }
        }//end updateDisplayInfo()

        //Updates the board visuals to match the entered text
        private void updateSpaceInfo(int space)
        {
            drawTest1.Board[space].X = float.Parse(textBox_X.Text);
            drawTest1.Board[space].Y = float.Parse(textBox_Y.Text);
            drawTest1.Board[space].Z = float.Parse(textBox_Z.Text);
        }//end updateSpaceInfo

        private void Position_WasModified(object sender, EventArgs e)
        {
            TextBox sendingBox = (TextBox)sender;
            //bool wasmod = sendingBox.Modified;
            updateSpaceInfo(drawTest1.SelectedSpace);
            sendingBox.Modified = false;
        }
    }
}

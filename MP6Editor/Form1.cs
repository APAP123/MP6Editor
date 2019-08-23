﻿using System;
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

        private void DrawTest1_OnMouseWheelUpwards(MouseEventArgs e)
        {
            drawTest1.Board_OnMouseWheelUpwards(e);
        }

        private void DrawTest1_OnMouseWheelDownwards(MouseEventArgs e)
        {
            drawTest1.Board_OnMouseWheelDownwards(e);
        }

        private void DrawTest1_MouseClick(object sender, MouseEventArgs e)
        {
            drawTest1.Board_OnMouseClick(e);
            if(drawTest1.SelectedSpace > -1)
            {
                textBox_X.Enabled = true;
                textBox_Y.Enabled = true;
                textBox_Z.Enabled = true;
                comboBox_Type.Enabled = true;
                listBox_Links.Enabled = true;
            }
            UpdateDisplayInfo();
        }

        //Updates on-screen information
        private void UpdateDisplayInfo()
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
        private void UpdateSpaceInfo(int space)
        {
            //Position
            drawTest1.Board[space].X = float.Parse(textBox_X.Text);
            drawTest1.Board[space].Y = float.Parse(textBox_Y.Text);
            drawTest1.Board[space].Z = float.Parse(textBox_Z.Text);

            //type
            drawTest1.Board[space].type = comboBox_Type.SelectedIndex;

            pictureBox_Space.Image = GetNewSpace(drawTest1.Board[drawTest1.SelectedSpace].type);
        }//end updateSpaceInfo()

        //Returns image of passed space type
        //TODO: Move this and similar helper functions to their own class
        private Image GetNewSpace(int type)
        {
            switch (type)
            {
                case 0: //Blank
                    return MP6Editor.Properties.Resources.Blank;
                case 1: //Blue
                    return MP6Editor.Properties.Resources.Blue;
                case 2: //Red
                    return MP6Editor.Properties.Resources.Red;
                case 3: //Happening
                    return MP6Editor.Properties.Resources.Happening;
                case 4: //Miracle
                    return MP6Editor.Properties.Resources.Miracle;
                case 5: //Duel
                    return MP6Editor.Properties.Resources.Dueling;
                case 6: //DK/Bowser
                    return MP6Editor.Properties.Resources.DK;
                case 8: //Orb
                    return MP6Editor.Properties.Resources.Orb;
                case 9: //Shop
                    return MP6Editor.Properties.Resources.Shop;
                default: //Everything else
                    return MP6Editor.Properties.Resources.Other;
            }
        }//end GetNewSpace()

        //Updates visual information if space position was changed
        private void Position_WasModified(object sender, EventArgs e)
        {
            TextBox sendingBox = (TextBox)sender;
            //bool wasmod = sendingBox.Modified;
            UpdateSpaceInfo(drawTest1.SelectedSpace);
            sendingBox.Modified = false;
        }//end Position_WasModified()

        //Updates space type if changed
        private void type_WasModified(object sender, EventArgs e)
        {
            //drawTest1.Board[drawTest1.SelectedSpace].type = comboBox_Type.SelectedIndex;
            UpdateSpaceInfo(drawTest1.SelectedSpace);
        }//end type_WasModified()

        //Opens the file openFileDialog to select the w##.bin file
        private void ImportFile(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            //if openFileDialog was successful
            if(openFileDialog_wbin.ShowDialog() == DialogResult.OK)
            {
                //TODO: Possible code clean up? These method calls to other classes feels sloppy
                Extractor extractor = new Extractor();

                filePath = openFileDialog_wbin.FileName;
                extractor.QuickExtract(filePath, false);
                drawTest1.Board = extractor.ReadFile();
                drawTest1.InitPositions();
            }
        }//end ImportFile()

        //Opposite 
        private void ExportFile(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            //if openFileDialog was successful
            if (openFileDialog_wbin.ShowDialog() == DialogResult.OK)
            {
                //TODO: ditto with ImportFile
                Extractor extractor = new Extractor();

                filePath = openFileDialog_wbin.FileName;
                extractor.QuickExtract(filePath, true);
            }
        }//end ExportFile()

        //Saves current board to MP6 format
        private void SaveBoard(object sender, EventArgs e)
        {
            //TODO
            Extractor extractor = new Extractor();
            extractor.SaveBoardLayout(drawTest1.Board);
        }//end SaveBoard()
    }
}

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
        ImageList imageList = new ImageList();
        string packedFileName = "";
        //List<int> newOffsets;
        List<byte[]> oldOffsets;

        public Form1()
        {
            InitializeComponent();

            //Populate imageList
            foreach (string spaceType in Enum.GetNames(typeof(Space.Types)))
            {
                imageList.Images.Add("Blank", Image.FromFile("thumbs\\" + spaceType + ".png"));
            }
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
                listView_Links.Enabled = true;
            }
            UpdateDisplayInfo();
        }

        //Updates on-screen information
        private void UpdateDisplayInfo()
        {
            //Clear previous links
            listView_Links.Items.Clear();

            if(drawTest1.SelectedSpace > -1)
            {
                label_SelectedSpace.Text = "ID#: " + drawTest1.SelectedSpace;
                textBox_X.Text = "" + drawTest1.Board[drawTest1.SelectedSpace].X;
                textBox_Y.Text = "" + drawTest1.Board[drawTest1.SelectedSpace].Y;
                textBox_Z.Text = "" + drawTest1.Board[drawTest1.SelectedSpace].Z;
                comboBox_Type.SelectedIndex = drawTest1.Board[drawTest1.SelectedSpace].type;

                listView_Links.LargeImageList = null;
                listView_Links.LargeImageList = imageList;

                //Add SelectedSpace's links to the listBox
                for (int i = 0; i < drawTest1.Board[drawTest1.SelectedSpace].links.Count; i++)
                {
                    listView_Links.Items.Add(drawTest1.Board[drawTest1.SelectedSpace].links[i].ToString(), drawTest1.Board[drawTest1.Board[drawTest1.SelectedSpace].links[i]].type);
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

            //links
            drawTest1.Board[space].linkAmount = drawTest1.Board[space].links.Count;

            pictureBox_Space.Image = GetSpaceImage(drawTest1.Board[drawTest1.SelectedSpace].type);
        }//end updateSpaceInfo()

        //Updates the passed space's links
        private void UpdateSpaceLinks(int space)
        {
            if (listView_Links.Items.Count > 0)
            {
                for (int i = 0; i < drawTest1.Board[space].links.Count; i++)
                {
                    drawTest1.Board[space].links[i] = int.Parse(listView_Links.Items[i].Text);
                }
            }
        }//end UpdateSpaceLinks()

        //Returns image of passed space type
        //TODO: can possibly move to Space.cs; could also do this with enums (see constructor)
        private Image GetSpaceImage(int type)
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
        }//end GetSpaceImage()

        //Updates visual information if space position was changed
        private void Position_WasModified(object sender, EventArgs e)
        {
            TextBox sendingBox = (TextBox)sender;
            UpdateSpaceInfo(drawTest1.SelectedSpace);
            sendingBox.Modified = false;
        }//end Position_WasModified()

        //Updates space type if changed
        private void type_WasModified(object sender, EventArgs e)
        {
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
                packedFileName = filePath;
                oldOffsets = extractor.GetFileHeader(filePath);
                extractor.QuickExtract(filePath, false);
                drawTest1.Board = extractor.ReadFile();
                drawTest1.InitPositions();
            }
        }//end ImportFile()

        //Opposite 
        private void ExportFile(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            //if saveFileDialog was successful
            if (saveFileDialog_wbin.ShowDialog() == DialogResult.OK)
            {
                Extractor extractor = new Extractor();

                filePath = saveFileDialog_wbin.FileName;
                //extractor.QuickExtract(filePath, true);
                extractor.SaveBoardLayout(drawTest1.Board);
                //extractor.RepackFile(filePath, packedFileName);
                extractor.RepackFile(filePath, packedFileName, oldOffsets);
            }
        }//end ExportFile()

        //Saves current board to MP6 format
        private void SaveBoard(object sender, EventArgs e)
        {
            Extractor extractor = new Extractor();
            extractor.SaveBoardLayout(drawTest1.Board);
        }//end SaveBoard()

        private void btn_AddSpace_click(object sender, EventArgs e)
        {
            //TODO
            //drawTest1.Board.Add(new Space(0, 0, 0, 0x00, new List<int>()));
        }

        //Adds a new link
        private void btn_AddLink_Click(object sender, EventArgs e)
        {
            drawTest1.Board[drawTest1.SelectedSpace].links.Add(1);
            UpdateSpaceInfo(drawTest1.SelectedSpace);
            UpdateDisplayInfo();

        }//end btn_AddLink_Click()

        //Remove a selected link
        private void btn_RemoveLink_Click(object sender, EventArgs e)
        {
            drawTest1.Board[drawTest1.SelectedSpace].links.Remove(int.Parse(listView_Links.SelectedItems[0].Text));
            UpdateSpaceInfo(drawTest1.SelectedSpace);
            UpdateDisplayInfo();
        }//end btn_RemoveLink_Click()

        private void listView_Links_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (listView_Links.SelectedItems.Count > 0 && e.Label != null)
            {
                listView_Links.SelectedItems[0].Text = e.Label;
                UpdateSpaceLinks(drawTest1.SelectedSpace);
                UpdateSpaceInfo(drawTest1.SelectedSpace);
                UpdateDisplayInfo();
            }
        }

        //Allows editing labels on double click rather than having to hold the mouse down
        private void listView_Links_Click(object sender, EventArgs e)
        {
            if(listView_Links.SelectedItems.Count > 0)
            {
                listView_Links.SelectedItems[0].BeginEdit();
            }
        }//end listView_Links_Click()
    }
}

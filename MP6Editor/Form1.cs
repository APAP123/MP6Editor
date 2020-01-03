using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace MP6Editor
{
    public partial class Form1 : Form
    {
        ImageList imageList = new ImageList();
        string packedFileName = "";
        List<byte[]> oldOffsets;

        public Form1()
        {
            InitializeComponent();

            // Populate imageList.
            foreach (string spaceType in Enum.GetNames(typeof(Space.Types)))
            {
                imageList.Images.Add("Blank", Image.FromFile("thumbs\\" + spaceType + ".png"));
            }

            AddToolTips();
        }

        private void AddToolTips()
        {
            toolTip_AddLink.SetToolTip(btn_AddLink, "Adds a new link to the currently selected space.");
            toolTip_AddLink.SetToolTip(btn_RemoveLink, "Removes the currently selected link from the selected space.");
            toolTip_AddLink.SetToolTip(btn_CreateSpace, "Adds a new Space to the Board.");
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
                foreach(TextBox textBox in Controls.OfType<TextBox>())
                {
                    textBox.Enabled = true;
                }
                comboBox_Type.Enabled = true;
                listView_Links.Enabled = true;
                btn_AddLink.Enabled = true;
                btn_RemoveLink.Enabled = true;
            }
            UpdateDisplayInfo();
        }

        /// <summary>
        /// Updates form information.
        /// </summary>
        private void UpdateDisplayInfo()
        {
            // Clear listViews.
            listView_Links.Items.Clear();

            if(drawTest1.SelectedSpace > -1)
            {
                label_SelectedSpace.Text = "ID#: " + drawTest1.SelectedSpace;

                pictureBox_Space.Image = GetSpaceImage(drawTest1.Board[drawTest1.SelectedSpace].type);

                // Position
                textBox_X.Text = "" + drawTest1.Board[drawTest1.SelectedSpace].X;
                textBox_Y.Text = "" + drawTest1.Board[drawTest1.SelectedSpace].Y;
                textBox_Z.Text = "" + drawTest1.Board[drawTest1.SelectedSpace].Z;

                // Rotation
                textBox_Rot_X.Text = "" + drawTest1.Board[drawTest1.SelectedSpace].rot_X;
                textBox_Rot_Y.Text = "" + drawTest1.Board[drawTest1.SelectedSpace].rot_Y;
                textBox_Rot_Z.Text = "" + drawTest1.Board[drawTest1.SelectedSpace].rot_Z;

                // Scaling
                textBox_Scale_X.Text = "" + drawTest1.Board[drawTest1.SelectedSpace].scale_X;
                textBox_Scale_Y.Text = "" + drawTest1.Board[drawTest1.SelectedSpace].scale_Y;
                textBox_Scale_Z.Text = "" + drawTest1.Board[drawTest1.SelectedSpace].scale_Z;

                // TODO: Implement the adding of unrecognized types to comboBox Items List on the fly.
                comboBox_Type.SelectedIndex = drawTest1.Board[drawTest1.SelectedSpace].type;

                listView_Links.LargeImageList = null;
                listView_Links.LargeImageList = imageList;

                //  Add SelectedSpace's links to the listView.
                for (int i = 0; i < drawTest1.Board[drawTest1.SelectedSpace].links.Count; i++)
                {
                    listView_Links.Items.Add(drawTest1.Board[drawTest1.SelectedSpace].links[i].ToString(), drawTest1.Board[drawTest1.Board[drawTest1.SelectedSpace].links[i]].type);
                }

                List<byte> tempList = new List<byte>(drawTest1.Board[drawTest1.SelectedSpace].crap);
                tempList.Reverse();

                // Populate flag textBoxes with SelectedSpace's flags.
                for (int i = 0; i < drawTest1.Board[drawTest1.SelectedSpace].crap.Count; i++)
                {
                    groupBox_flags.Controls[i].Enabled = true;
                    groupBox_flags.Controls[i].Text = tempList[i].ToString("X2");
                }
            }
        }// end updateDisplayInfo()

        /// <summary>
        /// Updates the information on the selected Space to match the info in the forms.
        /// </summary>
        /// <param name="space">ID # of space to update.</param>
        private void UpdateSpaceInfo(int space)
        {
            // Position
            drawTest1.Board[space].X = float.Parse(textBox_X.Text);
            drawTest1.Board[space].Y = float.Parse(textBox_Y.Text);
            drawTest1.Board[space].Z = float.Parse(textBox_Z.Text);

            // Rotation
            drawTest1.Board[space].rot_X = float.Parse(textBox_Rot_X.Text);
            drawTest1.Board[space].rot_Y = float.Parse(textBox_Rot_Y.Text);
            drawTest1.Board[space].rot_Z = float.Parse(textBox_Rot_Z.Text);

            // Scaling
            drawTest1.Board[space].scale_X = float.Parse(textBox_Scale_X.Text);
            drawTest1.Board[space].scale_Y = float.Parse(textBox_Scale_Y.Text);
            drawTest1.Board[space].scale_Z = float.Parse(textBox_Scale_Z.Text);

            // type
            drawTest1.Board[space].type = comboBox_Type.SelectedIndex;

            // links
            drawTest1.Board[space].linkAmount = drawTest1.Board[space].links.Count;

            pictureBox_Space.Image = GetSpaceImage(drawTest1.Board[drawTest1.SelectedSpace].type);

            // flags
            drawTest1.Board[space].crap = UpdateFlags(space);
        }// end updateSpaceInfo()

        /// <summary>
        /// Updates the flags of the selected Space.
        /// </summary>
        /// <param name="space">ID # of space to update.</param>
        /// <returns>List of bytes with updated flags.</returns>
        public List<byte> UpdateFlags(int space)
        {
            List<byte> newFlags = new List<byte>(drawTest1.Board[space].crap);

            for(int i = 0; i < drawTest1.Board[space].crap.Count; i++)
            {
                if(groupBox_flags.Controls[i].Text != "")
                {
                    newFlags[i] = StringToByte(groupBox_flags.Controls[drawTest1.Board[space].crap.Count-1-i].Text);
                }
            }
            return newFlags;
        } // end UpdateFlags()

        /// <summary>
        /// Converts a two-char string of hex to a byte array.
        /// </summary>
        /// <param name="hex">Two-char string of hex.</param>
        /// <returns>byte-converted string.</returns>
        private byte StringToByte(string hex)
        {
            byte byt = Convert.ToByte(hex, 16);
            return byt;
        }// end StringToByteArray()

        /// <summary>
        /// Updates the passed space's links.
        /// </summary>
        /// <param name="space">ID # of space to update.</param>
        private void UpdateSpaceLinks(int space)
        {
            if (listView_Links.Items.Count > 0)
            {
                for (int i = 0; i < drawTest1.Board[space].links.Count; i++)
                {
                    drawTest1.Board[space].links[i] = int.Parse(listView_Links.Items[i].Text);
                }
            }
        }// end UpdateSpaceLinks()

        // Returns image of passed space type
        // TODO: can possibly move to Space.cs; could also do this with enums (see constructor)
        private Image GetSpaceImage(int type)
        {
            switch (type)
            {
                case 0: // Blank
                    return MP6Editor.Properties.Resources.Blank;
                case 1: // Blue
                    return MP6Editor.Properties.Resources.Blue;
                case 2: // Red
                    return MP6Editor.Properties.Resources.Red;
                case 3: // Happening
                    return MP6Editor.Properties.Resources.Happening;
                case 4: // Miracle
                    return MP6Editor.Properties.Resources.Miracle;
                case 5: // Duel
                    return MP6Editor.Properties.Resources.Dueling;
                case 6: // DK/Bowser
                    return MP6Editor.Properties.Resources.DK;
                case 8: // Orb
                    return MP6Editor.Properties.Resources.Orb;
                case 9: // Shop
                    return MP6Editor.Properties.Resources.Shop;
                default: // Everything else
                    return MP6Editor.Properties.Resources.Other;
            }
        }// end GetSpaceImage()

        /// <summary>
        /// Updates visual information if space position was changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Position_WasModified(object sender, EventArgs e)
        {
            TextBox sendingBox = (TextBox)sender;
            sendingBox.Modified = false;

            if (float.TryParse(sendingBox.Text, out float result))
            {
                System.Diagnostics.Debug.WriteLine("Validate successful!");
                UpdateSpaceInfo(drawTest1.SelectedSpace);
            }
            else if(sendingBox.Text == "" || sendingBox.Text == "-0" || sendingBox.Text == "-" || sendingBox.Text == null)
            {
                sendingBox.Text = "0";
                UpdateSpaceInfo(drawTest1.SelectedSpace);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Validate failed! Reverting to last good value...");
                UpdateDisplayInfo();
            }
        }// end Position_WasModified()

        // Updates space type if changed
        private void type_WasModified(object sender, EventArgs e)
        {
            UpdateSpaceInfo(drawTest1.SelectedSpace);
        }// end type_WasModified()

        // MP4 and MP5
        private void ImportType1_Click(object sender, EventArgs e)
        {
            ImportFile(sender, e, 4);
        }// end ImportType1_Click()

        // MP6 and MP7
        private void ImportType2_Click(object sender, EventArgs e)
        {
            ImportFile(sender, e, 6);
        }// end ImportType2_Click()

        /// <summary>
        /// Opens the openFileDialog to select the w##.bin file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="version">MP version of board currently being opened.</param>
        private void ImportFile(object sender, EventArgs e, int version)
        {
            string filePath = string.Empty;
            openFileDialog_wbin.Filter = "Mario Party " + version + " board files|*.bin|All files|*.*";
            // if openFileDialog was successful
            if (openFileDialog_wbin.ShowDialog() == DialogResult.OK)
            {
                // TODO: Possible code clean up? These method calls to other classes feels sloppy.
                Extractor extractor = new Extractor();

                extractor.mpVersion = version;

                filePath = openFileDialog_wbin.FileName;
                packedFileName = filePath;
                oldOffsets = extractor.GetFileHeader(filePath);
                extractor.QuickExtract(filePath, false);
                drawTest1.Board = extractor.ReadFile();
                drawTest1.InitPositions();
                btn_CreateSpace.Enabled = true;
                btn_DeleteSpace.Enabled = true;
            }
        }// end ImportFile()


        // Opposite 
        private void ExportFile(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            // if saveFileDialog was successful...
            if (saveFileDialog_wbin.ShowDialog() == DialogResult.OK)
            {
                Extractor extractor = new Extractor();

                filePath = saveFileDialog_wbin.FileName;
                extractor.SaveBoardLayout(drawTest1.Board);
                extractor.RepackFile(filePath, packedFileName, oldOffsets);
            }
        }// end ExportFile()

        // Saves current board to MP6 format.
        private void SaveBoard(object sender, EventArgs e)
        {
            if (saveFileDialog_wbin.ShowDialog() == DialogResult.OK)
            {
                Extractor extractor = new Extractor();
                extractor.SaveBoardLayout(drawTest1.Board);
            }
        }// end SaveBoard()

        // Adds a new link.
        private void btn_AddLink_Click(object sender, EventArgs e)
        {
            drawTest1.Board[drawTest1.SelectedSpace].links.Add(0);
            UpdateSpaceInfo(drawTest1.SelectedSpace);
            UpdateDisplayInfo();

        }// end btn_AddLink_Click()

        // Remove a selected link.
        private void btn_RemoveLink_Click(object sender, EventArgs e)
        {
            if (listView_Links.SelectedItems.Count == 1)
            {
                drawTest1.Board[drawTest1.SelectedSpace].links.Remove(int.Parse(listView_Links.SelectedItems[0].Text));
                UpdateSpaceInfo(drawTest1.SelectedSpace);
                UpdateDisplayInfo();
            }
        }// end btn_RemoveLink_Click()

        private void listView_Links_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            // Validates the new label text.
            if (listView_Links.SelectedItems.Count > 0 && e.Label != null 
                && int.Parse(e.Label) > -1 && int.Parse(e.Label) < drawTest1.Board.Count)
            {
                listView_Links.SelectedItems[0].Text = e.Label;
            }

            UpdateSpaceLinks(drawTest1.SelectedSpace);
            UpdateSpaceInfo(drawTest1.SelectedSpace);
            UpdateDisplayInfo();
        }

        // Allows editing labels on double click rather than having to hold the mouse down.
        private void listView_Links_Click(object sender, EventArgs e)
        {
            if(listView_Links.SelectedItems.Count > 0)
            {
                listView_Links.SelectedItems[0].BeginEdit();
            }
        }// end listView_Links_Click()

        // Creates a new Space connected to the currently selected one.
        private void btn_CreateSpace_Click(object sender, EventArgs e)
        {
            //drawTest1.Board.Add(new Space(0, 0, 0, 29, 0x00, new List<int>()));
            drawTest1.Board.Add(new Space(5));
            drawTest1.InitPositions();
        }

        // Draws Space ID # overlays when checked.
        private void displaySpaceIDsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem sendingItem = (ToolStripMenuItem)sender;
            drawTest1.fontDraw = sendingItem.Checked;
        }// end displaySpaceIDsToolStripMenuItem_CheckedChanged()

        // Deletes currently selected Space
        private void btn_DeleteSpace_Click(object sender, EventArgs e)
        {
            if(drawTest1.SelectedSpace > -1)
            {
                drawTest1.RemoveSpace(drawTest1.SelectedSpace);
            }
        } // end btn_DeleteSpace_Click()
    }
}

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
        int mp_version;
        List<byte[]> oldOffsets;

        public Form1()
        {
            InitializeComponent();

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
            List<Control> controls = GetAllControls(groupBox_spaceProperties);

            drawTest1.Board_OnMouseClick(e);
            if(drawTest1.SelectedSpace > -1)
            {
                foreach (Control control in controls)
                {
                    
                    control.Enabled = true;
                }

            }
            UpdateDisplayInfo();
        }

        /// <summary>
        /// Returns a list of all controls (including GroupBox nested ones) in the passed container.
        /// </summary>
        /// <param name="container">Container to return controls from.</param>
        private List<Control> GetAllControls(Control container)
        {
            List<Control> controls = new List<Control>();
            foreach(Control c in container.Controls)
            {
                if(c is GroupBox)
                {
                    controls.AddRange(GetAllControls(c));
                }
                else
                {
                    controls.Add(c);
                }
            }
            return controls;
        } // end GetAllControls()

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

                // ComboBoxes
                comboBox_Type.SelectedIndex = drawTest1.Board[drawTest1.SelectedSpace].type;
                comboBox_PathFlag.SelectedIndex = FlagToIndex<Space.PathFlags>(drawTest1.Board[drawTest1.SelectedSpace].flags[0]);
                comboBox_TravelFlag.SelectedIndex = FlagToIndex<Space.TraversalFlags>(drawTest1.Board[drawTest1.SelectedSpace].flags[1]);

                listView_Links.LargeImageList = null;
                listView_Links.LargeImageList = imageList;

                //  Add SelectedSpace's links to the listView.
                for (int i = 0; i < drawTest1.Board[drawTest1.SelectedSpace].links.Count; i++)
                {
                    listView_Links.Items.Add(drawTest1.Board[drawTest1.SelectedSpace].links[i].ToString(), drawTest1.Board[drawTest1.Board[drawTest1.SelectedSpace].links[i]].type);
                }

                List<byte> tempList = new List<byte>(drawTest1.Board[drawTest1.SelectedSpace].flags);
                tempList.Reverse();

                // Populate flag textBoxes with SelectedSpace's flags.
                for (int i = 0; i < drawTest1.Board[drawTest1.SelectedSpace].flags.Count; i++)
                {
                    groupBox_flags.Controls[i].Enabled = true;
                    groupBox_flags.Controls[i].Text = tempList[i].ToString("X2");
                }

                // Update ToolBox.
                toolBox.highlightSpace = drawTest1.Board[drawTest1.SelectedSpace].type;
            }
        }// end UpdateDisplayInfo()

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
            drawTest1.Board[space].flags = UpdateFlags(space);

            drawTest1.Board[space].flags[0] = (byte)IndexToFlag<Space.PathFlags>(comboBox_PathFlag.SelectedIndex);
            drawTest1.Board[space].flags[1] = (byte)IndexToFlag<Space.TraversalFlags>(comboBox_TravelFlag.SelectedIndex);
        }// end updateSpaceInfo()

        /// <summary>
        /// Updates the flags of the selected Space.
        /// </summary>
        /// <param name="space">ID # of space to update.</param>
        /// <returns>List of bytes with updated flags.</returns>
        public List<byte> UpdateFlags(int space)
        {
            List<byte> newFlags = new List<byte>(drawTest1.Board[space].flags);

            for(int i = 0; i < drawTest1.Board[space].flags.Count; i++)
            {
                if(groupBox_flags.Controls[i].Text != "")
                {
                    newFlags[i] = StringToByte(groupBox_flags.Controls[drawTest1.Board[space].flags.Count-1-i].Text);
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

        private void PopulateImageList(int version)
        {
            imageList.Images.Clear();

            foreach(string name in NameRetriever.GetTextureNames(version))
            {
                imageList.Images.Add(Image.FromFile(@"Content/" + name + ".png"));
            }
        } // end PopulateImageList()

        // Returns image of passed space type
        private Image GetSpaceImage(int type)
        {
            return imageList.Images[type];
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
        private void SpaceWasModified(object sender, EventArgs e)
        {
            UpdateSpaceInfo(drawTest1.SelectedSpace);
        }// end SpaceWasModified()

        /// <summary>
        /// Opens the openFileDialog to select the w##.bin file.
        /// </summary>
        private void ImportFile(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            int version = int.Parse(item.Tag.ToString());
            mp_version = version;

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
                drawTest1.LoadVersionTextures(version);
                drawTest1.InitPositions();

                toolBox.drawTypes = true;

                // Type ComboBox
                List<string> names = NameRetriever.GetSpaceNames(version);
                PopulateComboBox(version, comboBox_Type, names);

                // Path ComboBox
                names = NameRetriever.MP6_GetPathFlags();
                PopulateComboBox(version, comboBox_PathFlag, names);

                // Traversal ComboBox
                names = NameRetriever.MP6_GetTraversalFlags();
                PopulateComboBox(version, comboBox_TravelFlag, names);

                PopulateImageList(version);

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

        /// <summary>
        /// Populates the passed comboBox with the passed string List.
        /// </summary>
        /// <param name="version">Version of Mario Party being loaded.</param>
        /// <param name="comboBox">ComboBox to populate.</param>
        /// <param name="names">List of items to populate comboBox with.</param>
        private void PopulateComboBox(int version, ComboBox comboBox, List<string> names)
        {
            comboBox.Items.Clear();
            for(int i = 0; i < names.Count; i++)
            {
                comboBox.Items.Add(names[i] + " (" + i + ")");
            }
        }// end PopulateTypeComboBox()

        /// <summary>
        /// Returns comboBox index value based on passed flag value.
        /// </summary>
        /// <param name="flag">Value of flag.</param>
        /// <returns></returns>
        private int FlagToIndex<T>(int flag)
        {
            return Array.IndexOf((Enum.GetValues(typeof(T)) as int[]), flag);
        }// end PathFlagToIndex()

        /// <summary>
        /// Returns Enum value based on passed selected index value.
        /// </summary>
        /// <param name="index">Selected index value of comboBox.</param>
        /// <returns></returns>
        private int IndexToFlag<T>(int index)
        {
            return (Enum.GetValues(typeof(T)) as int[])[index];
        }// end IndexToFlag()

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
            drawTest1.Board.Add(new Space(mp_version));
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

        // Updates info on flag modification
        private void textBox_flags_WasModified(object sender, EventArgs e)
        {
            UpdateSpaceInfo(drawTest1.SelectedSpace);
        }
    }
}

namespace MP6Editor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label_SelectedSpace = new System.Windows.Forms.Label();
            this.textBox_X = new System.Windows.Forms.TextBox();
            this.textBox_Y = new System.Windows.Forms.TextBox();
            this.textBox_Z = new System.Windows.Forms.TextBox();
            this.label_X = new System.Windows.Forms.Label();
            this.label_Y = new System.Windows.Forms.Label();
            this.label_Z = new System.Windows.Forms.Label();
            this.comboBox_Type = new System.Windows.Forms.ComboBox();
            this.label_Type = new System.Windows.Forms.Label();
            this.label_Links = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marioParty4binToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marioParty5binToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marioParty6binToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marioParty7BoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.displaySpaceIDsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox_Space = new System.Windows.Forms.PictureBox();
            this.openFileDialog_wbin = new System.Windows.Forms.OpenFileDialog();
            this.btn_AddLink = new System.Windows.Forms.Button();
            this.btn_RemoveLink = new System.Windows.Forms.Button();
            this.listView_Links = new System.Windows.Forms.ListView();
            this.saveFileDialog_wbin = new System.Windows.Forms.SaveFileDialog();
            this.btn_CreateSpace = new System.Windows.Forms.Button();
            this.toolTip_AddLink = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_RemoveLink = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_CreateSpaceButton = new System.Windows.Forms.ToolTip(this.components);
            this.btn_DeleteSpace = new System.Windows.Forms.Button();
            this.drawTest1 = new MP6Editor.DrawTest();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Space)).BeginInit();
            this.SuspendLayout();
            // 
            // label_SelectedSpace
            // 
            this.label_SelectedSpace.AutoSize = true;
            this.label_SelectedSpace.Location = new System.Drawing.Point(605, 188);
            this.label_SelectedSpace.Name = "label_SelectedSpace";
            this.label_SelectedSpace.Size = new System.Drawing.Size(130, 13);
            this.label_SelectedSpace.TabIndex = 1;
            this.label_SelectedSpace.Text = "ID#: (No Space Selected)";
            // 
            // textBox_X
            // 
            this.textBox_X.Enabled = false;
            this.textBox_X.Location = new System.Drawing.Point(628, 222);
            this.textBox_X.MaxLength = 30;
            this.textBox_X.Name = "textBox_X";
            this.textBox_X.Size = new System.Drawing.Size(55, 20);
            this.textBox_X.TabIndex = 2;
            this.textBox_X.ModifiedChanged += new System.EventHandler(this.Position_WasModified);
            // 
            // textBox_Y
            // 
            this.textBox_Y.Enabled = false;
            this.textBox_Y.Location = new System.Drawing.Point(628, 248);
            this.textBox_Y.MaxLength = 30;
            this.textBox_Y.Name = "textBox_Y";
            this.textBox_Y.Size = new System.Drawing.Size(55, 20);
            this.textBox_Y.TabIndex = 3;
            this.textBox_Y.ModifiedChanged += new System.EventHandler(this.Position_WasModified);
            // 
            // textBox_Z
            // 
            this.textBox_Z.Enabled = false;
            this.textBox_Z.Location = new System.Drawing.Point(628, 274);
            this.textBox_Z.MaxLength = 30;
            this.textBox_Z.Name = "textBox_Z";
            this.textBox_Z.Size = new System.Drawing.Size(55, 20);
            this.textBox_Z.TabIndex = 4;
            this.textBox_Z.ModifiedChanged += new System.EventHandler(this.Position_WasModified);
            // 
            // label_X
            // 
            this.label_X.AutoSize = true;
            this.label_X.Location = new System.Drawing.Point(605, 225);
            this.label_X.Name = "label_X";
            this.label_X.Size = new System.Drawing.Size(17, 13);
            this.label_X.TabIndex = 5;
            this.label_X.Text = "X:";
            // 
            // label_Y
            // 
            this.label_Y.AutoSize = true;
            this.label_Y.Location = new System.Drawing.Point(605, 255);
            this.label_Y.Name = "label_Y";
            this.label_Y.Size = new System.Drawing.Size(17, 13);
            this.label_Y.TabIndex = 6;
            this.label_Y.Text = "Y:";
            // 
            // label_Z
            // 
            this.label_Z.AutoSize = true;
            this.label_Z.Location = new System.Drawing.Point(605, 281);
            this.label_Z.Name = "label_Z";
            this.label_Z.Size = new System.Drawing.Size(17, 13);
            this.label_Z.TabIndex = 7;
            this.label_Z.Text = "Z:";
            // 
            // comboBox_Type
            // 
            this.comboBox_Type.Enabled = false;
            this.comboBox_Type.FormattingEnabled = true;
            this.comboBox_Type.Items.AddRange(new object[] {
            "Blank (0)",
            "Blue (1)",
            "Red (2)",
            "Happening (3)",
            "Miracle (4)",
            "Duel (5)",
            "DK/Bowser (6)",
            "Star (7)",
            "Orb (8)",
            "Shop (9)",
            "Unknown (10)",
            "Unknown (11)"});
            this.comboBox_Type.Location = new System.Drawing.Point(628, 300);
            this.comboBox_Type.Name = "comboBox_Type";
            this.comboBox_Type.Size = new System.Drawing.Size(104, 21);
            this.comboBox_Type.TabIndex = 8;
            this.comboBox_Type.SelectedIndexChanged += new System.EventHandler(this.type_WasModified);
            // 
            // label_Type
            // 
            this.label_Type.AutoSize = true;
            this.label_Type.Location = new System.Drawing.Point(588, 308);
            this.label_Type.Name = "label_Type";
            this.label_Type.Size = new System.Drawing.Size(34, 13);
            this.label_Type.TabIndex = 9;
            this.label_Type.Text = "Type:";
            // 
            // label_Links
            // 
            this.label_Links.AutoSize = true;
            this.label_Links.Location = new System.Drawing.Point(588, 338);
            this.label_Links.Name = "label_Links";
            this.label_Links.Size = new System.Drawing.Size(51, 13);
            this.label_Links.TabIndex = 11;
            this.label_Links.Text = "Links To:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 22);
            this.toolStripDropDownButton1.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.marioParty4binToolStripMenuItem,
            this.marioParty5binToolStripMenuItem,
            this.marioParty6binToolStripMenuItem,
            this.marioParty7BoardToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Import";
            // 
            // marioParty4binToolStripMenuItem
            // 
            this.marioParty4binToolStripMenuItem.Name = "marioParty4binToolStripMenuItem";
            this.marioParty4binToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.marioParty4binToolStripMenuItem.Text = "Mario Party 4 board...";
            this.marioParty4binToolStripMenuItem.Click += new System.EventHandler(this.ImportType1_Click);
            // 
            // marioParty5binToolStripMenuItem
            // 
            this.marioParty5binToolStripMenuItem.Name = "marioParty5binToolStripMenuItem";
            this.marioParty5binToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.marioParty5binToolStripMenuItem.Text = "Mario Party 5 board...";
            this.marioParty5binToolStripMenuItem.Click += new System.EventHandler(this.ImportType1_Click);
            // 
            // marioParty6binToolStripMenuItem
            // 
            this.marioParty6binToolStripMenuItem.Name = "marioParty6binToolStripMenuItem";
            this.marioParty6binToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.marioParty6binToolStripMenuItem.Text = "Mario Party 6 board...";
            this.marioParty6binToolStripMenuItem.Click += new System.EventHandler(this.ImportType2_Click);
            // 
            // marioParty7BoardToolStripMenuItem
            // 
            this.marioParty7BoardToolStripMenuItem.Name = "marioParty7BoardToolStripMenuItem";
            this.marioParty7BoardToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.marioParty7BoardToolStripMenuItem.Text = "Mario Party 7 board...";
            this.marioParty7BoardToolStripMenuItem.Click += new System.EventHandler(this.ImportType2_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportToolStripMenuItem.Text = "Export...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.ExportFile);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveBoard);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displaySpaceIDsToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(45, 22);
            this.toolStripDropDownButton2.Text = "View";
            // 
            // displaySpaceIDsToolStripMenuItem
            // 
            this.displaySpaceIDsToolStripMenuItem.CheckOnClick = true;
            this.displaySpaceIDsToolStripMenuItem.Name = "displaySpaceIDsToolStripMenuItem";
            this.displaySpaceIDsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.displaySpaceIDsToolStripMenuItem.Text = "Display space IDs";
            this.displaySpaceIDsToolStripMenuItem.CheckedChanged += new System.EventHandler(this.displaySpaceIDsToolStripMenuItem_CheckedChanged);
            // 
            // pictureBox_Space
            // 
            this.pictureBox_Space.Image = global::MP6Editor.Properties.Resources.Other;
            this.pictureBox_Space.Location = new System.Drawing.Point(628, 36);
            this.pictureBox_Space.Name = "pictureBox_Space";
            this.pictureBox_Space.Size = new System.Drawing.Size(124, 124);
            this.pictureBox_Space.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Space.TabIndex = 13;
            this.pictureBox_Space.TabStop = false;
            // 
            // openFileDialog_wbin
            // 
            this.openFileDialog_wbin.Filter = "Mario Party 6 board files|*.bin|All files|*.*";
            this.openFileDialog_wbin.Title = "Open...";
            // 
            // btn_AddLink
            // 
            this.btn_AddLink.Enabled = false;
            this.btn_AddLink.Location = new System.Drawing.Point(758, 354);
            this.btn_AddLink.Name = "btn_AddLink";
            this.btn_AddLink.Size = new System.Drawing.Size(26, 23);
            this.btn_AddLink.TabIndex = 14;
            this.btn_AddLink.Text = "+";
            this.btn_AddLink.UseVisualStyleBackColor = true;
            this.btn_AddLink.Click += new System.EventHandler(this.btn_AddLink_Click);
            // 
            // btn_RemoveLink
            // 
            this.btn_RemoveLink.Enabled = false;
            this.btn_RemoveLink.Location = new System.Drawing.Point(758, 383);
            this.btn_RemoveLink.Name = "btn_RemoveLink";
            this.btn_RemoveLink.Size = new System.Drawing.Size(26, 23);
            this.btn_RemoveLink.TabIndex = 15;
            this.btn_RemoveLink.Text = "-";
            this.btn_RemoveLink.UseVisualStyleBackColor = true;
            this.btn_RemoveLink.Click += new System.EventHandler(this.btn_RemoveLink_Click);
            // 
            // listView_Links
            // 
            this.listView_Links.Enabled = false;
            this.listView_Links.HideSelection = false;
            this.listView_Links.LabelEdit = true;
            this.listView_Links.Location = new System.Drawing.Point(608, 354);
            this.listView_Links.MultiSelect = false;
            this.listView_Links.Name = "listView_Links";
            this.listView_Links.Size = new System.Drawing.Size(144, 97);
            this.listView_Links.TabIndex = 16;
            this.listView_Links.UseCompatibleStateImageBehavior = false;
            this.listView_Links.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listView_Links_AfterLabelEdit);
            this.listView_Links.DoubleClick += new System.EventHandler(this.listView_Links_Click);
            // 
            // saveFileDialog_wbin
            // 
            this.saveFileDialog_wbin.Filter = "Mario Party 6 board files|*.bin|All files|*.*";
            this.saveFileDialog_wbin.Title = "Save As...";
            // 
            // btn_CreateSpace
            // 
            this.btn_CreateSpace.Enabled = false;
            this.btn_CreateSpace.Location = new System.Drawing.Point(608, 457);
            this.btn_CreateSpace.Name = "btn_CreateSpace";
            this.btn_CreateSpace.Size = new System.Drawing.Size(144, 23);
            this.btn_CreateSpace.TabIndex = 17;
            this.btn_CreateSpace.Text = "Create New Space";
            this.btn_CreateSpace.UseVisualStyleBackColor = true;
            this.btn_CreateSpace.Click += new System.EventHandler(this.btn_CreateSpace_Click);
            // 
            // btn_DeleteSpace
            // 
            this.btn_DeleteSpace.Enabled = false;
            this.btn_DeleteSpace.Location = new System.Drawing.Point(608, 487);
            this.btn_DeleteSpace.Name = "btn_DeleteSpace";
            this.btn_DeleteSpace.Size = new System.Drawing.Size(144, 23);
            this.btn_DeleteSpace.TabIndex = 18;
            this.btn_DeleteSpace.Text = "Delete Space";
            this.btn_DeleteSpace.UseVisualStyleBackColor = true;
            this.btn_DeleteSpace.Click += new System.EventHandler(this.btn_DeleteSpace_Click);
            // 
            // drawTest1
            // 
            this.drawTest1.Location = new System.Drawing.Point(12, 36);
            this.drawTest1.MouseHoverUpdatesOnly = false;
            this.drawTest1.Name = "drawTest1";
            this.drawTest1.Size = new System.Drawing.Size(566, 444);
            this.drawTest1.TabIndex = 0;
            this.drawTest1.Text = "drawTest1";
            this.drawTest1.OnMouseWheelUpwards += new MonoGame.Forms.Controls.GraphicsDeviceControl.MouseWheelUpwardsEvent(this.DrawTest1_OnMouseWheelUpwards);
            this.drawTest1.OnMouseWheelDownwards += new MonoGame.Forms.Controls.GraphicsDeviceControl.MouseWheelDownwardsEvent(this.DrawTest1_OnMouseWheelDownwards);
            this.drawTest1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DrawTest1_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 521);
            this.Controls.Add(this.btn_DeleteSpace);
            this.Controls.Add(this.btn_CreateSpace);
            this.Controls.Add(this.listView_Links);
            this.Controls.Add(this.btn_RemoveLink);
            this.Controls.Add(this.btn_AddLink);
            this.Controls.Add(this.pictureBox_Space);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label_Links);
            this.Controls.Add(this.label_Type);
            this.Controls.Add(this.comboBox_Type);
            this.Controls.Add(this.label_Z);
            this.Controls.Add(this.label_Y);
            this.Controls.Add(this.label_X);
            this.Controls.Add(this.textBox_Z);
            this.Controls.Add(this.textBox_Y);
            this.Controls.Add(this.textBox_X);
            this.Controls.Add(this.label_SelectedSpace);
            this.Controls.Add(this.drawTest1);
            this.Name = "Form1";
            this.Text = "MP6Editor";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Space)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DrawTest drawTest1;
        public System.Windows.Forms.Label label_SelectedSpace;
        private System.Windows.Forms.TextBox textBox_X;
        private System.Windows.Forms.TextBox textBox_Y;
        private System.Windows.Forms.TextBox textBox_Z;
        private System.Windows.Forms.Label label_X;
        private System.Windows.Forms.Label label_Y;
        private System.Windows.Forms.Label label_Z;
        private System.Windows.Forms.ComboBox comboBox_Type;
        private System.Windows.Forms.Label label_Type;
        private System.Windows.Forms.Label label_Links;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.PictureBox pictureBox_Space;
        private System.Windows.Forms.OpenFileDialog openFileDialog_wbin;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.Button btn_AddLink;
        private System.Windows.Forms.Button btn_RemoveLink;
        private System.Windows.Forms.ListView listView_Links;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_wbin;
        private System.Windows.Forms.Button btn_CreateSpace;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem displaySpaceIDsToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip_AddLink;
        private System.Windows.Forms.ToolTip toolTip_RemoveLink;
        private System.Windows.Forms.ToolTip toolTip_CreateSpaceButton;
        private System.Windows.Forms.ToolStripMenuItem marioParty4binToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marioParty5binToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marioParty6binToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marioParty7BoardToolStripMenuItem;
        private System.Windows.Forms.Button btn_DeleteSpace;
    }
}


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
            this.listBox_Links = new System.Windows.Forms.ListBox();
            this.label_Links = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox_Space = new System.Windows.Forms.PictureBox();
            this.drawTest1 = new MP6Editor.DrawTest();
            this.openFileDialog_wbin = new System.Windows.Forms.OpenFileDialog();
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
            "Shop (9)"});
            this.comboBox_Type.Location = new System.Drawing.Point(628, 300);
            this.comboBox_Type.Name = "comboBox_Type";
            this.comboBox_Type.Size = new System.Drawing.Size(121, 21);
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
            // listBox_Links
            // 
            this.listBox_Links.Enabled = false;
            this.listBox_Links.FormattingEnabled = true;
            this.listBox_Links.Location = new System.Drawing.Point(608, 369);
            this.listBox_Links.Name = "listBox_Links";
            this.listBox_Links.Size = new System.Drawing.Size(124, 82);
            this.listBox_Links.TabIndex = 10;
            // 
            // label_Links
            // 
            this.label_Links.AutoSize = true;
            this.label_Links.Location = new System.Drawing.Point(588, 353);
            this.label_Links.Name = "label_Links";
            this.label_Links.Size = new System.Drawing.Size(51, 13);
            this.label_Links.TabIndex = 11;
            this.label_Links.Text = "Links To:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Import...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.ImportFile);
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
            // drawTest1
            // 
            this.drawTest1.Location = new System.Drawing.Point(12, 36);
            this.drawTest1.MouseHoverUpdatesOnly = false;
            this.drawTest1.Name = "drawTest1";
            this.drawTest1.Size = new System.Drawing.Size(566, 426);
            this.drawTest1.TabIndex = 0;
            this.drawTest1.Text = "drawTest1";
            this.drawTest1.OnMouseWheelUpwards += new MonoGame.Forms.Controls.GraphicsDeviceControl.MouseWheelUpwardsEvent(this.drawTest1_OnMouseWheelUpwards);
            this.drawTest1.OnMouseWheelDownwards += new MonoGame.Forms.Controls.GraphicsDeviceControl.MouseWheelDownwardsEvent(this.drawTest1_OnMouseWheelDownwards);
            this.drawTest1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.drawTest1_MouseClick);
            // 
            // openFileDialog_wbin
            // 
            this.openFileDialog_wbin.FileName = "openFileDialog_wbin";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 474);
            this.Controls.Add(this.pictureBox_Space);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label_Links);
            this.Controls.Add(this.listBox_Links);
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
        private System.Windows.Forms.ListBox listBox_Links;
        private System.Windows.Forms.Label label_Links;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.PictureBox pictureBox_Space;
        private System.Windows.Forms.OpenFileDialog openFileDialog_wbin;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    }
}


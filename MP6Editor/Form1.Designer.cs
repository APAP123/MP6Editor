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
            this.drawTest1 = new MP6Editor.DrawTest();
            this.SuspendLayout();
            // 
            // label_SelectedSpace
            // 
            this.label_SelectedSpace.AutoSize = true;
            this.label_SelectedSpace.Location = new System.Drawing.Point(605, 199);
            this.label_SelectedSpace.Name = "label_SelectedSpace";
            this.label_SelectedSpace.Size = new System.Drawing.Size(28, 13);
            this.label_SelectedSpace.TabIndex = 1;
            this.label_SelectedSpace.Text = "ID#:";
            // 
            // textBox_X
            // 
            this.textBox_X.Location = new System.Drawing.Point(628, 233);
            this.textBox_X.MaxLength = 30;
            this.textBox_X.Name = "textBox_X";
            this.textBox_X.Size = new System.Drawing.Size(55, 20);
            this.textBox_X.TabIndex = 2;
            this.textBox_X.ModifiedChanged += new System.EventHandler(this.Position_WasModified);
            // 
            // textBox_Y
            // 
            this.textBox_Y.Location = new System.Drawing.Point(628, 259);
            this.textBox_Y.MaxLength = 30;
            this.textBox_Y.Name = "textBox_Y";
            this.textBox_Y.Size = new System.Drawing.Size(55, 20);
            this.textBox_Y.TabIndex = 3;
            this.textBox_Y.ModifiedChanged += new System.EventHandler(this.Position_WasModified);
            // 
            // textBox_Z
            // 
            this.textBox_Z.Location = new System.Drawing.Point(628, 285);
            this.textBox_Z.MaxLength = 30;
            this.textBox_Z.Name = "textBox_Z";
            this.textBox_Z.Size = new System.Drawing.Size(55, 20);
            this.textBox_Z.TabIndex = 4;
            this.textBox_Z.ModifiedChanged += new System.EventHandler(this.Position_WasModified);
            // 
            // label_X
            // 
            this.label_X.AutoSize = true;
            this.label_X.Location = new System.Drawing.Point(605, 236);
            this.label_X.Name = "label_X";
            this.label_X.Size = new System.Drawing.Size(17, 13);
            this.label_X.TabIndex = 5;
            this.label_X.Text = "X:";
            // 
            // label_Y
            // 
            this.label_Y.AutoSize = true;
            this.label_Y.Location = new System.Drawing.Point(605, 266);
            this.label_Y.Name = "label_Y";
            this.label_Y.Size = new System.Drawing.Size(17, 13);
            this.label_Y.TabIndex = 6;
            this.label_Y.Text = "Y:";
            // 
            // label_Z
            // 
            this.label_Z.AutoSize = true;
            this.label_Z.Location = new System.Drawing.Point(605, 292);
            this.label_Z.Name = "label_Z";
            this.label_Z.Size = new System.Drawing.Size(17, 13);
            this.label_Z.TabIndex = 7;
            this.label_Z.Text = "Z:";
            // 
            // comboBox_Type
            // 
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
            this.comboBox_Type.Location = new System.Drawing.Point(628, 311);
            this.comboBox_Type.Name = "comboBox_Type";
            this.comboBox_Type.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Type.TabIndex = 8;
            // 
            // label_Type
            // 
            this.label_Type.AutoSize = true;
            this.label_Type.Location = new System.Drawing.Point(588, 319);
            this.label_Type.Name = "label_Type";
            this.label_Type.Size = new System.Drawing.Size(34, 13);
            this.label_Type.TabIndex = 9;
            this.label_Type.Text = "Type:";
            // 
            // listBox_Links
            // 
            this.listBox_Links.FormattingEnabled = true;
            this.listBox_Links.Location = new System.Drawing.Point(608, 380);
            this.listBox_Links.Name = "listBox_Links";
            this.listBox_Links.Size = new System.Drawing.Size(124, 82);
            this.listBox_Links.TabIndex = 10;
            // 
            // label_Links
            // 
            this.label_Links.AutoSize = true;
            this.label_Links.Location = new System.Drawing.Point(588, 364);
            this.label_Links.Name = "label_Links";
            this.label_Links.Size = new System.Drawing.Size(51, 13);
            this.label_Links.TabIndex = 11;
            this.label_Links.Text = "Links To:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 474);
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
    }
}


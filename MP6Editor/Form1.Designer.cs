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
            this.openFileDialog_wbin = new System.Windows.Forms.OpenFileDialog();
            this.btn_AddLink = new System.Windows.Forms.Button();
            this.btn_RemoveLink = new System.Windows.Forms.Button();
            this.listView_Links = new System.Windows.Forms.ListView();
            this.saveFileDialog_wbin = new System.Windows.Forms.SaveFileDialog();
            this.btn_CreateSpace = new System.Windows.Forms.Button();
            this.toolTip_AddLink = new System.Windows.Forms.ToolTip(this.components);
            this.btn_DeleteSpace = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Rot_Z = new System.Windows.Forms.TextBox();
            this.textBox_Rot_Y = new System.Windows.Forms.TextBox();
            this.textBox_Rot_X = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Scale_Z = new System.Windows.Forms.TextBox();
            this.textBox_Scale_Y = new System.Windows.Forms.TextBox();
            this.textBox_Scale_X = new System.Windows.Forms.TextBox();
            this.groupBox_flags = new System.Windows.Forms.GroupBox();
            this.textBox_flag7 = new System.Windows.Forms.TextBox();
            this.textBox_flag6 = new System.Windows.Forms.TextBox();
            this.textBox_flag5 = new System.Windows.Forms.TextBox();
            this.textBox_flag4 = new System.Windows.Forms.TextBox();
            this.textBox_flag3 = new System.Windows.Forms.TextBox();
            this.textBox_flag2 = new System.Windows.Forms.TextBox();
            this.textBox_flag1 = new System.Windows.Forms.TextBox();
            this.comboBox_PathFlag = new System.Windows.Forms.ComboBox();
            this.comboBox_TravelFlag = new System.Windows.Forms.ComboBox();
            this.label_PathFlag = new System.Windows.Forms.Label();
            this.label_TravelFlag = new System.Windows.Forms.Label();
            this.groupBox_position = new System.Windows.Forms.GroupBox();
            this.groupBox_flagCombo = new System.Windows.Forms.GroupBox();
            this.groupBox_rotation = new System.Windows.Forms.GroupBox();
            this.groupBox_size = new System.Windows.Forms.GroupBox();
            this.groupBox_type = new System.Windows.Forms.GroupBox();
            this.groupBox_spaceProperties = new System.Windows.Forms.GroupBox();
            this.pictureBox_Space = new System.Windows.Forms.PictureBox();
            this.toolBox = new MP6Editor.ToolBox();
            this.drawTest1 = new MP6Editor.DrawTest();
            this.toolStrip1.SuspendLayout();
            this.groupBox_flags.SuspendLayout();
            this.groupBox_position.SuspendLayout();
            this.groupBox_flagCombo.SuspendLayout();
            this.groupBox_rotation.SuspendLayout();
            this.groupBox_size.SuspendLayout();
            this.groupBox_type.SuspendLayout();
            this.groupBox_spaceProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Space)).BeginInit();
            this.SuspendLayout();
            // 
            // label_SelectedSpace
            // 
            this.label_SelectedSpace.AutoSize = true;
            this.label_SelectedSpace.Location = new System.Drawing.Point(7, 16);
            this.label_SelectedSpace.Name = "label_SelectedSpace";
            this.label_SelectedSpace.Size = new System.Drawing.Size(130, 13);
            this.label_SelectedSpace.TabIndex = 1;
            this.label_SelectedSpace.Text = "ID#: (No Space Selected)";
            // 
            // textBox_X
            // 
            this.textBox_X.Enabled = false;
            this.textBox_X.Location = new System.Drawing.Point(25, 17);
            this.textBox_X.MaxLength = 30;
            this.textBox_X.Name = "textBox_X";
            this.textBox_X.Size = new System.Drawing.Size(55, 20);
            this.textBox_X.TabIndex = 2;
            this.textBox_X.ModifiedChanged += new System.EventHandler(this.Position_WasModified);
            // 
            // textBox_Y
            // 
            this.textBox_Y.Enabled = false;
            this.textBox_Y.Location = new System.Drawing.Point(25, 43);
            this.textBox_Y.MaxLength = 30;
            this.textBox_Y.Name = "textBox_Y";
            this.textBox_Y.Size = new System.Drawing.Size(55, 20);
            this.textBox_Y.TabIndex = 3;
            this.textBox_Y.ModifiedChanged += new System.EventHandler(this.Position_WasModified);
            // 
            // textBox_Z
            // 
            this.textBox_Z.Enabled = false;
            this.textBox_Z.Location = new System.Drawing.Point(25, 69);
            this.textBox_Z.MaxLength = 30;
            this.textBox_Z.Name = "textBox_Z";
            this.textBox_Z.Size = new System.Drawing.Size(55, 20);
            this.textBox_Z.TabIndex = 4;
            this.textBox_Z.ModifiedChanged += new System.EventHandler(this.Position_WasModified);
            // 
            // label_X
            // 
            this.label_X.AutoSize = true;
            this.label_X.Location = new System.Drawing.Point(6, 20);
            this.label_X.Name = "label_X";
            this.label_X.Size = new System.Drawing.Size(17, 13);
            this.label_X.TabIndex = 5;
            this.label_X.Text = "X:";
            // 
            // label_Y
            // 
            this.label_Y.AutoSize = true;
            this.label_Y.Location = new System.Drawing.Point(6, 46);
            this.label_Y.Name = "label_Y";
            this.label_Y.Size = new System.Drawing.Size(17, 13);
            this.label_Y.TabIndex = 6;
            this.label_Y.Text = "Y:";
            // 
            // label_Z
            // 
            this.label_Z.AutoSize = true;
            this.label_Z.Location = new System.Drawing.Point(6, 72);
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
            this.comboBox_Type.Location = new System.Drawing.Point(6, 19);
            this.comboBox_Type.Name = "comboBox_Type";
            this.comboBox_Type.Size = new System.Drawing.Size(82, 21);
            this.comboBox_Type.TabIndex = 8;
            this.comboBox_Type.SelectionChangeCommitted += new System.EventHandler(this.SpaceWasModified);
            // 
            // label_Links
            // 
            this.label_Links.AutoSize = true;
            this.label_Links.Location = new System.Drawing.Point(7, 357);
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
            this.toolStrip1.Size = new System.Drawing.Size(1248, 25);
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
            this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.openToolStripMenuItem.Text = "Import";
            // 
            // marioParty4binToolStripMenuItem
            // 
            this.marioParty4binToolStripMenuItem.Name = "marioParty4binToolStripMenuItem";
            this.marioParty4binToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.marioParty4binToolStripMenuItem.Tag = "4";
            this.marioParty4binToolStripMenuItem.Text = "Mario Party 4 board...";
            this.marioParty4binToolStripMenuItem.Click += new System.EventHandler(this.ImportFile);
            // 
            // marioParty5binToolStripMenuItem
            // 
            this.marioParty5binToolStripMenuItem.Name = "marioParty5binToolStripMenuItem";
            this.marioParty5binToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.marioParty5binToolStripMenuItem.Tag = "5";
            this.marioParty5binToolStripMenuItem.Text = "Mario Party 5 board...";
            this.marioParty5binToolStripMenuItem.Click += new System.EventHandler(this.ImportFile);
            // 
            // marioParty6binToolStripMenuItem
            // 
            this.marioParty6binToolStripMenuItem.Name = "marioParty6binToolStripMenuItem";
            this.marioParty6binToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.marioParty6binToolStripMenuItem.Tag = "6";
            this.marioParty6binToolStripMenuItem.Text = "Mario Party 6 board...";
            this.marioParty6binToolStripMenuItem.Click += new System.EventHandler(this.ImportFile);
            // 
            // marioParty7BoardToolStripMenuItem
            // 
            this.marioParty7BoardToolStripMenuItem.Name = "marioParty7BoardToolStripMenuItem";
            this.marioParty7BoardToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.marioParty7BoardToolStripMenuItem.Tag = "7";
            this.marioParty7BoardToolStripMenuItem.Text = "Mario Party 7 board...";
            this.marioParty7BoardToolStripMenuItem.Click += new System.EventHandler(this.ImportFile);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.exportToolStripMenuItem.Text = "Export...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.ExportFile);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
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
            // openFileDialog_wbin
            // 
            this.openFileDialog_wbin.Filter = "Mario Party 6 board files|*.bin|All files|*.*";
            this.openFileDialog_wbin.Title = "Open...";
            // 
            // btn_AddLink
            // 
            this.btn_AddLink.Enabled = false;
            this.btn_AddLink.Location = new System.Drawing.Point(170, 373);
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
            this.btn_RemoveLink.Location = new System.Drawing.Point(170, 402);
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
            this.listView_Links.Location = new System.Drawing.Point(21, 373);
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
            this.btn_CreateSpace.Location = new System.Drawing.Point(10, 650);
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
            this.btn_DeleteSpace.Location = new System.Drawing.Point(10, 621);
            this.btn_DeleteSpace.Name = "btn_DeleteSpace";
            this.btn_DeleteSpace.Size = new System.Drawing.Size(144, 23);
            this.btn_DeleteSpace.TabIndex = 18;
            this.btn_DeleteSpace.Text = "Delete Space";
            this.btn_DeleteSpace.UseVisualStyleBackColor = true;
            this.btn_DeleteSpace.Click += new System.EventHandler(this.btn_DeleteSpace_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Z:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "X:";
            // 
            // textBox_Rot_Z
            // 
            this.textBox_Rot_Z.Enabled = false;
            this.textBox_Rot_Z.Location = new System.Drawing.Point(25, 69);
            this.textBox_Rot_Z.MaxLength = 30;
            this.textBox_Rot_Z.Name = "textBox_Rot_Z";
            this.textBox_Rot_Z.Size = new System.Drawing.Size(55, 20);
            this.textBox_Rot_Z.TabIndex = 21;
            this.textBox_Rot_Z.ModifiedChanged += new System.EventHandler(this.Position_WasModified);
            // 
            // textBox_Rot_Y
            // 
            this.textBox_Rot_Y.Enabled = false;
            this.textBox_Rot_Y.Location = new System.Drawing.Point(25, 43);
            this.textBox_Rot_Y.MaxLength = 30;
            this.textBox_Rot_Y.Name = "textBox_Rot_Y";
            this.textBox_Rot_Y.Size = new System.Drawing.Size(55, 20);
            this.textBox_Rot_Y.TabIndex = 20;
            this.textBox_Rot_Y.ModifiedChanged += new System.EventHandler(this.Position_WasModified);
            // 
            // textBox_Rot_X
            // 
            this.textBox_Rot_X.Enabled = false;
            this.textBox_Rot_X.Location = new System.Drawing.Point(25, 17);
            this.textBox_Rot_X.MaxLength = 30;
            this.textBox_Rot_X.Name = "textBox_Rot_X";
            this.textBox_Rot_X.Size = new System.Drawing.Size(55, 20);
            this.textBox_Rot_X.TabIndex = 19;
            this.textBox_Rot_X.ModifiedChanged += new System.EventHandler(this.Position_WasModified);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Z:";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Y:";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "X:";
            this.label6.Visible = false;
            // 
            // textBox_Scale_Z
            // 
            this.textBox_Scale_Z.Enabled = false;
            this.textBox_Scale_Z.Location = new System.Drawing.Point(25, 69);
            this.textBox_Scale_Z.MaxLength = 30;
            this.textBox_Scale_Z.Name = "textBox_Scale_Z";
            this.textBox_Scale_Z.Size = new System.Drawing.Size(55, 20);
            this.textBox_Scale_Z.TabIndex = 27;
            this.textBox_Scale_Z.Visible = false;
            this.textBox_Scale_Z.ModifiedChanged += new System.EventHandler(this.Position_WasModified);
            // 
            // textBox_Scale_Y
            // 
            this.textBox_Scale_Y.Enabled = false;
            this.textBox_Scale_Y.Location = new System.Drawing.Point(25, 43);
            this.textBox_Scale_Y.MaxLength = 30;
            this.textBox_Scale_Y.Name = "textBox_Scale_Y";
            this.textBox_Scale_Y.Size = new System.Drawing.Size(55, 20);
            this.textBox_Scale_Y.TabIndex = 26;
            this.textBox_Scale_Y.Visible = false;
            this.textBox_Scale_Y.ModifiedChanged += new System.EventHandler(this.Position_WasModified);
            // 
            // textBox_Scale_X
            // 
            this.textBox_Scale_X.Enabled = false;
            this.textBox_Scale_X.Location = new System.Drawing.Point(25, 17);
            this.textBox_Scale_X.MaxLength = 30;
            this.textBox_Scale_X.Name = "textBox_Scale_X";
            this.textBox_Scale_X.Size = new System.Drawing.Size(55, 20);
            this.textBox_Scale_X.TabIndex = 25;
            this.textBox_Scale_X.Visible = false;
            this.textBox_Scale_X.ModifiedChanged += new System.EventHandler(this.Position_WasModified);
            // 
            // groupBox_flags
            // 
            this.groupBox_flags.Controls.Add(this.textBox_flag7);
            this.groupBox_flags.Controls.Add(this.textBox_flag6);
            this.groupBox_flags.Controls.Add(this.textBox_flag5);
            this.groupBox_flags.Controls.Add(this.textBox_flag4);
            this.groupBox_flags.Controls.Add(this.textBox_flag3);
            this.groupBox_flags.Controls.Add(this.textBox_flag2);
            this.groupBox_flags.Controls.Add(this.textBox_flag1);
            this.groupBox_flags.Location = new System.Drawing.Point(10, 563);
            this.groupBox_flags.Name = "groupBox_flags";
            this.groupBox_flags.Size = new System.Drawing.Size(171, 52);
            this.groupBox_flags.TabIndex = 35;
            this.groupBox_flags.TabStop = false;
            this.groupBox_flags.Text = "Flags";
            // 
            // textBox_flag7
            // 
            this.textBox_flag7.Enabled = false;
            this.textBox_flag7.Location = new System.Drawing.Point(144, 19);
            this.textBox_flag7.MaxLength = 2;
            this.textBox_flag7.Name = "textBox_flag7";
            this.textBox_flag7.Size = new System.Drawing.Size(20, 20);
            this.textBox_flag7.TabIndex = 6;
            this.textBox_flag7.ModifiedChanged += new System.EventHandler(this.textBox_flags_WasModified);
            // 
            // textBox_flag6
            // 
            this.textBox_flag6.Enabled = false;
            this.textBox_flag6.Location = new System.Drawing.Point(121, 19);
            this.textBox_flag6.MaxLength = 2;
            this.textBox_flag6.Name = "textBox_flag6";
            this.textBox_flag6.Size = new System.Drawing.Size(20, 20);
            this.textBox_flag6.TabIndex = 5;
            this.textBox_flag6.ModifiedChanged += new System.EventHandler(this.textBox_flags_WasModified);
            // 
            // textBox_flag5
            // 
            this.textBox_flag5.Enabled = false;
            this.textBox_flag5.Location = new System.Drawing.Point(98, 19);
            this.textBox_flag5.MaxLength = 2;
            this.textBox_flag5.Name = "textBox_flag5";
            this.textBox_flag5.Size = new System.Drawing.Size(20, 20);
            this.textBox_flag5.TabIndex = 4;
            this.textBox_flag5.ModifiedChanged += new System.EventHandler(this.textBox_flags_WasModified);
            // 
            // textBox_flag4
            // 
            this.textBox_flag4.Enabled = false;
            this.textBox_flag4.Location = new System.Drawing.Point(75, 19);
            this.textBox_flag4.MaxLength = 2;
            this.textBox_flag4.Name = "textBox_flag4";
            this.textBox_flag4.Size = new System.Drawing.Size(20, 20);
            this.textBox_flag4.TabIndex = 3;
            this.textBox_flag4.ModifiedChanged += new System.EventHandler(this.textBox_flags_WasModified);
            // 
            // textBox_flag3
            // 
            this.textBox_flag3.Enabled = false;
            this.textBox_flag3.Location = new System.Drawing.Point(52, 19);
            this.textBox_flag3.MaxLength = 2;
            this.textBox_flag3.Name = "textBox_flag3";
            this.textBox_flag3.Size = new System.Drawing.Size(20, 20);
            this.textBox_flag3.TabIndex = 2;
            this.textBox_flag3.ModifiedChanged += new System.EventHandler(this.textBox_flags_WasModified);
            // 
            // textBox_flag2
            // 
            this.textBox_flag2.Enabled = false;
            this.textBox_flag2.Location = new System.Drawing.Point(29, 19);
            this.textBox_flag2.MaxLength = 2;
            this.textBox_flag2.Name = "textBox_flag2";
            this.textBox_flag2.Size = new System.Drawing.Size(20, 20);
            this.textBox_flag2.TabIndex = 1;
            this.textBox_flag2.ModifiedChanged += new System.EventHandler(this.textBox_flags_WasModified);
            // 
            // textBox_flag1
            // 
            this.textBox_flag1.Enabled = false;
            this.textBox_flag1.Location = new System.Drawing.Point(6, 19);
            this.textBox_flag1.MaxLength = 2;
            this.textBox_flag1.Name = "textBox_flag1";
            this.textBox_flag1.Size = new System.Drawing.Size(20, 20);
            this.textBox_flag1.TabIndex = 0;
            this.textBox_flag1.ModifiedChanged += new System.EventHandler(this.textBox_flags_WasModified);
            // 
            // comboBox_PathFlag
            // 
            this.comboBox_PathFlag.Enabled = false;
            this.comboBox_PathFlag.FormattingEnabled = true;
            this.comboBox_PathFlag.Location = new System.Drawing.Point(90, 19);
            this.comboBox_PathFlag.Name = "comboBox_PathFlag";
            this.comboBox_PathFlag.Size = new System.Drawing.Size(104, 21);
            this.comboBox_PathFlag.TabIndex = 36;
            this.comboBox_PathFlag.SelectionChangeCommitted += new System.EventHandler(this.SpaceWasModified);
            // 
            // comboBox_TravelFlag
            // 
            this.comboBox_TravelFlag.Enabled = false;
            this.comboBox_TravelFlag.FormattingEnabled = true;
            this.comboBox_TravelFlag.Location = new System.Drawing.Point(90, 53);
            this.comboBox_TravelFlag.Name = "comboBox_TravelFlag";
            this.comboBox_TravelFlag.Size = new System.Drawing.Size(104, 21);
            this.comboBox_TravelFlag.TabIndex = 37;
            this.comboBox_TravelFlag.SelectionChangeCommitted += new System.EventHandler(this.SpaceWasModified);
            // 
            // label_PathFlag
            // 
            this.label_PathFlag.AutoSize = true;
            this.label_PathFlag.Location = new System.Drawing.Point(6, 22);
            this.label_PathFlag.Name = "label_PathFlag";
            this.label_PathFlag.Size = new System.Drawing.Size(73, 13);
            this.label_PathFlag.TabIndex = 38;
            this.label_PathFlag.Text = "Path Settings:";
            // 
            // label_TravelFlag
            // 
            this.label_TravelFlag.AutoSize = true;
            this.label_TravelFlag.Location = new System.Drawing.Point(6, 56);
            this.label_TravelFlag.Name = "label_TravelFlag";
            this.label_TravelFlag.Size = new System.Drawing.Size(81, 13);
            this.label_TravelFlag.TabIndex = 39;
            this.label_TravelFlag.Text = "Travel Settings:";
            // 
            // groupBox_position
            // 
            this.groupBox_position.Controls.Add(this.textBox_X);
            this.groupBox_position.Controls.Add(this.textBox_Y);
            this.groupBox_position.Controls.Add(this.textBox_Z);
            this.groupBox_position.Controls.Add(this.label_X);
            this.groupBox_position.Controls.Add(this.label_Y);
            this.groupBox_position.Controls.Add(this.label_Z);
            this.groupBox_position.Location = new System.Drawing.Point(10, 256);
            this.groupBox_position.Name = "groupBox_position";
            this.groupBox_position.Size = new System.Drawing.Size(94, 98);
            this.groupBox_position.TabIndex = 40;
            this.groupBox_position.TabStop = false;
            this.groupBox_position.Text = "Position";
            // 
            // groupBox_flagCombo
            // 
            this.groupBox_flagCombo.Controls.Add(this.comboBox_PathFlag);
            this.groupBox_flagCombo.Controls.Add(this.comboBox_TravelFlag);
            this.groupBox_flagCombo.Controls.Add(this.label_TravelFlag);
            this.groupBox_flagCombo.Controls.Add(this.label_PathFlag);
            this.groupBox_flagCombo.Location = new System.Drawing.Point(10, 476);
            this.groupBox_flagCombo.Name = "groupBox_flagCombo";
            this.groupBox_flagCombo.Size = new System.Drawing.Size(200, 81);
            this.groupBox_flagCombo.TabIndex = 41;
            this.groupBox_flagCombo.TabStop = false;
            this.groupBox_flagCombo.Text = "Special Flags";
            // 
            // groupBox_rotation
            // 
            this.groupBox_rotation.Controls.Add(this.textBox_Rot_Z);
            this.groupBox_rotation.Controls.Add(this.textBox_Rot_X);
            this.groupBox_rotation.Controls.Add(this.textBox_Rot_Y);
            this.groupBox_rotation.Controls.Add(this.label3);
            this.groupBox_rotation.Controls.Add(this.label2);
            this.groupBox_rotation.Controls.Add(this.label1);
            this.groupBox_rotation.Location = new System.Drawing.Point(110, 256);
            this.groupBox_rotation.Name = "groupBox_rotation";
            this.groupBox_rotation.Size = new System.Drawing.Size(94, 98);
            this.groupBox_rotation.TabIndex = 42;
            this.groupBox_rotation.TabStop = false;
            this.groupBox_rotation.Text = "Rotation";
            // 
            // groupBox_size
            // 
            this.groupBox_size.Controls.Add(this.textBox_Scale_Z);
            this.groupBox_size.Controls.Add(this.textBox_Scale_X);
            this.groupBox_size.Controls.Add(this.textBox_Scale_Y);
            this.groupBox_size.Controls.Add(this.label6);
            this.groupBox_size.Controls.Add(this.label5);
            this.groupBox_size.Controls.Add(this.label4);
            this.groupBox_size.Location = new System.Drawing.Point(210, 256);
            this.groupBox_size.Name = "groupBox_size";
            this.groupBox_size.Size = new System.Drawing.Size(94, 98);
            this.groupBox_size.TabIndex = 43;
            this.groupBox_size.TabStop = false;
            this.groupBox_size.Text = "Size(?)";
            this.groupBox_size.Visible = false;
            // 
            // groupBox_type
            // 
            this.groupBox_type.Controls.Add(this.comboBox_Type);
            this.groupBox_type.Location = new System.Drawing.Point(210, 424);
            this.groupBox_type.Name = "groupBox_type";
            this.groupBox_type.Size = new System.Drawing.Size(94, 46);
            this.groupBox_type.TabIndex = 44;
            this.groupBox_type.TabStop = false;
            this.groupBox_type.Text = "Type";
            // 
            // groupBox_spaceProperties
            // 
            this.groupBox_spaceProperties.Controls.Add(this.toolBox);
            this.groupBox_spaceProperties.Controls.Add(this.groupBox_rotation);
            this.groupBox_spaceProperties.Controls.Add(this.groupBox_type);
            this.groupBox_spaceProperties.Controls.Add(this.label_SelectedSpace);
            this.groupBox_spaceProperties.Controls.Add(this.groupBox_size);
            this.groupBox_spaceProperties.Controls.Add(this.label_Links);
            this.groupBox_spaceProperties.Controls.Add(this.groupBox_flagCombo);
            this.groupBox_spaceProperties.Controls.Add(this.btn_AddLink);
            this.groupBox_spaceProperties.Controls.Add(this.groupBox_position);
            this.groupBox_spaceProperties.Controls.Add(this.btn_RemoveLink);
            this.groupBox_spaceProperties.Controls.Add(this.groupBox_flags);
            this.groupBox_spaceProperties.Controls.Add(this.listView_Links);
            this.groupBox_spaceProperties.Controls.Add(this.btn_DeleteSpace);
            this.groupBox_spaceProperties.Controls.Add(this.btn_CreateSpace);
            this.groupBox_spaceProperties.Location = new System.Drawing.Point(734, 12);
            this.groupBox_spaceProperties.Name = "groupBox_spaceProperties";
            this.groupBox_spaceProperties.Size = new System.Drawing.Size(314, 680);
            this.groupBox_spaceProperties.TabIndex = 45;
            this.groupBox_spaceProperties.TabStop = false;
            this.groupBox_spaceProperties.Text = "Space Properties";
            // 
            // pictureBox_Space
            // 
            this.pictureBox_Space.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Space.Image")));
            this.pictureBox_Space.Location = new System.Drawing.Point(1054, 28);
            this.pictureBox_Space.Name = "pictureBox_Space";
            this.pictureBox_Space.Size = new System.Drawing.Size(155, 157);
            this.pictureBox_Space.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Space.TabIndex = 13;
            this.pictureBox_Space.TabStop = false;
            // 
            // toolBox
            // 
            this.toolBox.ForeColor = System.Drawing.Color.IndianRed;
            this.toolBox.Location = new System.Drawing.Point(10, 34);
            this.toolBox.MouseHoverUpdatesOnly = false;
            this.toolBox.Name = "toolBox";
            this.toolBox.Size = new System.Drawing.Size(200, 216);
            this.toolBox.TabIndex = 46;
            this.toolBox.Text = "toolBox";
            // 
            // drawTest1
            // 
            this.drawTest1.Location = new System.Drawing.Point(12, 28);
            this.drawTest1.MouseHoverUpdatesOnly = false;
            this.drawTest1.Name = "drawTest1";
            this.drawTest1.Size = new System.Drawing.Size(716, 664);
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
            this.ClientSize = new System.Drawing.Size(1248, 704);
            this.Controls.Add(this.groupBox_spaceProperties);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.drawTest1);
            this.Controls.Add(this.pictureBox_Space);
            this.Name = "Form1";
            this.Text = "MP6Editor";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox_flags.ResumeLayout(false);
            this.groupBox_flags.PerformLayout();
            this.groupBox_position.ResumeLayout(false);
            this.groupBox_position.PerformLayout();
            this.groupBox_flagCombo.ResumeLayout(false);
            this.groupBox_flagCombo.PerformLayout();
            this.groupBox_rotation.ResumeLayout(false);
            this.groupBox_rotation.PerformLayout();
            this.groupBox_size.ResumeLayout(false);
            this.groupBox_size.PerformLayout();
            this.groupBox_type.ResumeLayout(false);
            this.groupBox_spaceProperties.ResumeLayout(false);
            this.groupBox_spaceProperties.PerformLayout();
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
        private System.Windows.Forms.Label label_Links;
        private System.Windows.Forms.ToolStrip toolStrip1;
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
        private System.Windows.Forms.ToolStripMenuItem marioParty4binToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marioParty5binToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marioParty6binToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marioParty7BoardToolStripMenuItem;
        private System.Windows.Forms.Button btn_DeleteSpace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Rot_Z;
        private System.Windows.Forms.TextBox textBox_Rot_Y;
        private System.Windows.Forms.TextBox textBox_Rot_X;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Scale_Z;
        private System.Windows.Forms.TextBox textBox_Scale_Y;
        private System.Windows.Forms.TextBox textBox_Scale_X;
        private System.Windows.Forms.GroupBox groupBox_flags;
        private System.Windows.Forms.TextBox textBox_flag7;
        private System.Windows.Forms.TextBox textBox_flag6;
        private System.Windows.Forms.TextBox textBox_flag5;
        private System.Windows.Forms.TextBox textBox_flag4;
        private System.Windows.Forms.TextBox textBox_flag3;
        private System.Windows.Forms.TextBox textBox_flag2;
        private System.Windows.Forms.TextBox textBox_flag1;
        private System.Windows.Forms.ComboBox comboBox_PathFlag;
        private System.Windows.Forms.ComboBox comboBox_TravelFlag;
        private System.Windows.Forms.Label label_PathFlag;
        private System.Windows.Forms.Label label_TravelFlag;
        private System.Windows.Forms.GroupBox groupBox_position;
        private System.Windows.Forms.GroupBox groupBox_flagCombo;
        private System.Windows.Forms.GroupBox groupBox_rotation;
        private System.Windows.Forms.GroupBox groupBox_size;
        private System.Windows.Forms.GroupBox groupBox_type;
        private System.Windows.Forms.GroupBox groupBox_spaceProperties;
        private ToolBox toolBox;
        private System.Windows.Forms.PictureBox pictureBox_Space;
    }
}


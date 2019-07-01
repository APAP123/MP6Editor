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
    }
}

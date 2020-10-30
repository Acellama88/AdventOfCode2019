using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AoC05
{
    public partial class Form2 : Form
    {
        private decimal value = 0;
        public int Value
        {
            get { return (int)value; }
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            value = numericUpDown1.Value;
            this.Close();
        }
    }
}

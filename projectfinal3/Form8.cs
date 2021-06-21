using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectfinal3
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gun matee = new gun();
            this.Hide();
            matee.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 matee = new Form6();
            this.Hide();
            matee.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form7 matee = new Form7();
            this.Hide();
            matee.Show();
        }
    }
}

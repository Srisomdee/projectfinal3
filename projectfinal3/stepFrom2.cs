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
    public partial class stepFrom2 : Form
    {
        public stepFrom2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 matee = new Form1();
            this.Hide();
            matee.Show();
            MessageBox.Show("คุณต้องการดูรายการเพิ่มเติมกรุณากดล็อกอินเพื่อใช้งาน");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 matee = new Form5();
            this.Hide();
            matee.Show();
        }
    }
}

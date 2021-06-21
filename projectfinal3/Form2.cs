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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("คุณต้องการดูรายการเพิ่มเติมกรุณากดล็อกอินเพื่อใช้งานหรือสมัครสมาชิกใหม่");
        }
    }
}

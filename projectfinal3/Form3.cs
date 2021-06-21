using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace projectfinal3
{
    public partial class Form3 : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projectfinal2;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM member2 WHERE User = \"{usertext.Text}\" AND passwold = \"{passtext.Text}\"";
            MySqlDataReader row = cmd.ExecuteReader();

            if (row.HasRows)
            {
                Form1 a = new Form1();
                this.Hide();
                a.Show();
                MessageBox.Show("เข้าสู่ระบบสำเร็จ");

            }
            else
            {
                MessageBox.Show("ชื่อผู้ใช้ หรือ รหัสผ่านไม่ถูกต้อง");
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                string p = passtext.Text;
                passtext.PasswordChar = '\0';
            }
            else
            {
                passtext.PasswordChar = '•';
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}

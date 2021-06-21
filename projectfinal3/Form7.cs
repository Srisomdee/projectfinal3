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
    public partial class Form7 : Form
    {

        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projectfinal2;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM addminlogin WHERE User = \"{usertext.Text}\" AND passwold = \"{passtext.Text}\"";
            MySqlDataReader row = cmd.ExecuteReader();

            if (row.HasRows)
            {
                Form8 a = new Form8();
                this.Hide();
                a.Show();
                MessageBox.Show("เข้าสู่ระบบสำเร็จ");

            }
            else
            {
                MessageBox.Show("ชื่อผู้ใช้ หรือ รหัสผ่านไม่ถูกต้อง");
                usertext.Clear();
                passtext.Clear();
            }
            conn.Close();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            this.Hide();
            a.Show();
        }
    }
}

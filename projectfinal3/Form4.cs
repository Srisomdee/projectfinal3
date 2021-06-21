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
using System.IO;

namespace projectfinal3
{
    public partial class Form4 : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projectfinal2;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (User.Text != "" && passwold.Text != "" && name.Text != "" && address.Text != "" && phonenumber.Text != "" && IDcard.Text != "" )
            {
                if (passwold.Text == passwold2.Text)
                {
                    if (IDcard.TextLength < 13)
                    {
                        MessageBox.Show("กรุณากรอกเลขบัตรให้ถูกต้องให้ถูกต้อง", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        IDcard.Clear();
                    }
                    else
                    {



                        if (phonenumber.TextLength < 10)
                        {
                            MessageBox.Show("กรุณากรอกเบอร์โทรศัพท์ให้ถูกต้อง", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            phonenumber.Clear();
                        }
                        else
                        {

                            string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=projectfinal2;";
                            MySqlConnection conn = new MySqlConnection(connection);
                            byte[] image = null;
                            pictureBox1.ImageLocation = textBox1.Text;
                            string filepath = textBox1.Text;
                            FileStream f_stream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                            BinaryReader bi_read = new BinaryReader(f_stream);
                            image = bi_read.ReadBytes((int)f_stream.Length);
                            string sql = $" INSERT INTO member2 (User,password,name,address,phonenumber,IDcard,picture) VALUES(\"{User.Text}\",\"{passwold.Text}\",\"{name.Text}\",\"{ address.Text}\",\"{ phonenumber.Text}\",\"{ IDcard.Text}\",@Imgg)";
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                                MySqlCommand cmd = new MySqlCommand(sql, conn);
                                cmd.Parameters.Add(new MySqlParameter("@Imgg", image));
                                int x = cmd.ExecuteNonQuery();
                                conn.Close();
                                
                            }
                            MessageBox.Show("เพิ่มข้อมูลสำเร็จ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            User.Clear();
                            passwold.Clear();
                            passwold2.Clear();
                            name.Clear();
                            address.Clear();
                            phonenumber.Clear();
                            IDcard.Clear();
                            pictureBox1.Image=null;
                            textBox1.Clear();



                        }
                    }


                }
                else
                {
                    MessageBox.Show("กรุณาใส่รหัสผ่านให้ตรงกัน", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    passwold.Clear();
                    passwold2.Clear();
                }

            }
            else
            {
                MessageBox.Show("กรุณากรอกให้ครบทุกช่อง", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }








        }

        private void User_TextChanged(object sender, EventArgs e)
        {

        }

        private void User_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
            }
        }

        private void passwold_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
            }
        }

        private void phonenumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                MessageBox.Show("กรุณาป้อนเฉพาะตัวเลขเท่านั้น");
                e.Handled = true;
            }
        }

        private void IDcard_TextChanged(object sender, EventArgs e)
        {

        }

        private void IDcard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                MessageBox.Show("กรุณาป้อนเฉพาะตัวเลขเท่านั้น");
                e.Handled = true;
            }
        }

        private void หนาลอกอนToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 matee = new Form3();
            this.Hide();
            matee.Show();
        }

        private void เลอกซอสนคาToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 matee = new Form3();
            this.Hide();
            matee.Show();
            MessageBox.Show("กรุณาเข้าสู่ระบบ");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters
            open.Filter = "Image Files(*.jpg; *.jpeg; .png)|*.jpg; *.jpeg; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(open.FileName);
                textBox1.Text = open.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void Con_Click(object sender, EventArgs e)
        {

        }
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                string p = passwold.Text;
                passwold.PasswordChar = '\0';
            }
            else
            {
                passwold.PasswordChar = '•';
            }
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                string p = passwold2.Text;
                passwold2.PasswordChar = '\0';
            }
            else
            {
                passwold2.PasswordChar = '•';
            }
        }
    }
}


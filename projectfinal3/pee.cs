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
    public partial class pee : Form
    {


        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projectfinal2;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public pee()
        {
            InitializeComponent();
        }

        private void pee_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=projectfinal2;";
            MySqlConnection conn = new MySqlConnection(connection);
            byte[] image = null;
            pic_gun.ImageLocation = name_file.Text;
            string filepath = name_file.Text;
            FileStream f_stream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            BinaryReader bi_read = new BinaryReader(f_stream);
            image = bi_read.ReadBytes((int)f_stream.Length);
            string sql = $" INSERT INTO pee (User,password,pic_gun) VALUES(\"{User.Text}\"," + $"\"{password.Text}\",@Imgg)";

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add(new MySqlParameter("@Imgg", image));
                int x = cmd.ExecuteNonQuery();
                conn.Close();

            }
            MessageBox.Show("เพิ่มข้อมูลสำเร็จ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters
            open.Filter = "Image Files(*.jpg; *.jpeg; .png)|*.jpg; *.jpeg; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pic_gun.Image = new Bitmap(open.FileName);
                name_file.Text = open.FileName;
            }
        }
    }
}

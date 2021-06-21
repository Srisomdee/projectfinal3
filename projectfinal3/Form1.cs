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
    public partial class Form1 : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projectfinal2;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        private void showugundata()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id,Namegun,Category,pic_gun FROM detail_gun";
            //cmd.CommandText = "SELECT * FROM detail_gun";


            MySqlDataAdapter adpter = new MySqlDataAdapter(cmd);
            adpter.Fill(ds);

            conn.Close();


            gun_shopGridView1.DataSource = ds.Tables[0].DefaultView;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void หนาแรกToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showugundata();
        }

        private void เขาสระบบToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 matee = new Form3();
            this.Hide();
            matee.Show();
        }

        private void สมครสมาชกToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 matee = new Form4();
            this.Hide();
            matee.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            stepFrom2 matee = new stepFrom2();
            this.Hide();
            matee.Show();
        }

        

        private void addminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 matee = new Form7();
            this.Hide();
            matee.Show();
        }

        private void ออกจากระบบToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void gun_shopGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void gun_shopGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                gun_shopGridView1.CurrentRow.Selected = true;
                int selectedRows = gun_shopGridView1.CurrentCell.RowIndex;
                int show_p = Convert.ToInt32(gun_shopGridView1.Rows[selectedRows].Cells["id"].Value);




                string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=projectfinal2;";
                MySqlConnection conn = new MySqlConnection(connection);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT pic_gun FROM detail_gun WHERE id = \"{ show_p }\"", conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["pic_gun"]);
                    pictureBox3.Image = new Bitmap(ms);
                }

            }
            catch (Exception)
            {

            }
        }
        private void name_gun()
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM detail_gun ";


            MySqlDataReader row = cmd.ExecuteReader();
            //String name = username.Text;
            row.Read();
        }

        private void gun_shopGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ปืนสั้น")
            {
                MySqlConnection conn = databaseConnection();
                DataSet ds = new DataSet();
                conn.Open();

                MySqlCommand cmd;

                string name = "ปืนสั้น";
                cmd = conn.CreateCommand();
                cmd.CommandText = $"SELECT id,Namegun,Category,pic_gun FROM detail_gun WHERE Category = \"{name}\" ";

                MySqlDataAdapter adpter = new MySqlDataAdapter(cmd);
                adpter.Fill(ds);

                conn.Close();

                gun_shopGridView1.DataSource = ds.Tables[0].DefaultView;
            }
            else
            {
                MySqlConnection conn = databaseConnection();
                DataSet ds = new DataSet();
                conn.Open();

                MySqlCommand cmd;

                string name = "ปืนลูกซอง";
                cmd = conn.CreateCommand();
                cmd.CommandText = $"SELECT id,Namegun,Category,pic_gun FROM detail_gun WHERE Category = \"{name}\" ";

                MySqlDataAdapter adpter = new MySqlDataAdapter(cmd);
                adpter.Fill(ds);

                conn.Close();

                gun_shopGridView1.DataSource = ds.Tables[0].DefaultView;
            }
        }
    }
}

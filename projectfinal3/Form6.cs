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
    
    public partial class Form6 : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projectfinal2;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void showuserdata()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM member2";

            MySqlDataAdapter adpter = new MySqlDataAdapter(cmd);
            adpter.Fill(ds);

            conn.Close();


            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            showuserdata();
        }

        

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void userGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1.CurrentRow.Selected = true;
                int selectedRows = dataGridView1.CurrentCell.RowIndex;
                int show_p = Convert.ToInt32(dataGridView1.Rows[selectedRows].Cells["id"].Value);

                string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=projectfinal2;";
                MySqlConnection conn = new MySqlConnection(connection);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT picture FROM member2 WHERE id = \"{ show_p }\"", conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["picture"]);
                    samnao.Image = new Bitmap(ms);
                }

            }
            catch (Exception)
            {

            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form8 matee = new Form8();
            this.Hide();
            matee.Show();
        }
    }
}

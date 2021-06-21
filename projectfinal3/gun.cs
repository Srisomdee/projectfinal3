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
    public partial class gun : Form
    {

        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projectfinal2;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public gun()
        {
            InitializeComponent();
        }

        private void show_gun()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM detail_gun";
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            adap.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void gun_Load(object sender, EventArgs e)
        {
            show_gun();
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
            string sql = $" INSERT INTO detail_gun (Namegun,Category,type,brand,Price,Amount,details,Total_length,Barrel_length,Weight,security_system,trigger_system,bullet_size,Packing,center,gun_shape,pistol_grip,pic_gun) VALUES(\"{Namegun.Text}\"," +$"\"{Category.Text}\",\"{type.Text}\",\"{ price.Text}\",\"{ amount.Text}\",\"{ brand.Text}\",\"{ details.Text}\",\"{ Total_length.Text}\",\"{ Barrel_length.Text}\",\"{ Weight.Text}\"" +$",\"{ security_system.Text}\",\"{ trigger_system.Text}\",\"{ bullet_size.Text}\",\"{ Packing.Text}\"," +$"\"{ center.Text}\",\"{ gun_shape.Text}\",\"{ pistol_grip.Text}\",@Imgg)";
            
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add(new MySqlParameter("@Imgg", image));
                int x = cmd.ExecuteNonQuery();
                conn.Close();

            }
            MessageBox.Show("เพิ่มข้อมูลสำเร็จ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Namegun.Clear();
            Category.Clear();
            type.Clear();
            price.Clear();
            amount.Clear();
            brand.Clear();
            details.Clear();
            Total_length.Clear();
            Barrel_length.Clear();
            Weight.Clear();
            security_system.Clear();
            trigger_system.Clear();
            bullet_size.Clear();
            Packing.Clear();
            center.Clear();
            gun_shape.Clear();
            pistol_grip.Clear();
            name_file.Clear();
            pic_gun.Image = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters
            open.Filter = "Image Files(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pic_gun.Image = new Bitmap(open.FileName);
                name_file.Text = open.FileName;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            this.Hide();
            a.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form8 a = new Form8();
            this.Hide();
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridView1.CurrentCell.RowIndex;
            int deleteId = Convert.ToInt32(dataGridView1.Rows[selectedRow].Cells["id"].Value);

            MySqlConnection conn = databaseConnection();

            String sql = "DELETE FROM detail_gun WHERE id = '" + deleteId + "'";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();

            int rows = cmd.ExecuteNonQuery();

            conn.Close();

            if (rows > 0)
            {
                show_gun();
                MessageBox.Show("ลบข้อมูลสำเร็จ");

            }

            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1.CurrentRow.Selected = true;
                int selectedRows = dataGridView1.CurrentCell.RowIndex;
                int show_p = Convert.ToInt32(dataGridView1.Rows[selectedRows].Cells["id"].Value);

                Namegun.Text = dataGridView1.Rows[e.RowIndex].Cells["Namegun"].FormattedValue.ToString();
                Category.Text = dataGridView1.Rows[e.RowIndex].Cells["Category"].FormattedValue.ToString();
                type.Text = dataGridView1.Rows[e.RowIndex].Cells["type"].FormattedValue.ToString();
                brand.Text = dataGridView1.Rows[e.RowIndex].Cells["brand"].FormattedValue.ToString();
                price.Text = dataGridView1.Rows[e.RowIndex].Cells["Price"].FormattedValue.ToString();
                amount.Text = dataGridView1.Rows[e.RowIndex].Cells["Amount"].FormattedValue.ToString();
                details.Text = dataGridView1.Rows[e.RowIndex].Cells["details"].FormattedValue.ToString();
                Total_length.Text = dataGridView1.Rows[e.RowIndex].Cells["Total_length"].FormattedValue.ToString();
                Barrel_length.Text = dataGridView1.Rows[e.RowIndex].Cells["Barrel_length"].FormattedValue.ToString();
                Weight.Text = dataGridView1.Rows[e.RowIndex].Cells["Weight"].FormattedValue.ToString();
                security_system.Text = dataGridView1.Rows[e.RowIndex].Cells["security_system"].FormattedValue.ToString();
                trigger_system.Text = dataGridView1.Rows[e.RowIndex].Cells["trigger_system"].FormattedValue.ToString();
                Packing.Text = dataGridView1.Rows[e.RowIndex].Cells["Packing"].FormattedValue.ToString();
                center.Text = dataGridView1.Rows[e.RowIndex].Cells["center"].FormattedValue.ToString();
                gun_shape.Text = dataGridView1.Rows[e.RowIndex].Cells["gun_shape"].FormattedValue.ToString();
                pistol_grip.Text = dataGridView1.Rows[e.RowIndex].Cells["pistol_grip"].FormattedValue.ToString();

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
                    pic_gun.Image = new Bitmap(ms);
                }
            }
            catch(Exception){}

            



        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int selectedRow = dataGridView1.CurrentCell.RowIndex;
            int editId = Convert.ToInt32(dataGridView1.Rows[selectedRow].Cells["id"].Value);

            MySqlConnection conn = databaseConnection();
            byte[] image = null;
            string filepath = name_file.Text;
            FileStream f_stream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            BinaryReader bi_read = new BinaryReader(f_stream);
            image = bi_read.ReadBytes((int)f_stream.Length);
            String sql = "UPDATE detail_gun SET Namegun ='" + Namegun.Text + "',Category = '" + Category.Text + "',type ='" + type.Text + "', brand ='" + brand.Text + "',price ='" + price.Text + "',Amount ='" + amount.Text + "',details ='" + details.Text + "',Total_length ='" + Total_length.Text + "',Barrel_length ='" + Barrel_length.Text + "',Weight ='" + Weight.Text + "',trigger_system ='" + trigger_system.Text + "',Packing ='" + Packing.Text + "',center ='" + center.Text + "',gun_shape ='" + gun_shape.Text + "',pistol_grip ='" + pistol_grip.Text + "',pic_gun= @Imgg WHERE id = '" + editId + "'";
             
            MySqlCommand cmd = new MySqlCommand(sql, conn);


            conn.Open();
            cmd.Parameters.Add(new MySqlParameter("@Imgg", image));
            int rows = cmd.ExecuteNonQuery();

            conn.Close();

            if (rows > 0)
            {
                MessageBox.Show("แก้ไขข้อมูลสำเร็จ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                show_gun();
                


            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Namegun.Clear();
            Category.Clear();
            type.Clear();
            price.Clear();
            amount.Clear();
            brand.Clear();
            details.Clear();
            Total_length.Clear();
            Barrel_length.Clear();
            Weight.Clear();
            security_system.Clear();
            trigger_system.Clear();
            bullet_size.Clear();
            Packing.Clear();
            center.Clear();
            gun_shape.Clear();
            pistol_grip.Clear();
            name_file.Clear();
            pic_gun.Image = null;
        }
    }
}

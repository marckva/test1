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

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Ааод строки для подключения к Базе данных
        /// </summary>
        string str = "server = localhost; user = root; password = Majart_420; database = test; port = 3306";
        public Form1()
        {
            MySqlConnection connection = new MySqlConnection(str);
            InitializeComponent();
            connection.Open();
            string sql = "Select * from agent";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql,connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connection.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int j=0; j<dataGridView1.ColumnCount;j++)
            {
                comboBox2.Items.Add(dataGridView1.Columns[j].HeaderText);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            MySqlConnection connection = new MySqlConnection(str);
            try 
            {
                connection.Open();
                string sql = "Select * from `"+comboBox1.Text+"`";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            for (int j = 0; j < dataGridView1.ColumnCount; j++)
            {
                comboBox2.Items.Add(dataGridView1.Columns[j].HeaderText);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(str);
            try
            {
                connection.Open();
                string sql = "Select * from `" + comboBox1.Text+ "` where(`"+comboBox2.Text+"` like'"+textBox1.Text + "%');";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                connection.Close();
            }
            catch 
            {
                MessageBox.Show("ощибка ","нет данных",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Autorisation form = new Autorisation();
            form.Show();
            this.Hide();
        }
    }
}

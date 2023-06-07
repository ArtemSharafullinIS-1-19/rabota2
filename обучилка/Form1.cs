using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace обучилка
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("host = 127.0.0.1; port = 3306; password =; user = root; database = obuch");

            string login = textBox1.Text;
            string pass = textBox2.Text;

            string запрос = $"Select count(*) from Users where login = '{login}' and pass = '{pass}'";
            connection.Open();
            MySqlCommand command = new MySqlCommand(запрос, connection);
            int count = Convert.ToInt32(command.ExecuteScalar());
            if (count > 0)
            {
                MessageBox.Show("привет");
                Form2 form2 = new Form2();
                form2.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("пока");
            }
            connection.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
            MySqlConnection connection = new MySqlConnection("host = 127.0.0.1; port = 3306; password =; user = root; database = obuch");
            string sha256(string ввод) => string.Concat(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(ввод)).Select(item => item.ToString("x2")));

        private void button1_Click(object sender, EventArgs e)
        {

            string запрос = $"Select count(*) from Users where login = '{textBox1.Text}' and pass = '{sha256(textBox2.Text)}'";
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

        private void button2_Click(object sender, EventArgs e)
        {
            string запрос = $"insert into Users (login, pass)" + $"values ('{textBox1.Text}', '{sha256(textBox2.Text)}')";

            MySqlCommand command = new MySqlCommand(запрос, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("зарегался");
        }
    }

}

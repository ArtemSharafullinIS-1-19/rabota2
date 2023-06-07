using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace обучилка
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Загрузи()
        {
            using (MySqlConnection connection = new MySqlConnection("host = 127.0.0.1; port = 3306; password =; user = root; database = obuch"))
            {
                connection.Open();
                // Формируем запрос на выборку данных о сотрудниках
                string запрос = "SELECT * from Tovar";

                // Создаем команду для выполнения запроса
                MySqlCommand command = new MySqlCommand(запрос, connection);
                // Создаем адаптер для получения данных и заполняем таблицу DataGridView
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Загрузи();
        }
    }
}

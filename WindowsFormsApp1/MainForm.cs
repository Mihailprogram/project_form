using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        static String connection = Properties.Settings.Default.pgConnection;

        NpgsqlConnection cnct = new NpgsqlConnection(connection);
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string NameProduct = '%'+ NameprodBox1.Text + '%';
            try
            {
                //NpgsqlCommand cmd = new NpgsqlCommand("SELECT productname,\"productcategory \"  ,productdescription,productcost,productmaxdiscountamount,productmanufacturer,productsupplier FROM champ.product\r\nWHERE product.productname = @NameProduct");
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM champ.selectproduct(@NameProduct)");
                cmd.Parameters.AddWithValue("@NameProduct", NameProduct);
                
               // cnct.Open();
                cmd.Connection = cnct;
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
             //   cnct.Close();
            }
            catch (Exception ex)
            {
              MessageBox.Show("Ошибка " + ex.Message);
            }
        }
        public int userole;
        public int userId;
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            
            cnct.Open();
            if (userole == 1)
            {
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;

            }
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT productarticlenumber AS \"Артикул\",productname AS \"Имя товара\",productcategory AS \"Категория товара\",productdescription AS \"Описание\",productcost AS \"Цена\",productmaxdiscountamount AS \"Максимальная скидка\",productmanufacturer AS \"Производитель\",productsupplier AS \"Поставщик\",productdiscountamount AS \"Скидка\",productquantityinstock AS \"Количество на складе\",productphoto AS \"Изображение\" FROM champ.product");
            cmd.Connection = cnct;
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Context == DataGridViewDataErrorContexts.Formatting)
            {
                // Эта ошибка связана с форматированием данных. 
                // Мы можем установить значение по умолчанию (например, пустое изображение).
                e.ThrowException = false;
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = new Bitmap(1, 1); // Пустое изображение.
            }
            else
            {
                // Другие типы ошибок могут потребовать другой обработки, в зависимости от вашей логики.
                // Здесь вы можете добавить дополнительные действия по обработке.
                e.ThrowException = true; // Можно оставить исключение.
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridView1.DataError += dataGridView1_DataError;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT productarticlenumber AS \"Артикул\",productname AS \"Имя товара\",productcategory AS \"Категория товара\",productdescription AS \"Описание\",productcost AS \"Цена\",productmaxdiscountamount AS \"Максимальная скидка\",productmanufacturer AS \"Производитель\",productsupplier AS \"Поставщик\",productdiscountamount AS \"Скидка\",productquantityinstock AS \"Количество на складе\",productphoto AS \"Изображение\" FROM champ.product");
            cmd.Connection = cnct;
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            INSERTForm iNSERTForm = new INSERTForm();
            iNSERTForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //DeleteForm deleteForm = new DeleteForm();
            //deleteForm.Show();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Получаем выбранную строку
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Получаем данные из выбранной строки
                string artick = selectedRow.Cells["Артикул"].Value.ToString();
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить товар?",
                    "Сообщение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM champ.product WHERE productarticlenumber = @IDProduct", cnct);
                        cmd.Parameters.AddWithValue("@IDProduct", artick);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Успешно");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку в таблице для удаление данных.");
            }
        }   

        private void button5_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Получаем выбранную строку
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Получаем данные из выбранной строки
                string data1 = selectedRow.Cells["Артикул"].Value.ToString();
                string data2 = selectedRow.Cells["Имя товара"].Value.ToString();
                string data3 = selectedRow.Cells["Категория товара"].Value.ToString();
                string data4 = selectedRow.Cells["Описание"].Value.ToString();
                string data5 = selectedRow.Cells["Цена"].Value.ToString();
                string data6 = selectedRow.Cells["Максимальная скидка"].Value.ToString();
                string data7 = selectedRow.Cells["Производитель"].Value.ToString();
                string data8 = selectedRow.Cells["Поставщик"].Value.ToString();
                string data9 = selectedRow.Cells["Скидка"].Value.ToString();
                string data10 = selectedRow.Cells["Количество на складе"].Value.ToString();
                byte[] imageBytes = selectedRow.Cells["Изображение"].Value as byte[];


                //AS \"Изображение\"

                // и так далее для других данных

                // Создаем новую форму
                UpdateForm updateForm = new UpdateForm();

                // Передаем данные на вторую форму, используя методы или свойства второй формы
                updateForm.SetData(data1, data2, data3, data4, data5, data6, data7, data8, data9, data10, imageBytes);

                // Показываем вторую форму
                updateForm.Show();

            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку в таблице для обновления данных.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();

            //Application.OpenForms["AuthorizationFrom"].Close();
            AuthorizationFrom authForm = (AuthorizationFrom)Application.OpenForms["AuthorizationFrom"];

            if (authForm != null)
            {
                authForm.ClearTextFields();

                authForm.Show();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //userId;
            
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                string artick = selectedRow.Cells["Артикул"].Value.ToString();
                Order order = new Order();
                
                order.artik = artick;
                order.userIdord = userId;
                order.Show();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку в таблице для создания заказа.");
            }
        }
    }
}

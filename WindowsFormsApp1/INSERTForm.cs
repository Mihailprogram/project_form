using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class INSERTForm : Form
    {
        static String connection = Properties.Settings.Default.pgConnection;

        NpgsqlConnection cnct = new NpgsqlConnection(connection);
        public INSERTForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MemoryStream memoryStream = new MemoryStream();
            pictureBox1.Image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            byte[] imageBytes = memoryStream.ToArray();

            string ProductName = NametextBox.Text;
            string IDProduct = IDtextBox.Text;
            int CostProduct = Convert.ToInt32(CosttextBox.Text);
            string CategoryProdutct = CategorytextBox.Text;
            int MaxProduct = Convert.ToInt32(MaxtdisextBox.Text);
            string ManufacturProduct = ManuftextBox.Text;
            string SuppliertProduct = SuppliertextBox.Text;
            int DiscontProduct = Convert.ToInt32(DisconttextBox.Text);
            int CountProduct = Convert.ToInt32(CounttextBox.Text);
            string DescriptionProduct = DescriptiontextBox.Text;
            string product = "шт.";

            try
            {
     
                NpgsqlCommand cmd = new NpgsqlCommand("CALL  champ.insert_products(" +
                    "@productarticlenumber,@productname,@productunitmeasurement," +
                    "@cost,@maxdiscount,@manufactur,@supplier," +
                    "@discount, @count,@description, @category,@image)", cnct);
                
                cmd.Parameters.Add(new NpgsqlParameter("@productarticlenumber", NpgsqlDbType.Varchar)).Value = IDProduct;
                cmd.Parameters.Add(new NpgsqlParameter("@productname", NpgsqlDbType.Text)).Value = ProductName;
                cmd.Parameters.Add(new NpgsqlParameter("@productunitmeasurement", NpgsqlDbType.Text)).Value = product;
                cmd.Parameters.Add(new NpgsqlParameter("@cost", NpgsqlDbType.Numeric)).Value = CostProduct;
                cmd.Parameters.Add(new NpgsqlParameter("@maxdiscount", NpgsqlDbType.Smallint)).Value = MaxProduct;
                cmd.Parameters.Add(new NpgsqlParameter("@manufactur", NpgsqlDbType.Varchar)).Value = ManufacturProduct;
                cmd.Parameters.Add(new NpgsqlParameter("@supplier", NpgsqlDbType.Text)).Value = SuppliertProduct;
                cmd.Parameters.Add(new NpgsqlParameter("@discount", NpgsqlDbType.Smallint)).Value = DiscontProduct;
                cmd.Parameters.Add(new NpgsqlParameter("@count", NpgsqlDbType.Integer)).Value = CountProduct;
                cmd.Parameters.Add(new NpgsqlParameter("@description", NpgsqlDbType.Text)).Value = DescriptionProduct;
                cmd.Parameters.Add(new NpgsqlParameter("@category", NpgsqlDbType.Varchar)).Value = CategoryProdutct;
                cmd.Parameters.Add(new NpgsqlParameter("@image", NpgsqlDbType.Bytea)).Value = imageBytes;
                cmd.ExecuteNonQuery();


                MessageBox.Show("Данные успешно добавлены.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string IDProduct = IDtextBox.Text;
            if (string.IsNullOrEmpty(IDProduct))
            {
                MessageBox.Show("Внесите данные");
            }
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM champ.product WHERE productarticlenumber = @IDProduct",cnct);
                cmd.Parameters.AddWithValue("@IDProduct", IDProduct);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Успешно");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message);
            }
        }

        private void INSERTForm_Load(object sender, EventArgs e)
        {
            cnct.Open();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;

                // Здесь вы можете отобразить изображение на PictureBox, если нужно.
                pictureBox1.Image = new Bitmap(imagePath);

                // Сохраните путь к файлу в переменной или, при необходимости, переведите его в бинарные данные.
            }
        }
    }
}

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
    public partial class UpdateForm : Form
    {
        static String connection = Properties.Settings.Default.pgConnection;

        NpgsqlConnection cnct = new NpgsqlConnection(connection);
        public UpdateForm()
        {
            InitializeComponent();
        }
        public void SetData(string data1, string data2, 
            string data3, string data4, 
            string data5, string data6, 
            string data7, string data8, string data9, string data10,
            byte[] imageBytes)
        {
            IDtextBox.Text = data1;
            NametextBox.Text = data2;
            CategorytextBox.Text = data3;
            DescriptiontextBox.Text = data4;
            CosttextBox.Text = data5;//
            MaxtdisextBox.Text = data6;//
            ManuftextBox.Text = data7;
            SuppliertextBox.Text = data8;
            DisconttextBox.Text = data9;//
            CounttextBox.Text = data10;//

            if (imageBytes != null && imageBytes.Length > 0)
            {
                using (MemoryStream stream = new MemoryStream(imageBytes))
                {
                    pictureBox1.Image = Image.FromStream(stream);
                }
            }

            // и так далее для других TextBox на второй форме
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MemoryStream memoryStream = new MemoryStream();
            pictureBox1.Image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            byte[] imageBytes = memoryStream.ToArray();

            string ProductName = NametextBox.Text;
            string IDProduct = IDtextBox.Text;
            decimal CostProduct = decimal.Parse(CosttextBox.Text);
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

                NpgsqlCommand cmd = new NpgsqlCommand("CALL  champ.update_products(" +
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


                MessageBox.Show("Данные успешно обновлены.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message);
            }
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            cnct.Open();
        }

        private void IDtextBox_TextChanged(object sender, EventArgs e)
        {
            IDtextBox.ReadOnly = true;
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

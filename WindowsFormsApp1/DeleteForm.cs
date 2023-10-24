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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class DeleteForm : Form
    {
        static String connection = Properties.Settings.Default.pgConnection;

        NpgsqlConnection cnct = new NpgsqlConnection(connection);
        public DeleteForm()
        {
            InitializeComponent();
        }
        public string Artikl;
        private void button1_Click(object sender, EventArgs e)
        {
            string IDProduct = IDtextBox.Text;
            if (string.IsNullOrEmpty(IDProduct))
            {
                MessageBox.Show("Внесите данные");
            }
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM champ.product WHERE productarticlenumber = @IDProduct", cnct);
                cmd.Parameters.AddWithValue("@IDProduct", IDProduct);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Успешно");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message);
            }
        }

        private void DeleteForm_Load(object sender, EventArgs e)
        {
            cnct.Open();
        }
    }
}

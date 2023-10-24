using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class RegistrationForm : Form
    {
        static String connection = Properties.Settings.Default.pgConnection;

        NpgsqlConnection cnct = new NpgsqlConnection(connection);
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;
            string patronymic = textBox3.Text;
            string login = textBox4.Text;
            string password = textBox5.Text;
            try
            {
                cnct.Open();
                string sql = "CALL champ.autif(@usersurname,@username,@patronymic,@userlogin,@userpassword)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, cnct);
                

                cmd.Parameters.Add(new NpgsqlParameter("@username", NpgsqlDbType.Varchar)).Value = name;
                cmd.Parameters.Add(new NpgsqlParameter("@usersurname", NpgsqlDbType.Varchar)).Value = surname;
                cmd.Parameters.Add(new NpgsqlParameter("@patronymic", NpgsqlDbType.Varchar)).Value = patronymic;
                cmd.Parameters.Add(new NpgsqlParameter("@userlogin", NpgsqlDbType.Text)).Value = login;
                cmd.Parameters.Add(new NpgsqlParameter("@userpassword", NpgsqlDbType.Text)).Value = password;




                cmd.ExecuteNonQuery();
                MessageBox.Show("Успешно");
                this.Close();
                cnct.Close();
                Application.OpenForms["AuthorizationFrom"].Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message);
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.PasswordChar = '•';
        }
    }
}

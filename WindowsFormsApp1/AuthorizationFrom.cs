using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class AuthorizationFrom : Form
    {
        static String connection = Properties.Settings.Default.pgConnection;

        NpgsqlConnection cnct = new NpgsqlConnection(connection);
        public AuthorizationFrom()
        {
            InitializeComponent();
            LoadCaptcha();

        }
        int num = 0;
        bool flag = false;
        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void ClearTextFields()
        {
            // Очищаем текстовые поля
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (cnct.State == ConnectionState.Closed)
                    cnct.Open();


            }
            catch (Exception ex)


            {
                MessageBox.Show(ex.Message);

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            this.Hide();
            registrationForm.Show();
        }

        //public event Action<int> UserLoggedIn;
        private void button1_Click(object sender, EventArgs e)
        {
            if (flag == true)
            {
                string login = textBox1.Text;
                string password = textBox2.Text;
                try
                {
                    string sql = "SELECT userrole FROM champ.user " +
                        "WHERE userlogin = @login and userpassword = @password";
                    string sqlid = "SELECT userid FROM champ.user " +
                        "WHERE userlogin = @login and userpassword = @password";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, cnct);
                    NpgsqlCommand cmdid = new NpgsqlCommand(sqlid, cnct);

                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", password);

                    cmdid.Parameters.AddWithValue("@login", login);
                    cmdid.Parameters.AddWithValue("@password", password);

                    object result = cmd.ExecuteScalar();
                    int count = Convert.ToInt32(result);

                    object resultid = cmdid.ExecuteScalar();
                    int countid = Convert.ToInt32(resultid);
                    MainForm mainForm = new MainForm();

                    if (count > 0)
                    {


                        mainForm.userole = count;
                        mainForm.userId = countid;
                        this.Hide();
                        mainForm.Show();



                    }
                    else
                    {
                        // Пользователь не найден или пароль не совпадает
                        MessageBox.Show("Неверное имя пользователя или пароль.");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Пройдите капчу");
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '•';
        }
        private void LoadCaptcha()
        {
            //throw new NotImplementedException();
            Random r1 = new Random();
            num = r1.Next(100, 999);
            var img = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            var font = new Font("Arial", 30, FontStyle.Bold, GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(img);
            graphics.DrawString(num.ToString(), font, Brushes.Red, new Point(0, 0));
            pictureBox1.Image = img;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if  (textBox3.Text == num.ToString())
            {
                flag = true;
                MessageBox.Show("Ввод верный");
            }
            else
            {
                MessageBox.Show("Ввод неверный");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadCaptcha();

        }
    }
}

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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Order : Form
    {
        static String connection = Properties.Settings.Default.pgConnection;

        NpgsqlConnection cnct = new NpgsqlConnection(connection);
        public Order()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxPick.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public string artik;
        public int userIdord;
        public int Idpik;

        private void Order_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(userIdord.ToString());
            cnct.Open();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT pickuppointid,pickuppointid,pickuppointcity,pickuppointstreet,pickuppointnumber FROM champ.pickuppoint", cnct);
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string id = reader["pickuppointid"].ToString();

                        string pickuppointcity = reader["pickuppointcity"].ToString();
                        string pickuppointstreet = reader["pickuppointstreet"].ToString();
                        string pickuppointnumber = reader["pickuppointnumber"].ToString();
                        string new_str = pickuppointcity + " " + pickuppointstreet + " " + pickuppointnumber + "                                                   " + id;
                        // Добавляем виды спорта из таблицы в ComboBox
                        comboBoxPick.Items.Add(new_str);

                        //comboBox1.Items.Add(reader["pickuppointstreet"].ToString());

                    }
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message);
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            DateTime now3 = DateTime.Now;
            now3 = now3.AddDays(3);
            string pick = comboBoxPick.Text;
            string [] maspick = pick.Split(' ');
            string orderstatus = "Новый";
            int idpick = (int)Convert.ToUInt64(maspick.Last());
            


            
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO champ.order (orderdate, orderdeliverydate, orderpickuppoint, orderuser, orderstatus)   " +
                " VALUES (@orderdate,@orderdeliverydate,@orderpickuppoint,@orderuser,@orderstatus)", cnct);
                cmd.Parameters.Add(new NpgsqlParameter("@orderuser", NpgsqlDbType.Integer)).Value = userIdord;
                cmd.Parameters.Add(new NpgsqlParameter("@orderpickuppoint",NpgsqlDbType.Integer)).Value = idpick;
                cmd.Parameters.Add(new NpgsqlParameter("@orderstatus", NpgsqlDbType.Varchar)).Value = orderstatus;
                cmd.Parameters.Add(new NpgsqlParameter("@orderdeliverydate", NpgsqlDbType.Date)).Value = now3;
                cmd.Parameters.Add(new NpgsqlParameter("@orderdate", NpgsqlDbType.Date)).Value = now;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Заказ сформирован!");
                this.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message);
            }
            
        }
    }
}

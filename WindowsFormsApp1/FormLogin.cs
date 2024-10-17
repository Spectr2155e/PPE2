using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Database;

namespace WindowsFormsApp1
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*string strsql = "select c.Nom as 'Nom CPU'," +
                    " m.Nom as 'nom marque', mo.Nom as 'nom modèle'" +
                    " from dbo.CPU c join dbo.Marque m on" +
                    " c.ID_Marque = m.ID_MARQUE join dbo.Modele mo " +
                    "on c.ID_Modele = mo.ID_MODELE";
            SqlDataReader rd = Program.databaseManager.getResultOfRequest(strsql);

            while(rd.Read() == true)
            {
                MessageBox.Show(rd["Nom CPU"].ToString());

                listBox1.Items.Add(rd["Nom CPU"].ToString());
            }*/

            string name = "Spectr2155e";
            string sql = "select * from Users WHERE USER_NAME = '"+name+"'";
            MySqlDataReader rd = Program.databaseManager.getResultOfRequest(sql);

            MessageBox.Show(Utils.Utils.sha256_hash(textBoxLoginPassword.Text));

            while(rd.Read() == true)
            {
                MessageBox.Show(rd["USER_PASSWORD"].ToString());
            }
            rd.Close();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAccueil form = new FormAccueil();
            form.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxLoginPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Green;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor= SystemColors.Control;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}

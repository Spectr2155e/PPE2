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
    }
}

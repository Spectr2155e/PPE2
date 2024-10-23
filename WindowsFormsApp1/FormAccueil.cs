using MySql.Data.MySqlClient;
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
    public partial class FormAccueil : Form
    {
        public FormAccueil()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fichierToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateItems();
        }

        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            string id = listView1.SelectedItems[0].SubItems[5].Text;
            string sql = string.Format("DELETE from items WHERE ID = '{0}'", id);
            Program.databaseManager.executeRequest(sql);
            updateItems();
        }

        private void FormAccueil_Load(object sender, EventArgs e)
        {
            updateItems();
            Console.Write(getCategoryFromId(Program.currentUser.Organisation) + "t");
            label1.Text = string.Format("Bienvenue {0}, vous êtes actuellement connecté sur la base de l'organisation {1}" +
                "\n\nN'hésitez pas à contacter un administrateur si vous avez besoin d'aide.", 
                Program.currentUser.Mail, getCategoryFromId(Program.currentUser.Organisation));
        }

        private void updateItems()
        {
            listView1.Items.Clear();
            string sql = string.Format("select items.ID, items.NAME as ITEM_NAME, QUANTITY, WEIGHT, categories.NAME as CATEGORY_NAME, ADDING_DATE from items join categories on items.CATEGORY_ID = categories.ID WHERE ORGANISATION_ID = {0}", Program.currentUser.Organisation);
            MySqlDataReader reader = Program.databaseManager.getResultOfRequest(sql);

            while (reader.Read() == true)
            {
                string[] args = { reader["ITEM_NAME"].ToString(), reader["QUANTITY"].ToString(), reader["WEIGHT"].ToString() + " kg", reader["CATEGORY_NAME"].ToString(), reader["ADDING_DATE"].ToString(), reader["ID"].ToString() };
                listView1.Items.Add(new ListViewItem(args));
            }
            reader.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormAddItem formAddItem = new FormAddItem();
            this.Hide();
            formAddItem.ShowDialog();
            this.Close();
        }

        private string getCategoryFromId(string id)
        {
            string sql = string.Format("select * from organisations WHERE ID = '{0}'", id);
            MySqlDataReader reader = Program.databaseManager.getResultOfRequest(sql);

            while (reader.Read() == true)
            {
                string name = reader["NAME"].ToString();
                reader.Close();
                return name;
            }
            reader.Close();
            return null;
        }

        private void seDéconnecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            this.Hide();
            formLogin.ShowDialog();
            this.Close();
        }
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Objects;
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace WindowsFormsApp1
{
    public partial class FormAccueil : Form
    {
        public FormAccueil()
        {
            InitializeComponent();
        }

        // Actualise la list View.
        private void buttonActualiser_Click(object sender, EventArgs e)
        {
            updateItems();
        }

        // Supprimer l'item sélectionné dans la list View.
        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            string id = listView1.SelectedItems[0].SubItems[5].Text;
            string sql = "DELETE from items WHERE ID = @id";

            MySqlCommand command = new MySqlCommand(sql, Program.databaseManager.getConnection());
            command.Parameters.AddWithValue("id", id);

            command.ExecuteNonQuery();
            updateItems();
        }

        // Lancement de la Form Accueil
        private void FormAccueil_Load(object sender, EventArgs e)
        {
            updateItems();
            Console.Write(getCategoryFromId(Program.currentUser.Organisation) + "t");
            labelMain.Text = string.Format("Bienvenue {0}, vous êtes actuellement connecté sur la base de l'organisation {1}" +
                "\n\nN'hésitez pas à contacter un administrateur si vous avez besoin d'aide.",
                Program.currentUser.Mail, getCategoryFromId(Program.currentUser.Organisation));
        }

        private void updateItems()
        {
            listView1.Items.Clear();
            string sql = "select items.ID, items.NAME as ITEM_NAME, QUANTITY, WEIGHT, categories.NAME as CATEGORY_NAME, ADDING_DATE from items join categories on items.CATEGORY_ID = categories.ID WHERE ORGANISATION_ID = @organisation";

            MySqlCommand command = new MySqlCommand(sql, Program.databaseManager.getConnection());
            command.Parameters.AddWithValue("organisation", Program.currentUser.Organisation);
            
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read() == true)
            {
                string[] args = { reader["ITEM_NAME"].ToString(), reader["QUANTITY"].ToString(), reader["WEIGHT"].ToString() + " kg", reader["CATEGORY_NAME"].ToString(), reader["ADDING_DATE"].ToString(), reader["ID"].ToString() };
                listView1.Items.Add(new ListViewItem(args));
            }
            reader.Close();
        }

        // Ouvre la form pour ajouter des items
        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            FormAddItem formAddItem = new FormAddItem();
            this.Hide();
            formAddItem.ShowDialog();
            this.Close();
        }

        // Récupére le nom de la categorie grâce à l'id
        private string getCategoryFromId(int id)
        {
            string sql = "select * from organisations WHERE ID = @id";

            MySqlCommand command = new MySqlCommand(sql, Program.databaseManager.getConnection());
            command.Parameters.AddWithValue("id", id.ToString());

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read() == true)
            {
                string name = reader["NAME"].ToString();
                reader.Close();
                return name;
            }
            reader.Close();
            return null;
        }

        // Se déconnecte de l'application
        private void seDéconnecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            this.Hide();
            formLogin.ShowDialog();
            this.Close();
        }

        // Ouvre le panneau d'information de l'utilisateur
        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUserInformations formUserInformations = new FormUserInformations();
            this.Hide();
            formUserInformations.ShowDialog();
            this.Close();
        }

        // Ouvre la gestion des utilisateurs
        private void gérerLesUtilisateursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "select * from organisations WHERE ID = @id";

            MySqlCommand command2 = new MySqlCommand(sql, Program.databaseManager.getConnection());
            command2.Parameters.AddWithValue("id", Program.currentUser.Organisation);

            MySqlDataReader reader = command2.ExecuteReader();

            while(reader.Read() == true)
            {
                if (Int32.Parse(reader["PERMISSION_LEVEL"].ToString()) >= 3)
                {
                    reader.Close();
                    FormUsers formUsers = new FormUsers();
                    this.Hide();
                    formUsers.ShowDialog();
                    this.Close();
                    return;
                }
                MessageBox.Show("Vous n'avez pas la permission d'ouvrir la gestion d'utilisateur",
                "Permission insuffisante",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            reader.Close();
        }

        private void gérerLesOrganisationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "select * from organisations WHERE ID = @id";

            MySqlCommand command2 = new MySqlCommand(sql, Program.databaseManager.getConnection());
            command2.Parameters.AddWithValue("id", Program.currentUser.Organisation);

            MySqlDataReader reader = command2.ExecuteReader();

            while (reader.Read() == true)
            {
                if (Int32.Parse(reader["PERMISSION_LEVEL"].ToString()) >= 3)
                {
                    reader.Close();
                    FormOrganisations formOrganisations = new FormOrganisations();
                    this.Hide();
                    formOrganisations.ShowDialog();
                    this.Close();
                    return;
                }
                MessageBox.Show("Vous n'avez pas la permission d'ouvrir la gestion d'organisation",
                "Permission insuffisante",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

                SmtpClient smtpClient = new SmtpClient();
            }

            reader.Close();
        }
    }
}

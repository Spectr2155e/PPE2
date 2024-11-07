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
    public partial class FormUserInformations : Form
    {
        public FormUserInformations()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            FormAccueil formAccueil = new FormAccueil();
            this.Hide();
            formAccueil.ShowDialog();
            this.Close();
        }

        private void FormUserInformations_Load(object sender, EventArgs e)
        {

            string sql = "select users.USER_NAME, users.CREATION_DATE, users.LAST_CONNECTION, orga.NAME from users join organisations as orga on users.ORGANISATION_ID = orga.ID WHERE users.USER_NAME = @username";

            MySqlCommand command = new MySqlCommand(sql, Program.databaseManager.getConnection());
            command.Parameters.AddWithValue("username", Program.currentUser.Mail);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read() == true)
            {
                this.labelMail.Text = "Adresse mail: " + reader["USER_NAME"].ToString();
                this.labelPassword.Text = "Mot de passe: *******";
                this.labelCreationDate.Text = "Date de création: " + reader["CREATION_DATE"].ToString();
                this.labelLastConnection.Text = "Dernière connexion: " + reader["LAST_CONNECTION"].ToString();
                this.labelOrganisation.Text = "Organisation: " + reader["NAME"].ToString();
            }
            reader.Close();
        }
    }
}

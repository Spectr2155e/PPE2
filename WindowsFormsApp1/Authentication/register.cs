using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Objects;

namespace WindowsFormsApp1.Authentication
{
    internal class register
    {
        public static Boolean tryRegister(string username, string password, string key, FormLogin form)
        {
            MySqlDataReader reader;
            string sql;

            sql = string.Format("select * from users WHERE USER_NAME = @username", username);

            MySqlCommand command = new MySqlCommand(sql, Program.databaseManager.getConnection());
            command.Parameters.AddWithValue("username", username);

            reader = command.ExecuteReader();

            while (reader.Read() == true)
            {
                MessageBox.Show("Création de compte impossible, un utilisateur possède déjà cette adresse mail.",
                "Erreur d'inscription",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                reader.Close();
                return false;
            }
            reader.Close();

            sql = "select * from keys_orga k join organisations o on k.ORGANISATION_ID = o.ID WHERE KEY_STRING = @key";

            MySqlCommand command2 = new MySqlCommand(sql, Program.databaseManager.getConnection());
            command2.Parameters.AddWithValue("key", key);

            reader = command2.ExecuteReader();

            string now = Utils.Utils.GetTimestamp(DateTime.Now);

            while (reader.Read() == true)
            {

                Program.currentUser = new Objects.User(username, password, Int32.Parse(reader["ORGANISATION_ID"].ToString()));

                MessageBox.Show(string.Format("Compte créé avec succès sur l'organisation: \"{0}\".", reader["NAME"]),
                "Erreur d'inscription",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                new Logs(Utils.Utils.GetTimestamp(DateTime.Now) + " - Inscription réussi pour l'utilisateur " + username).writeLogs();

                password = Utils.Utils.sha256_hash(password);
                string sqlCreationUser = "INSERT INTO users(USER_NAME, USER_PASSWORD, CREATION_DATE, LAST_CONNECTION, ORGANISATION_ID)" +
                " VALUES(@username, @password, @now, @now, @id)";

                MySqlCommand command3 = new MySqlCommand(sqlCreationUser, Program.databaseManager.getConnection());
                command3.Parameters.AddWithValue("username", username);
                command3.Parameters.AddWithValue("password", password);
                command3.Parameters.AddWithValue("now", now);
                command3.Parameters.AddWithValue("id", reader["ORGANISATION_ID"].ToString());

                reader.Close();
                command3.ExecuteNonQuery();
                FormAccueil formAccueil = new FormAccueil();
                form.Hide();
                formAccueil.ShowDialog();
                form.Close();

                return true;
            }
            MessageBox.Show("Création de compte impossible, la clé d'enregistrement est inexistante.",
                "Erreur d'inscription",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            new Logs(Utils.Utils.GetTimestamp(DateTime.Now) + " - Interruption connexion utilisateur " + username + " Code d'erreur: Création de compte impossible, la clé d'enregistrement est inexistante.").writeLogs();
            reader.Close();
            return false;
        }
    }
}

using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Objects;

namespace WindowsFormsApp1.Authentication
{
    internal class login
    {
        public static Boolean tryLogin(string username, string password, FormLogin form)
        {
            string sql = "select USER_PASSWORD, users.ID as ID, organisations.ID as ORGA_ID, USER_NAME from users join organisations on users.ORGANISATION_ID = organisations.ID WHERE USER_NAME = @username";

            MySqlCommand command = new MySqlCommand(sql, Program.databaseManager.getConnection());
            command.Parameters.AddWithValue("username", username);
            
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read() == true)
            {
                if (reader["USER_PASSWORD"].Equals(Utils.Utils.sha256_hash(password)))
                {
                    int id = (int)reader["ID"];
                    Program.currentUser = new Objects.User(username, password, Int32.Parse(reader["ORGA_ID"].ToString()));
                    new Logs(Utils.Utils.GetTimestamp(DateTime.Now) + " - Connexion réussi pour l'utilisateur " + username).writeLogs();
                    reader.Close();
                    FormAccueil formAccueil = new FormAccueil();
                    form.Hide();
                    formAccueil.ShowDialog();
                    form.Close();
                    loginUser(id);
                    return true;
                }
            }
            MessageBox.Show("Connexion impossible, le mot de passe ou l'identifiant est incorrect.", 
                "Erreur d'authentification", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            new Logs(Utils.Utils.GetTimestamp(DateTime.Now) + " - Interruption connexion utilisateur " + username + " Code d'erreur: Connexion impossible, le mot de passe ou l'identifiant est incorrect.").writeLogs();
            reader.Close();
            return false;
        }

        public static void loginUser(int id)
        {
            string timestamp = Utils.Utils.GetTimestamp(DateTime.Now);
            string sql = "UPDATE Users SET LAST_CONNECTION = @timestamp WHERE ID = @id";

            MySqlCommand command = new MySqlCommand(sql, Program.databaseManager.getConnection());
            command.Parameters.AddWithValue("timestamp", timestamp);
            command.Parameters.AddWithValue("id", id);

            MessageBox.Show("Connecté avec succès !",
                "Authentification réussi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);


            command.ExecuteNonQuery();

        }
    }
}

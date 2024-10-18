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

namespace WindowsFormsApp1.Authentication
{
    internal class login
    {
        public static Boolean tryLogin(string username, string password)
        {
            string sql = string.Format("select * from Users WHERE USER_NAME = '{0}'", username);

            MySqlDataReader reader = Program.databaseManager.getResultOfRequest(sql);

            while (reader.Read() == true)
            {
                if (reader["USER_PASSWORD"].Equals(Utils.Utils.sha256_hash(password)))
                {
                    int id = (int)reader["ID"];
                    reader.Close();
                    loginUser(id);
                    return true;
                }
            }
            MessageBox.Show("Connexion impossible, le mot de passe ou l'identifiant est incorrect.", 
                "Erreur d'authentification", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            reader.Close();
            return false;
        }

        public static void loginUser(int id)
        {
            string timestamp = Utils.Utils.GetTimestamp(DateTime.Now);
            string sql = string.Format("UPDATE Users SET LAST_CONNECTION = '{0}' WHERE ID = '{1}'", timestamp, id);
            MessageBox.Show(sql);
            MessageBox.Show("Connecté avec succès !",
                "Authentification réussi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            Program.databaseManager.executeRequest(sql);
        }
    }
}

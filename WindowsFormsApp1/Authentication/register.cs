using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Authentication
{
    internal class register
    {
        public static Boolean tryRegister(string username, string password, string key)
        {
            MySqlDataReader reader;
            string sql;

            sql = string.Format("select * from users WHERE USER_NAME = '{0}'", username);

            reader = Program.databaseManager.getResultOfRequest(sql);

            while (reader.Read() == true)
            {
                MessageBox.Show("Création de compte impossible, un utilisateur possède déjà ce nom.",
                "Erreur d'inscription",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                reader.Close();
                return false;
            }
            reader.Close();

            sql = string.Format("select * from keys_orga k join organisations o on k.ORGANISATION_ID = o.ID WHERE KEY_STRING = '{0}'", key);

            reader = Program.databaseManager.getResultOfRequest(sql);

            string now = Utils.Utils.GetTimestamp(DateTime.Now);

            while (reader.Read() == true)
            {
                MessageBox.Show(string.Format("Compte créé avec succès sur l'organisation: \"{0}\".", reader["NAME"]),
                "Erreur d'inscription",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                password = Utils.Utils.sha256_hash(password);
                string sqlCreationUser = string.Format("INSERT INTO Users(USER_NAME, USER_PASSWORD, CREATION_DATE, LAST_CONNECTION, ORGANISATION_ID)" +
                " VALUES('{0}', '{1}', '{2}', '{3}', '{4}')", username, password, now, now, reader["ID"]);
                Console.Write(sqlCreationUser);
                reader.Close();
                Program.databaseManager.executeRequest(sqlCreationUser);
                return true;
            }
            MessageBox.Show("Création de compte impossible, la clé d'enregistrement est inexistante.",
                "Erreur d'inscription",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            reader.Close();
            return false;
        }
    }
}

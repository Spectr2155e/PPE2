using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp1
{
    public partial class FormChangePassword : Form
    {
        public FormChangePassword()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox2.Text.Length < 12 || !(Regex.IsMatch(textBox2.Text, "[A-Z]")) || !(Regex.IsMatch(textBox2.Text, "[a-z]")) || !(textBox2.Text.Any(char.IsDigit)) || !(textBox2.Text.Any(c => !char.IsLetterOrDigit(c))))
            {
                MessageBox.Show("Votre mot de passe doit contenir au moins 1 caractère en majuscule, au moins 1 caractère en minuscule, 1 chiffre et un caractère spécial",
                "Problème",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sql3 = "select * from password_history WHERE MAIL = @mail LIMIT 20";

            MySqlCommand command3 = new MySqlCommand(sql3, Program.databaseManager.getConnection());
            command3.Parameters.AddWithValue("mail", FormLogin.currentMail);

            MySqlDataReader reader = command3.ExecuteReader();

            while (reader.Read() == true)
            {
                if (reader["USER_PASSWORD"].ToString().Equals(Utils.Utils.sha256_hash(textBox2.Text)))
                {
                    MessageBox.Show("Le mot de passe saisie a déjà été utilisé lors des 20 dernières fois",
                "Problème",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    reader.Close();
                    return;
                }
                
            }
            reader.Close();

            if (FormLogin.currentCode == Int32.Parse(textBox1.Text))
            {
                string sql = "UPDATE users SET USER_PASSWORD = @password WHERE USER_NAME = @username";

                MySqlCommand command = new MySqlCommand(sql, Program.databaseManager.getConnection());
                command.Parameters.AddWithValue("username", FormLogin.currentMail);
                command.Parameters.AddWithValue("password", Utils.Utils.sha256_hash(textBox2.Text));

                command.ExecuteNonQuery();

                string sql2 = "INSERT INTO password_history(MAIL, USER_PASSWORD, CHANGED_DATE) VALUES(@mail, @password, @date)";

                MySqlCommand command2 = new MySqlCommand(sql2, Program.databaseManager.getConnection());
                command2.Parameters.AddWithValue("mail", FormLogin.currentMail);
                command2.Parameters.AddWithValue("password", Utils.Utils.sha256_hash(textBox2.Text));
                command2.Parameters.AddWithValue("date", Utils.Utils.GetTimestamp(DateTime.Now));

                command2.ExecuteNonQuery();

                MessageBox.Show("Mot de passe changé avec succès.",
                "Succès",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                FormLogin formAccueil = new FormLogin();
                this.Hide();
                formAccueil.ShowDialog();
                this.Close();

            } else
            {
                MessageBox.Show("Le code saisi est incorrect.",
                "Erreur de changement de mot de passe",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormLogin formAccueil = new FormLogin();
            this.Hide();
            formAccueil.ShowDialog();
            this.Close();
        }
    }
}

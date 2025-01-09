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
            if(Program.currentUser.keyToChangePassword == Int32.Parse(textBox1.Text))
            {
                string sql = "UPDATE users SET USER_PASSWORD = @password WHERE USER_NAME = @username";

                MySqlCommand command = new MySqlCommand(sql, Program.databaseManager.getConnection());
                command.Parameters.AddWithValue("username", Program.currentUser.Mail);
                command.Parameters.AddWithValue("password", Utils.Utils.sha256_hash(textBox2.Text));

                command.ExecuteNonQuery();

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

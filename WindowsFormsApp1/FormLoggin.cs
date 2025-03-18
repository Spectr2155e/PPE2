using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Database;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class FormLogin : Form
    {

        public static int choice;

        private void switchConnectionMode(int choiceA)
        {
            switch (choiceA)
            {
                case 1:
                    choice = 0;
                    LabelLogin.Text = "Se connecter";
                    button1.Text = "Se connecter";
                    textBox1.Visible = false;
                    pictureBox4.Visible = false;
                    label4.Visible = false;
                    label3.Text = "Créer un compte";
                    break;
                case 0:
                    choice = 1;
                    LabelLogin.Text = "S'enregistrer";
                    button1.Text = "S'enregistrer";
                    textBox1.Visible = true;
                    pictureBox4.Visible = true;
                    label4.Visible = true;
                    label3.Text = "J'ai déjà un compte";
                    break;
            }
        }

        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxLoginUserName.Text == "" || !Utils.Utils.IsValidMail(textBoxLoginUserName.Text))
            {
                MessageBox.Show("Veuillez entrer une adresse mail valide.",
                    "Erreur d'authentification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBoxLoginPassword.Text == "" || !(textBoxLoginPassword.Text.Length >= 6))
            {
                MessageBox.Show("Veuillez entrer un mot de passe de plus de 6 caractères et valide.",
                    "Erreur d'authentification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (choice)
            {
                case 0:
                    Authentication.login.tryLogin(textBoxLoginUserName.Text, textBoxLoginPassword.Text, this);
                    break;
                case 1:
                    Authentication.register.tryRegister(textBoxLoginUserName.Text, textBoxLoginPassword.Text, textBox1.Text, this);
                    break;

            }

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Green;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = SystemColors.Control;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            switchConnectionMode(choice);
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            choice = 0;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FormAccueil formAccueil = new FormAccueil();
            this.Hide();
            formAccueil.ShowDialog();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {

        }

        public static int currentCode;
        public static String currentMail;

        private void label5_Click(object sender, EventArgs e)
        {
            currentCode = Utils.Utils.randomValue(100000, 999999);
            currentMail = textBoxLoginUserName.Text;
            Utils.Utils.sendAnEmailConfirmation(textBoxLoginUserName.Text, currentCode);
            FormChangePassword formChangePassword = new FormChangePassword();
            this.Hide();
            formChangePassword.ShowDialog();
            this.Close();
        }
    }
}

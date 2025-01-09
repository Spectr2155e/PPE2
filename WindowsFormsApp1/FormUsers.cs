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
    public partial class FormUsers : Form
    {

        public static string method;

        public FormUsers()
        {
            InitializeComponent();
        }

        private void FormUsers_Load(object sender, EventArgs e)
        {
            refreshData();
            button4.Visible = false;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem != null)
            {
                textBox1.Text = ((Objects.User)listBox1.SelectedItem).Mail;
                textBox2.Text = ((Objects.User)listBox1.SelectedItem).Password;
                textBox3.Text = ((Objects.User)listBox1.SelectedItem).Organisation.ToString();
                textBox4.Text = ((Objects.User)listBox1.SelectedItem).LastConnection;
                textBox5.Text = ((Objects.User)listBox1.SelectedItem).CreationDate;

                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;

                button4.Visible = false;
                button5.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string sql = "delete from users where ID = @id";

                MySqlCommand command = new MySqlCommand(sql, Program.databaseManager.getConnection());
                command.Parameters.AddWithValue("id", ((Objects.User)listBox1.SelectedItem).Id);

                command.ExecuteNonQuery();
                refreshData();
                clearAllTextBox();
                return;
            }
            MessageBox.Show("Erreur de choix d'utilisateur", "Vous n'avez pas séléctionné d'utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        private void refreshData()
        {
            listBox1.Items.Clear();
            string sql = "select users.ID, users.USER_NAME, users.USER_PASSWORD, users.CREATION_DATE, users.LAST_CONNECTION, organisations.NAME, organisations.ID as ORGANISATION_ID" +
               " from users join organisations on organisations.ID = users.ORGANISATION_ID";

            MySqlDataReader rd = Program.databaseManager.getResultOfRequest(sql);

            while (rd.Read() == true)
            {
                listBox1.Items.Add(new Objects.User(Int32.Parse(rd["ID"].ToString()), rd["USER_NAME"].ToString(),
                    rd["USER_PASSWORD"].ToString(), Int32.Parse(rd["ORGANISATION_ID"].ToString()),
                    rd["LAST_CONNECTION"].ToString(), rd["CREATION_DATE"].ToString()));
            }
            rd.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            method = "create";
            button4.Visible = true; 
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            clearAllTextBox();
        }

        private void clearAllTextBox()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormAccueil formAccueil = new FormAccueil();
            this.Hide();
            formAccueil.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            switch (method) 
            {
                case "create":
                    if(textBox1.Text != null && textBox2 != null && textBox3 != null)
                    {
                        string sql = "INSERT INTO users(USER_NAME, USER_PASSWORD, CREATION_DATE, LAST_CONNECTION, ORGANISATION_ID) " +
                            "VALUES(@username, @password, @creationDate, @lastConnection, @organisation)";

                        MySqlCommand command = new MySqlCommand(sql, Program.databaseManager.getConnection());
                        command.Parameters.AddWithValue("username", textBox1.Text);
                        command.Parameters.AddWithValue("password", Utils.Utils.sha256_hash(textBox2.Text));
                        command.Parameters.AddWithValue("creationDate", Utils.Utils.GetTimestamp(DateTime.Now));
                        command.Parameters.AddWithValue("lastConnection", null);
                        command.Parameters.AddWithValue("organisation", textBox3.Text);

                        command.ExecuteNonQuery();
                        clearAllTextBox();
                        refreshData();
                        break;
                    } else
                    {
                        MessageBox.Show("Erreur de saisie", "Vous n'avez pas rempli tous les champs disponible", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                case "modify":
                    if (textBox1.Text != null && textBox2 != null && textBox3 != null)
                    {
                        string sql = "UPDATE users SET USER_NAME = @username, USER_PASSWORD = @password, ORGANISATION_ID = @organisation WHERE ID = @id";

                        MySqlCommand command = new MySqlCommand(sql, Program.databaseManager.getConnection());
                        command.Parameters.AddWithValue("username", textBox1.Text);
                        command.Parameters.AddWithValue("password", Utils.Utils.sha256_hash(textBox2.Text));
                        command.Parameters.AddWithValue("organisation", textBox3.Text);
                        command.Parameters.AddWithValue("id", ((Objects.User)listBox1.SelectedItem).Id);

                        command.ExecuteNonQuery();
                        refreshData();
                        clearAllTextBox();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Erreur de saisie", "Vous n'avez pas rempli tous les champs disponible", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            button4.Visible = true;
            method = "modify";
        }
    }
}

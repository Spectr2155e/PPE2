using Google.Protobuf.WellKnownTypes;
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
    public partial class FormOrganisations : Form
    {

        public static string method;

        public FormOrganisations()
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
            textBox5.ReadOnly = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem != null)
            {
                textBox1.Text = ((Objects.Organisation)listBox1.SelectedItem).Name;
                textBox2.Text = ((Objects.Organisation)listBox1.SelectedItem).Description;
                textBox3.Text = ((Objects.Organisation)listBox1.SelectedItem).PermissionLevel.ToString();
                textBox5.Text = ((Objects.Organisation)listBox1.SelectedItem).CreationDate;

                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox5.ReadOnly = true;

                button4.Visible = false;
                button5.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string sql = "delete from organisations where ID = @id";

                MySqlCommand command = new MySqlCommand(sql, Program.databaseManager.getConnection());
                command.Parameters.AddWithValue("id", ((Objects.Organisation)listBox1.SelectedItem).Id);

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
            string sql = "select * from organisations";

            MySqlDataReader rd = Program.databaseManager.getResultOfRequest(sql);

            while (rd.Read() == true)
            {
                listBox1.Items.Add(new Objects.Organisation(Int32.Parse(rd["ID"].ToString()), rd["NAME"].ToString(),
                    rd["CREATION_DATE"].ToString(), rd["DESCRIPTION"].ToString(), Int32.Parse(rd["PERMISSION_LEVEL"].ToString())));
            }
            rd.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            method = "create";
            button4.Visible = true; 
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
                        string sql = "INSERT INTO organisations(NAME, CREATION_DATE, DESCRIPTION, PERMISSION_LEVEL) " +
                            "VALUES(@name, @creationDate, @description, @permissionLevel)";

                        MySqlCommand command = new MySqlCommand(sql, Program.databaseManager.getConnection());
                        command.Parameters.AddWithValue("name", textBox1.Text);
                        command.Parameters.AddWithValue("creationDate", Utils.Utils.GetTimestamp(DateTime.Now));
                        command.Parameters.AddWithValue("description", textBox2.Text);
                        command.Parameters.AddWithValue("permissionLevel", textBox3.Text);

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
                        string sql = "UPDATE organisations SET NAME = @name, DESCRIPTION = @description, PERMISSION_LEVEL = @permissionLevel WHERE ID = @id";

                        MySqlCommand command = new MySqlCommand(sql, Program.databaseManager.getConnection());
                        command.Parameters.AddWithValue("name", textBox1.Text);
                        command.Parameters.AddWithValue("description", textBox2.Text);
                        command.Parameters.AddWithValue("permissionLevel", textBox3.Text);
                        command.Parameters.AddWithValue("id", ((Objects.Organisation)listBox1.SelectedItem).Id);

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
            textBox5.ReadOnly = true;
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            button4.Visible = true;
            method = "modify";
        }

        private void FormUsers_Load_1(object sender, EventArgs e)
        {

        }

        private void label1a_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormAddItem : Form
    {
        public FormAddItem()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void FormAddItem_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string sql = "select * from categories";
            MySqlDataReader reader = Program.databaseManager.getResultOfRequest(sql);

            while (reader.Read() == true)
            {
                comboBox1.Items.Add(reader["NAME"].ToString());
            }
            reader.Close();
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            int quantity = (int) numericUpDown1.Value;
            int weight = (int) numericUpDown2.Value;
            string addingDate = Utils.Utils.GetTimestamp(DateTime.Now);
            int category =  (int) Int32.Parse(getIdOfCategory(comboBox1.SelectedItem.ToString()));
            int organisation = Program.currentUser.Organisation;

            string sql = "INSERT INTO items(NAME, QUANTITY, WEIGHT, ADDING_DATE, CATEGORY_ID, ORGANISATION_ID) VALUES(@name, @quantity, @weight, @adding, @category, @organisation)";

            MySqlCommand command = new MySqlCommand(sql, Program.databaseManager.getConnection());
            command.Parameters.AddWithValue("name", name);
            command.Parameters.AddWithValue("quantity", quantity);
            command.Parameters.AddWithValue("weight", weight);
            command.Parameters.AddWithValue("adding", addingDate);
            command.Parameters.AddWithValue("category", category);
            command.Parameters.AddWithValue("organisation", organisation);

            command.ExecuteNonQuery();

            returnToAccueilScreen();
            
        }

        private string getIdOfCategory(string category) {
            string sql = "select * from categories";
            MySqlDataReader reader = Program.databaseManager.getResultOfRequest(sql);

            while (reader.Read() == true)
            {
                if (reader["NAME"].Equals(category))
                {
                    Console.Write(reader["NAME"].ToString());
                    string id = reader["ID"].ToString();
                    reader.Close();
                    return id;
                }
            }
            reader.Close();
            return null;
        }

        private void returnToAccueilScreen()
        {
            FormAccueil formAccueil = new FormAccueil();
            this.Hide();
            formAccueil.ShowDialog();
            this.Close();
        }

        private void FormAddItem_FormClosed(object sender, FormClosedEventArgs e)
        {
            returnToAccueilScreen();
        }
    }
}

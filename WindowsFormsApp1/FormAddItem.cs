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
            string quantity = numericUpDown1.Value.ToString();
            string weight = numericUpDown2.Value.ToString();
            string addingDate = Utils.Utils.GetTimestamp(DateTime.Now);
            string category = getIdOfCategory(comboBox1.SelectedItem.ToString());
            string organisation = Program.currentUser.Organisation;

            string sql = string.Format("INSERT INTO items(NAME, QUANTITY, WEIGHT, ADDING_DATE, CATEGORY_ID, ORGANISATION_ID) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                name, quantity, weight, addingDate, category, organisation);

            Program.databaseManager.executeRequest(sql);

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
    }
}

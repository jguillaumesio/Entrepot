using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using MySql.Data.MySqlClient;
using Microsoft.VisualBasic;

namespace Entrepot
{
    public partial class accueil : Form
    {
        Form2 form2 = new Form2();
        Form3 form3 = new Form3();
        ClassConnexionMySQL mysql = new ClassConnexionMySQL("entrepot");
        MySqlDataReader Reader;
        CEntrepot entrepot = new CEntrepot("entrepot");
        public accueil()
        {
            InitializeComponent();
        }

        private void accueil_Load(object sender, EventArgs e)
        {
        }

        private void quitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void update()
        {
            form2.combobox_liberer.Items.Clear();
            form2.combobox_liberer.Text = "";
            foreach (string i in entrepot.ProduitsEnStock)
            {
                form2.combobox_liberer.Items.Add(i);
            }
            form2.combobox_liberer.Items.Add("Sélectionner un emplacement !");
            form2.combobox_liberer.SelectedItem = "Sélectionner un emplacement !";
        }
        private void liberer_Click(object sender, EventArgs e)
        {
            this.Hide();
            form2.Show();
            update();
        }

        private void obtenir_libre_Click(object sender, EventArgs e)
        {
            string place = entrepot.donnerPlace();
            MessageBox.Show(place);
        }

        public void stock_Click(object sender, EventArgs e)
        {
            mysql.Connexion1.Open();
            DataTable print = new DataTable();
            print.Columns.Add("Référence");
            print.Columns.Add("Désignation");
            print.Columns.Add("Emplacement");
            string req = "SELECT * FROM stock WHERE idEntrepot = '" + entrepot.IdenEntrepot + "'";
            mysql.Command1 = new MySqlCommand(req, mysql.Connexion1);
            Reader = mysql.Command1.ExecuteReader();
            do
            {
                while (Reader.Read())
                {
                    DataRow row = print.NewRow();
                    row["Référence"] = Reader.GetValue(1);
                    row["Désignation"] = Reader.GetValue(2);
                    row["Emplacement"]=Reader.GetValue(3);
                    print.Rows.Add(row);
                }
            }
            while (Reader.NextResult());
            Reader.Close();
            mysql.CommandeClose();
            this.Hide();
            form3.Show();
            foreach (DataRow row in print.Rows)
            {
                int num = form3.dataGridView1.Rows.Add();
                form3.dataGridView1.Rows[num].Cells[0].Value =row["Référence"].ToString();
                form3.dataGridView1.Rows[num].Cells[1].Value = row["Désignation"].ToString();
                form3.dataGridView1.Rows[num].Cells[2].Value = row["Emplacement"].ToString();

            }
        }

        private void impress_Click(object sender, EventArgs e)
        {
            mysql.Connexion1.Open();
            ArrayList emplacement = new ArrayList();
            string reference=Interaction.InputBox("Entrez la référence du produit recherché","Recherche d'un produit en stock","");
            string req = "SELECT * FROM stock WHERE idEntrepot = '" + entrepot.IdenEntrepot + "'";
            mysql.Command1 = new MySqlCommand(req, mysql.Connexion1);
            Reader = mysql.Command1.ExecuteReader();
            do
            {
                while (Reader.Read())
                {
                    if(Reader.GetValue(1).ToString()==reference)
                    {
                        emplacement.Add(Reader.GetValue(3).ToString());
                    }
                }
            }
            while (Reader.NextResult());
            Reader.Close();
            mysql.CommandeClose();
            if (emplacement.Count == 0)
            {
                MessageBox.Show("Le produit que vous recherchez n'est pas en stock", "Recherche d'un produit en stock");
            }
            else
            {
                string retour = "";
                foreach(string i in emplacement)
                {
                    retour = string.Concat(retour,i, ", ");
                }
                retour = retour.Remove(retour.Length-2);
                MessageBox.Show("Le produit que vous recherchez est à/aux l'emplacement(s):"+ Environment.NewLine+""+retour + "", "Recherche d'un produit en stock");
            }
        }
    }
}

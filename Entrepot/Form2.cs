using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Entrepot
{
    public partial class Form2 : Form
    {
        CEntrepot entrepot = new CEntrepot("entrepot");

        public Form2()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            accueil form1 = new accueil();
            this.Hide();
            form1.Show();
            
        }

        public void update()
        {
            combobox_liberer.Items.Clear();
            combobox_liberer.Text = "";
            foreach (string i in entrepot.ProduitsEnStock)
            {
                combobox_liberer.Items.Add(i);
            }
            combobox_liberer.Items.Add("Sélectionner un emplacement !");
            combobox_liberer.SelectedItem="Sélectionner un emplacement !";
        }

        private void combobox_liberer_SelectedIndexChanged(object sender, EventArgs e)
        {
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (combobox_liberer.Text != "Sélectionner un emplacement !")
            {
                entrepot.supprimerProduit(combobox_liberer.Text, entrepot.IdenEntrepot);
                update();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un emplacement !");
            }
        }
    }
}

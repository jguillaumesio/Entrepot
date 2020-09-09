using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Entrepot
{
    class CEntrepot
    {
        string idenEntrepot; // identification entrepot
        ArrayList produitsEnStock;// collection d'objets des emplacements utilisés par des produits en stock.
        ArrayList placesDisponibles;// collection de string des numéros d'emplacements disponibles

        public string IdenEntrepot
        {
            get { return idenEntrepot; }
            set { idenEntrepot = value; }
        }
        public ArrayList ProduitsEnStock
        {
            get { return produitsEnStock; }
            set { produitsEnStock = value; }
        }
        public ArrayList PlacesDisponibles
        {
            get { return placesDisponibles; }
            set { placesDisponibles = value; }
        }

        public CEntrepot( string identEntrepot)
        {
            this.idenEntrepot = identEntrepot;
            this.produitsEnStock = new ArrayList();
            this.placesDisponibles = new ArrayList();
            List<char> travee = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q' };
            foreach (char rang in travee)
            {
                for (int num = 0; num < 100; num++)
                {
                    this.PlacesDisponibles.Add(string.Concat(rang.ToString(), num.ToString()));
                }
            }
            ClassConnexionMySQL mysql = new ClassConnexionMySQL("entrepot");
            string req = "SELECT count(*) FROM entrepot WHERE id = '" + this.IdenEntrepot + "'";
            int count = mysql.rowCount(req);
            if (count == 0)
            {
                req = string.Format("INSERT INTO `entrepot`(`id`) VALUES('{0}')", idenEntrepot);
                mysql.CommandeInsertion(req);

            }
            else
            {
                req ="SELECT * FROM stock WHERE idEntrepot = '" + this.IdenEntrepot + "'";
                mysql.Command1 = new MySqlCommand(req, mysql.Connexion1);
                MySqlDataReader Reader = mysql.Command1.ExecuteReader();
                ArrayList places_occ = new ArrayList();
                do
                {
                    while (Reader.Read())
                    {
                        CProduitEnStock produit = new CProduitEnStock(Reader.GetValue(3).ToString(), Reader.GetValue(1).ToString(), Reader.GetValue(2).ToString());
                        this.produitsEnStock.Add(produit.Emplacement);
                        places_occ.Add(Reader.GetValue(3).ToString());
                    }
                }
                while (Reader.NextResult());
                Reader.Close();
                foreach(string i in places_occ)
                {
                    this.PlacesDisponibles.Remove(i);
                }
            }
            mysql.CommandeClose();
        }
        public string donnerPlace()
        {
            if(this.PlacesDisponibles.Count==0)
            {
                return null;
            }
            else
            {
                Random rnd = new Random();
                int index = rnd.Next(this.PlacesDisponibles.Count);
                string retour = this.PlacesDisponibles[index].ToString();
                return retour;
            }
        }
        public void stockerProduit(CProduitEnStock produit)
        {
            string place = this.donnerPlace();
            produit.Emplacement = place;
            this.ProduitsEnStock.Add(place);
            this.placesDisponibles.Remove(place);
            ClassConnexionMySQL mysql = new ClassConnexionMySQL("entrepot");
            mysql.Connexion1.Open();
            string req = string.Format("INSERT INTO `stock`(`refProduit`,`designation`,`emplacement`,`idEntrepot`) VALUES('{0}','{1}','{2}','{3}')", produit.RefProduit, produit.DesignationProduit, produit.Emplacement,this.idenEntrepot);
            mysql.Command1=new MySqlCommand(req,mysql.Connexion1);
            mysql.Command1.ExecuteNonQuery();
            mysql.CommandeClose();
            
        }
        public string chercheProduit(string refProduit)
        {
            ClassConnexionMySQL mysql = new ClassConnexionMySQL("entrepot");
            mysql.Connexion1.Open();
            string req = "SELECT * FROM stock WHERE idEntrepot='" + this.IdenEntrepot + "' AND  refProduit='"+ refProduit +"'";
            mysql.Command1= new MySqlCommand(req, mysql.Connexion1);
            MySqlDataReader Reader = mysql.Command1.ExecuteReader();
            do
            {
                while (Reader.Read())
                {
                    return Reader.GetValue(3).ToString();
                }
            }
            while (Reader.NextResult());
            Reader.Close();
            mysql.CommandeClose();
            return null;
        }
        public void supprimerProduit(string emplacement,string entrepot)
        {
            ClassConnexionMySQL mysql = new ClassConnexionMySQL("entrepot");
            string req = "DELETE FROM stock WHERE idEntrepot = '" + entrepot + "' AND emplacement='" + emplacement + "'";
            mysql.CommandeInsertion(req);
            this.ProduitsEnStock.Remove(emplacement);
            this.PlacesDisponibles.Add(emplacement);
            mysql.CommandeClose();
        }
     }
}

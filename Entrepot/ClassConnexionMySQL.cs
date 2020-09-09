using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Data.SqlClient;

namespace Entrepot
{
    class ClassConnexionMySQL
    {
        MySqlConnection Connexion;
        MySqlCommand Command;

        public MySqlConnection Connexion1
        {
            get { return Connexion; }
            set { Connexion = value; }
        }

        public MySqlCommand Command1
        {
            get { return Command; }
            set { Command = value; }
        }

        public ClassConnexionMySQL(string database)
        {
            try 
            {
                string connectionString=string.Concat("SERVER=127.0.0.1; DATABASE=",database,"; UID=root; PASSWORD=");
                this.Connexion1 = new MySqlConnection(connectionString);
            }
            catch
            {
            }
        }

        public void CommandeLecture(string strRequete)
        {
            this.Command1 = new MySqlCommand(strRequete, this.Connexion1);
            MySqlDataReader Reader = this.Command1.ExecuteReader();
            do
            {
                while (Reader.Read())
                {
                    //Console.WriteLine(string.Concat("ID: ", Reader.GetValue(0).ToString(), " Nom: ", Reader.GetValue(1).ToString(), " Description: ", Reader.GetValue(2).ToString()));
                }
            }
            while (Reader.NextResult());
            Reader.Close();

        }

        public void CommandeInsertion(string strRequete)
        {
            this.Connexion1.Open();
            MySqlCommand command = new MySqlCommand(strRequete, Connexion);
            command.ExecuteNonQuery();

        }

        public int rowCount(string req)
        {
            this.Connexion1.Open();
            this.Command1 = new MySqlCommand(req, this.Connexion1);
            Int32 count = Convert.ToInt32(this.Command1.ExecuteScalar());
            return count;
        }

        public void CommandeClose()
        {
            this.Connexion1.Close();
        }
    }
}

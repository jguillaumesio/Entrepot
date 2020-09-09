using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrepot
{
    class CProduitEnStock
    {
        string emplacement;
        string refProduit;
        string designationProduit;

        public string Emplacement
        {
            get { return emplacement; }
            set { emplacement = value; }
        }
        public string RefProduit
        {
            get { return refProduit; }
            set { refProduit = value; }
        }

        public string DesignationProduit
        {
            get { return designationProduit; }
            set { designationProduit = value; }
        }

        public CProduitEnStock(string emplacement,string refProduit,string designationProduit)
        {
            this.emplacement = emplacement;
            this.refProduit = refProduit;
            this.designationProduit = designationProduit;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce__projet.Models.Panier
{
    public class PanierProduit
    {
        public Produit Produitpanier
        {
            get; set;
        }

        public int Quantite
        { 
            set; get; 
        }
        
    }
}
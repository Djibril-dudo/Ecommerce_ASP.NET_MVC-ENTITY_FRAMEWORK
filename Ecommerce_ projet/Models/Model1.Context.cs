﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ecommerce__projet.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BdecommerceEntities : DbContext
    {
        public BdecommerceEntities()
            : base("name=BdecommerceEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Vendeur> Vendeur { get; set; }
        public virtual DbSet<Produit> Produit { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Commande> Commande { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Ecommerce__projet.Models;
namespace Ecommerce__projet.Controllers
{
    public class ProduitController : Controller
    {

        BdecommerceEntities db= new BdecommerceEntities();
        // GET: Produit
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult modifier(Produit produit, HttpPostedFileBase photo)
        {
            string fil = null;
            if (photo != null)
            {
                fil = System.IO.Path.GetFileName(photo.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/PhotoProduit/"), fil);
                photo.SaveAs(path);
            }
            Produit pr = new Produit();

            pr.idproduit = produit.idproduit;
            pr.nom = produit.nom;
            pr.prix = produit.prix;
            pr.quantite = produit.quantite;
            pr.image = fil;
            db.Produit.Add(pr);
            return View("ajouter");

        }
        public ActionResult ajouter(Produit produit, HttpPostedFileBase photo)
        {

            string fil = null;
            if (photo != null)
            {
                fil = System.IO.Path.GetFileName(photo.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/PhotoProduit/"), fil);
                photo.SaveAs(path);
            }
            Produit pr = new Produit();

            pr.idproduit = produit.idproduit;
            pr.nom = produit.nom;
            pr.prix = produit.prix;
            pr.quantite = produit.quantite;
            pr.image = fil;
            db.Produit.Add(pr);
            return View("ajouter");

        }
        [HttpPost]
        public ActionResult CreatePro(Produit produit,HttpPostedFileBase photo)
        {
            string fil=null;
            if(photo!=null)
            {
                 fil = System.IO.Path.GetFileName(photo.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/PhotoProduit/"), fil);
                photo.SaveAs(path);
            }
            Produit pr = new Produit();

            pr.idproduit = produit.idproduit;
            pr.nom = produit.nom;
            pr.prix = produit.prix;
            pr.quantite = produit.quantite;
            pr.image = fil;
            db.Produit.Add(pr);
            db.SaveChanges();
            return View("ajouter");

        }
    }
}


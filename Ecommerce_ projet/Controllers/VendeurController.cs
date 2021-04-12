using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce__projet.Models;
namespace Ecommerce__projet.Controllers
{
    public class VendeurController : Controller
    {
        BdecommerceEntities bd=new BdecommerceEntities();
        // GET: Vendeur
        public ActionResult Vendeur()
        {
            var getvendeur = bd.Vendeur.ToList();
            SelectList list = new SelectList(getvendeur, "identifiant", "identifiant");
            ViewBag.listvendeur = list;
            return View();
        }
        public ActionResult Vend()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ajoutVendeur(Vendeur vendeur)
        {
            Vendeur v=new Vendeur();
            v.identifiant = vendeur.identifiant;
            v.nom = vendeur.nom;
            v.prenom = vendeur.prenom;
            bd.Vendeur.Add(v);
            bd.SaveChanges();
            return View("Vend");
        }
      public ActionResult listeproduit()
        {
            var res = bd.Produit.ToList();
        
            return View(res);
        }
       
        public ActionResult PageVendeur()
        {

            return View();
        }
        public ActionResult Delete(int id)
        {
            var res = bd.Produit.Where(x => x.idproduit == id).First();
            bd.Produit.Remove(res);
            bd.SaveChanges();
            var list = bd.Produit.ToList();
            return View("listeproduit", list);
        }
        public ActionResult affichercommande()
        {
            var resul = bd.Commande.ToList();

            return View(resul);
        }
        public ActionResult ChoixDuVendeur()
        {

            var getclient = bd.Vendeur.ToList();
            SelectList list = new SelectList(getclient, "identifiant", "identifiant");
            ViewBag.listvendeur = list;
            return View();
        }

        [HttpPost]
        public ActionResult ChoixDuVendeur(Vendeur vendeur)
        {
            var user = bd.Vendeur.SingleOrDefault(x => x.identifiant == vendeur.identifiant);

            if (user != null)
            {
                ViewBag.message = "vous etes conecter";
                ViewBag.triedOnce = "yes";
                Session["identifiant"] = vendeur.identifiant;
                return RedirectToAction("PageVendeur", "Vendeur", new { identifiant = vendeur.identifiant });
            }
            else
            {
                ViewBag.triedOnce = "yes";
                var getvendeur = bd.Vendeur.ToList();
                SelectList list = new SelectList(getvendeur, "identifiant", "identifiant");
                ViewBag.listvendeur = list;

                return View();
            }
        }
        public ActionResult InscrireVendeur()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AjouterVendeur(Vendeur v)
        {
            Vendeur cli = new Vendeur();
            cli.identifiant = v.identifiant;
            cli.nom = v.nom;
            cli.prenom = v.prenom;
            bd.Vendeur.Add(cli);
            bd.SaveChanges();
            return View("InscrireVendeur");
        }
    }
}
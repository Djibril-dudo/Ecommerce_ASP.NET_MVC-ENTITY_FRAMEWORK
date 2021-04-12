using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;
using Ecommerce__projet.Models;
using Ecommerce__projet.Models.Panier;
namespace Ecommerce__projet.Controllers
{
    public class ClientController : Controller
    {
        BdecommerceEntities bd=new BdecommerceEntities();
        // GET: Client
        public ActionResult Index()
        {
            
            return View();
         
        }
        public ActionResult InterfaceGenerale(string chercher,string identifiantClient)

        {
            
                var res = from s in bd.Produit select s;
                if (!String.IsNullOrEmpty(chercher))
                {
                    res = res.Where(s => s.nom.Contains(chercher));
                }
                return View(res.ToList());
            
            
        }
        public ActionResult Panier(int idproduit)
  {
            if(Session["panier"]==null)
            {
                List<PanierProduit> panier = new List<PanierProduit>();
                var prod = bd.Produit.Find(idproduit);
                panier.Add(new PanierProduit()
                {
                    Produitpanier = prod,
                    Quantite = 1
                });
                Session["panier"] = panier;
            }
            else
            {

                List<PanierProduit> panier =( List<PanierProduit>)Session["panier"];
                var prod = bd.Produit.Find(idproduit);
                foreach (var element in panier)
                {
                    if (element.Produitpanier.idproduit == idproduit)
                    {

                        int augmquantite = element.Quantite;

                        panier.Remove(element);
                        panier.Add(new PanierProduit()
                        {
                        Produitpanier = prod,
                            Quantite = augmquantite + 1
                        });

                        break;
                    }
                    else
                    {
                        panier.Add(new PanierProduit()
                        {
                            Produitpanier = prod,
                            Quantite =1
                        });

                    }
                    break;
                }
                

                Session["panier"] = panier;
            }
           
            return Redirect("InterfaceGenerale");
        }
        public ActionResult SupprimerPanier(int idprod)
        {
             List<PanierProduit> panier = (List<PanierProduit>)Session["panier"];

            foreach (var element in panier)
            {
            if(element.Produitpanier.idproduit==idprod)
                {
                    panier.Remove(element);
                    break;
                }
                
            }

            Session["panier"] = panier;
            return Redirect("InterfaceGenerale");
        }
        public ActionResult Commande()
        {
            return View();
        }
        public ActionResult CommandeDetail(Client client)
        {
            var user = bd.Client.SingleOrDefault(x => x.identifiantClient == client.identifiantClient);

            if (user != null)
            {
                ViewBag.message = "vous etes conecter";
                ViewBag.triedOnce = "yes";
                Session["identifiantClient"] = client.identifiantClient;
                return RedirectToAction("InterfaceGenerale", "Client", new { identifiantClient = client.identifiantClient });
            }
            else
            {
                ViewBag.triedOnce = "yes";
                var getclient = bd.Client.ToList();
                SelectList list = new SelectList(getclient, "identifiantClient", "identifiantClient");
                ViewBag.listeclient = list;


                return View();

            }
        }
       public ActionResult InscrireClient()
        {
            return View();
        }
       
         [HttpPost]
        public ActionResult AjouterClient(Client client)
        {
            Client cli =new Client();
            cli.identifiantClient = client.identifiantClient;
            cli.nom = client.nom;
            cli.prenom = client.prenom;
            cli.soldeinitial = client.soldeinitial;
            bd.Client.Add(cli);
            bd.SaveChanges();
            return View("InscrireClient");
        }
        public  ActionResult Listeclient()
        {
            var client = bd.Client.ToList();

            return View(client);
        }
        public ActionResult ChoixDuClient(Commande comm)
        {
           
            var getclient = bd.Client.ToList();
            SelectList list = new SelectList(getclient, "identifiantClient", "identifiantClient");
            ViewBag.listeclient = list;
            return View();
        }
        [HttpPost]
        public ActionResult ChoixDuClient(Client client)
        {
            var user = bd.Client.SingleOrDefault(x => x.identifiantClient == client.identifiantClient);
            
            if (user != null)
            {
                ViewBag.message = "vous etes conecter";
                ViewBag.triedOnce = "yes";
                Session["identifiantClient"] = client.identifiantClient;
                return RedirectToAction("InterfaceGenerale", "Client", new { identifiantClient = client.identifiantClient });
            }
            else
            {
                ViewBag.triedOnce = "yes";
                var getclient = bd.Client.ToList();
                SelectList list = new SelectList(getclient, "identifiantClient", "identifiantClient");
                ViewBag.listeclient = list;
                
                
                return View();


            }
        }
        [HttpPost]

        public ActionResult InterfaceClients()
        {
            return View();
        }
        public ActionResult SaveCommande(FormCollection fr,Commande commande)
        {
            List<PanierProduit> panier = (List<PanierProduit>)Session["panier"];
            foreach (PanierProduit panier1 in panier)
            {
                Commande co = new Commande();
                commande.idcommande =commande.idcommande;
                co.quantite = panier1.Quantite;
                co.prix_total= panier1.Produitpanier.prix;
                co.identifiantClient = fr["listeclient"];
                bd.Commande.Add(co);
                bd.SaveChanges();
            }
            


            return View("InterfaceClient");
        }
        public ActionResult InformationClient()
        {
            var res = bd.Client.ToList();

            return View(res);
        }
    }
}
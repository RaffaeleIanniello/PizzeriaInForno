using PizzeriaInForno.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzeriaInForno.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        ModelDbContext db = new ModelDbContext();
        public ActionResult Index()
        {


            return View(db.prodotti.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(prodotti p, HttpPostedFileBase img)
        {
           
            
                if(img != null && img.ContentLength>0) {
                    p.fotoProdotto = img.FileName;
                string path = Server.MapPath("~/Content/img/")+img.FileName;
                    img.SaveAs(path);
               }
                db.prodotti.Add(p);
                db.SaveChanges();   
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id) {
        
        prodotti p = db.prodotti.Find(id);
            return View(p);
        
        }
        [HttpPost]
        public ActionResult Edit(prodotti p, HttpPostedFileBase img)
        {
            if(ModelState.IsValid)
            {
                var prodotto = db.prodotti.Find(p.idProdotti);
                prodotto.nomeProdotto = p.nomeProdotto;
                prodotto.prezzoProdotto = p.prezzoProdotto;
                prodotto.ingredienti = p.ingredienti;
                prodotto.tempoConsegna  = p.tempoConsegna;  
                prodotto.fotoProdotto= p.fotoProdotto;
                db.Entry(prodotto).State=EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            prodotti product = db.prodotti.Find(id);
            db.prodotti.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ListaOrdini() {
        
        return View(db.ordini.ToList());
        }

        [HttpGet]
        public ActionResult EditOrdini(int id)
        {

            ordini o = db.ordini.Find(id);
            return View(o);

        }
        [HttpPost]
        public ActionResult EditOrdini(ordini o)
        {
            if (ModelState.IsValid)
            {
                var ordine = db.ordini.Find(o.idOrdini);
                ordine.dataOrdine = o.dataOrdine;
                ordine.indirizzoConsegna = o.indirizzoConsegna;
                ordine.evaso = o.evaso;
                ordine.notaOrdine = o.notaOrdine;
                ordine.totaleOrdine = o.totaleOrdine;
                ordine.fkUtenti = o.fkUtenti;
                db.Entry(ordine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(o);
        }
        [HttpGet]
        public ActionResult DeleteOrdine(int id)
        {
            ordini orders = db.ordini.Find(id);
            db.ordini.Remove(orders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
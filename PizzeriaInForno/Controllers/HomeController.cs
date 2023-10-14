using PizzeriaInForno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzeriaInForno.Controllers
{
    public class HomeController : Controller
    {
        ModelDbContext db = new ModelDbContext();
        public ActionResult Index()
        {


            return View(db.prodotti.ToList());
        }
    }
}

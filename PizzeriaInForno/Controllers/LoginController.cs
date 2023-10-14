using PizzeriaInForno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PizzeriaInForno.Controllers
{

    public class LoginController : Controller
        
    {
        ModelDbContext db = new ModelDbContext();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(utenti u) {
            var utente = db.utenti.FirstOrDefault(user =>
            
                user.username == u.username && user.password == u.password);

            FormsAuthentication.SetAuthCookie(utente.username, false);
            return RedirectToAction("Index", "Home");



        }
        [HttpGet]
         public ActionResult Register() {
        
        return View();
        
        }
        [HttpPost]
        public ActionResult Register(utenti u)
        {
            u.role = "User";
            db.utenti.Add(u);
            db.SaveChanges();
            return RedirectToAction("Login", "Login");
        }
    }
}
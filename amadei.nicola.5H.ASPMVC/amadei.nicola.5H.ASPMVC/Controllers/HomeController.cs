using amadei.nicola._5H.ASPMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace amadei.nicola._5H.ASPMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ElencoUtenti()
        {
            Utenti utenti = new Utenti();
            utenti.Add(new Utente { Nome = "Pamela", Cognome = "Sanchini" });
            utenti.Add(new Utente { Nome = "Onorio", Cognome = "Pompizii" });

            return View(utenti);
        }
    }
}
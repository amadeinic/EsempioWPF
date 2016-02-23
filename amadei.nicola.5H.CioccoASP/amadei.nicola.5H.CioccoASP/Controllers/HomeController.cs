using amadei.nicola._5H.CioccoASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace amadei.nicola._5H.CioccoASP.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListaCioccolatini()
        {
            Cioccolatini scatola = new Cioccolatini();
            scatola.Add(new Cioccolatino() { Marca = "Mars Inc.", Nome = "Bounty", Tipo = "Pralina", Calorie = 300 });
            scatola.Add(new Cioccolatino() { Marca = "Lindt", Nome = "Lindor", Tipo = "Pralina", Calorie = 30 });
            scatola.Add(new Cioccolatino() { Marca = "Majani", Nome = "Cremino FIAT", Tipo = "Cremino", Calorie = 38 });
            scatola.Add(new Cioccolatino() { Marca = "Mars Inc.", Nome = "M&M's", Tipo = "Pralina", Calorie = 250 });
            scatola.Add(new Cioccolatino() { Marca = "Pernigotti", Nome = "Gianduiotto", Tipo = "Cremino", Calorie = 29 });
            scatola.Add(new Cioccolatino() { Marca = "Nestlé", Nome = "Smarties", Tipo = "Pralina", Calorie = 120 });
            return View(scatola);
        }
    }
}
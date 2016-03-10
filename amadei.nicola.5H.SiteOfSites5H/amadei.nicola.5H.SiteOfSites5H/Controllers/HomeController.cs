using amadei.nicola._5H.SiteOfSites5H.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace amadei.nicola._5H.SiteOfSites5H.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            SchoolClass studentsList = new SchoolClass();
            XElement classe = XElement.Load(Server.MapPath("~/App_Data/datas.xml"));
            IEnumerable<XElement> studentsTags = classe.Element("students").Elements("student");
            foreach (XElement xe in studentsTags)
            {
                Student alu = new Student(xe);
                studentsList.Add(alu);     
            }           
            return View(studentsList);           
        }
    }
}
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Raven.Client;
using Tournamin.web.Models;


namespace Tournamin.web.Controllers
{
    public class HomeController : Controller
    {
        readonly IDocumentSession _session;

        public HomeController(IDocumentSession session)
        {
            _session = session;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult AddGroups()
        {
            _session.Store(new Group("A")
            {
                Matches = new List<GroupMatch>
                {
                    new GroupMatch("Norge", "Sverige"), 
                    new GroupMatch("Frankrike", "England"), 
                    new GroupMatch("Latvia", "Romania"),
                    new GroupMatch("Hellas", "Danmark"),
                }
            });
            _session.Store(new Group("B")
            {
                Matches = new List<GroupMatch>
                {
                    new GroupMatch("Finland", "Østerike"), 
                    new GroupMatch("Belgia", "Spania"), 
                    new GroupMatch("Tyskland", "Kosovo"),
                    new GroupMatch("Portugal", "Nederland"),
                }
            });
            _session.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }
    }
}
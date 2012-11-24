using System;
using System.Collections.Generic;
using System.Linq;
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
                Teams = new List<Team>{new Team("Norge"), new Team("Sverige"), new Team("Hellas"), new Team("England")},

                Matches = new List<GroupMatch>
                {
                    new GroupMatch("Norge", "Sverige"), 
                    new GroupMatch("Hellas", "England"),
                    new GroupMatch("England", "Norge"),
                    new GroupMatch("Hellas", "Sverige"),
                    new GroupMatch("Norge", "Hellas"),
                    new GroupMatch("Sverige", "England")
                }
            });
            _session.Store(new Group("B")
            {
                Teams = new List<Team>{new Team("Finland"), new Team("Østerike"), new Team("Belgia"), new Team("Spania")},
                Matches = new List<GroupMatch>
                {
                    new GroupMatch("Finland", "Østerike"), 
                    new GroupMatch("Belgia", "Spania"),
                    new GroupMatch("Spania", "Finland"),
                    new GroupMatch("Belgia", "Østerike"),
                    new GroupMatch("Finland", "Spania"),
                    new GroupMatch("Østerike", "Spania")
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

        public ActionResult Save(string group,IList<GroupMatch> matches)
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Index()
        {
            return View(_session.Query<Group>().OrderBy(x => x.GroupName).ToList());
        }
    }
}
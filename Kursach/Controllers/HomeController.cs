using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BLL.Db;
using Microsoft.AspNetCore.Mvc;
using Kursach.Models;
using BOL;
using MVC_Web.Controllers;

namespace Kursach.Controllers
{
    public class HomeController : BaseController
    {      
        public HomeController(CyberTrainingContext context) : base(context)
        {
            db = new AllDb(context);
            if (!db.RoleDb.GetAll().Any())
            {
                db.RoleDb.FillRoles();
                db.UserDb.InsertAdmin();
            }
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

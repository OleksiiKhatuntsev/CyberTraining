using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BLL.Db;
using Microsoft.AspNetCore.Mvc;
using Kursach.Models;
using BOL;
using Microsoft.AspNetCore.Authorization;
using MVC_Web.Controllers;
using UserTrackingService;

namespace Kursach.Controllers
{
    public class HomeController : BaseController
    {
        private UserTrackingHelper userHelper;

        public HomeController(CyberTrainingContext context) : base(context)
        {
            db = new AllDb(context);
            userHelper = new UserTrackingHelper(context);

            if (!db.RoleDb.GetAll().Any())
            {
                db.GenreDb.FillGenres();
                db.GameDb.FillGames();
                db.TeamDb.CreateNewbeeTeam();
                db.RoleDb.FillRoles();
                db.UserDb.InsertAdmin();
                db.UserDb.InsertFewUsers();
                foreach (var user in db.UserDb.GetAll())
                {
                    if (db.KillDb.GetById(user.UserId) == null && user.RoleId == db.RoleDb.GetAll().First(x=>x.RoleName == "Player").RoleId)
                    {
                        userHelper.SetUserSettings(user.UserId);
                    }
                }
            }
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult About()
        {
            ViewData["Message"] = "Description";

            return View();
        }

        [Authorize(Roles = "notAdmin")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

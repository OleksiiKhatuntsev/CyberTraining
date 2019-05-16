using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserTrackingService;

namespace MVC_Web.Controllers
{
    [Authorize]
    public class TrainerController : BaseController
    {
        private UserTrackingHelper userHelper;

        public TrainerController(CyberTrainingContext context) : base(context)
        {
            userHelper = new UserTrackingHelper(context);
        }

        public IActionResult Index()
        {
            var players = db.UserDb.GetAll().Where(x => x.Role.RoleName == "Player");
            var currentRole = db.RoleDb.GetAll().FirstOrDefault(x =>
                x.RoleId == db.UserDb.GetAll().FirstOrDefault(y => y.UserName == User.Identity.Name).RoleId).RoleName;

            if (currentRole == "Trainer")
            {
                return RedirectToAction("PlayersView");
            }

            return View("BecomeATrainer");
        }

        public IActionResult BecomeTrainer()
        {
            var user = db.UserDb.GetAll().First(x => x.UserName == User.Identity.Name);
            user.RoleId = db.RoleDb.GetAll().First(x => x.RoleName == "Trainer").RoleId;
            db.UserDb.Update(user);
            return RedirectToAction("Index");
        }

        public IActionResult PlayersView()
        {
            userHelper.UpdateUserSettings();
            var kills = db.KillDb.GetAll();
            return View("MyPlayers", kills);
        }
    }
}
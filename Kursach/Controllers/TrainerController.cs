using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Web.Controllers
{
    [Authorize]
    public class TrainerController : BaseController 
    {
        public TrainerController(CyberTrainingContext context) : base(context)
        { }

        public IActionResult Index()
        {
            var currentRole = db.RoleDb.GetAll().FirstOrDefault(x =>
                x.RoleId == db.UserDb.GetAll().FirstOrDefault(y => y.UserName == User.Identity.Name).RoleId).RoleName;

            if (currentRole == "Trainer")
            {
                return View("MyPlayers");
            }

            return View("BecomeATrainer");
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOL;
using BOL.Models;
using ConditionsService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_Web.Controllers
{
    [Authorize(Roles = "Administrator, Trainer, Player")]
    public class TeamController : BaseController
    {
        private ConditionsHelper conditionsHelper;

        public TeamController(CyberTrainingContext context) : base(context)
        {
            conditionsHelper = new ConditionsHelper(context);
        }

        public IActionResult TeamList()
        {
            return View(db.TeamDb.GetAll());
        }

        public IActionResult CreateTeam()
        {
            List<SelectListItem> games = new List<SelectListItem>();
            int counter = 0;
            foreach (var game in db.GameDb.GetAll())
            {
                games.Add(new SelectListItem(game.GameName, game.GameName));
                counter++;
            }
            ViewBag.GameName = games;

            return View();
        }

        [HttpPost]
        public IActionResult CreateTeam(Team team)
        {
            // ReSharper disable once PossibleNullReferenceException
            team.GameId = db.GameDb.GetAll().FirstOrDefault(x => x.GameName == team.Game.GameName).GameId;
            db.TeamDb.Insert(team);
            return RedirectToAction("CreateTeam", "Team");
        }

        public IActionResult JoinTeam(int teamId)
        {
            User user = db.UserDb.GetAll().FirstOrDefault(x => x.UserName == User.Identity.Name);
            user.TeamId = teamId;
            db.UserDb.Update(user);
            return RedirectToAction("TeamList", "Team");
        }

        public IActionResult TeamConditions()
        {
            conditionsHelper.GetConditionsFromDevice();
            var currentUser = db.UserDb.GetAll().FirstOrDefault(x => x.UserName == User.Identity.Name);
            var userList = db.UserDb.GetAll().Where(x => currentUser != null && x.TeamId == currentUser.TeamId);
            List<Condition> conditionsList = new List<Condition>();
            foreach (var user in userList)
            {
                conditionsList.Add(db.ConditionDb.GetAll().LastOrDefault(x => x.UserId == user.UserId));
            }

            ViewBag.Team = db.TeamDb.GetById(currentUser.TeamId).TeamName;
            return View(conditionsList);
        }
    }
}
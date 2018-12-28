using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOL;
using BOL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : BaseController
    {
        public AdminController(CyberTrainingContext context) : base(context)
        { }

        public IActionResult UserList()
        {
            var users = db.UserDb.GetAll();
            return View(users);
        }

        public IActionResult DeleteUser(int userId)
        {
            db.UserDb.Delete(userId);
            return RedirectToAction("UserList");
        }

        public IActionResult ApproveUser(int userId)
        {
            User user = db.UserDb.GetById(userId);
            // ReSharper disable once PossibleNullReferenceException
            user.RoleId = db.RoleDb.GetAll().FirstOrDefault(x => x.RoleName == "Player").RoleId;
            db.UserDb.Update(user);
            return RedirectToAction("UserList");
        }

        public IActionResult DeleteTeam(int teamId)
        {
            db.TeamDb.Delete(teamId);
            return RedirectToAction("TeamList", controllerName: "Team");
        }
    }
}
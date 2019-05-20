using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BOL;
using BOL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserTrackingService;

namespace MVC_Web.Controllers
{
    public class ParentsControlController : BaseController
    {
        private UserTrackingHelper userHelper;

        public ParentsControlController(CyberTrainingContext context) : base(context)
        {
            userHelper = new UserTrackingHelper(context);
        }

        public IActionResult Index()
        {
            var user = db.UserDb.GetAll().First(x => x.UserName == User.Identity.Name);
            if (user.Role.RoleName == "Parent")
            {
                return RedirectToAction("AllUserList");
            }
            return RedirectToAction("BecomeParent");
        }

        public IActionResult BecomeParent()
        {
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Parent")]
        public IActionResult AllUserList()
        {
            var parentId = db.UserDb.GetAll().First(x => x.UserName == User.Identity.Name).UserId;
            var parentsControls = db.ParentsControlDb.GetAll().Where(x => x.UserId == parentId);
            var users = new List<User>();
            foreach (var user in db.UserDb.GetAll().Where(x => x.Role.RoleName == "Player"))
            {
                if (db.ParentsControlDb.GetAll().Count(x => x.KillId == user.UserId && x.UserId == parentId) == 0)
                {
                    users.Add(user);
                }
            }
            return View(users);
        }

        [Authorize(Roles = "Parent")]
        public IActionResult MySubscribes()
        {
            var parentId = db.UserDb.GetAll().First(x => x.UserName == User.Identity.Name).UserId;
            var mySubscribes = db.ParentsControlDb.GetAll().Where(x => x.UserId == parentId);
            userHelper.UpdateUserSettings();
            return View("MySubscribes", mySubscribes);
        }

        [Authorize(Roles = "Parent")]
        public IActionResult Subscribe(int id)
        {
            var parentId = db.UserDb.GetAll().First(x => x.UserName == User.Identity.Name).UserId;
            db.ParentsControlDb.Insert(new ParentsControl {UserId = parentId, KillId = id});
            return RedirectToAction("AllUserList");
        }

        [Authorize(Roles = "Parent")]
        public IActionResult UnSubscribe(int id)
        {
            db.ParentsControlDb.Delete(id);
            return RedirectToAction("MySubscribes");
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOL;
using BOL.Models;
using ConditionsService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Web.Controllers
{
    [Authorize]
    public class ProfileController : BaseController
    {
        private ConditionsHelper conditionsHelper;

        public ProfileController(CyberTrainingContext context) : base(context)
        {
            conditionsHelper = new ConditionsHelper(context);
        }

        public IActionResult ViewProfile()
        {
            User user = db.UserDb.GetAll().FirstOrDefault(x => x.UserName == User.Identity.Name);
            return View(user);
        }

        public IActionResult MyConditions()
        {
            conditionsHelper.GetConditionsFromDevice();
            var conditionsList = db.ConditionDb.GetAll().Where(x =>
                x.UserId == db.UserDb.GetAll().FirstOrDefault(y => y.UserName == User.Identity.Name).UserId);
            return View(conditionsList);
        }
    }
}
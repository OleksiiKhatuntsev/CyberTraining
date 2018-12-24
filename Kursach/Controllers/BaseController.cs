using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Db;
using BOL;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Web.Controllers
{
    public class BaseController : Controller
    {
        protected AllDb db;

        public BaseController(CyberTrainingContext context)
        {
            db = new AllDb(context);
        }
    }
}
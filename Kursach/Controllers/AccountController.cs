﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BOL;
using BOL.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Web.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(CyberTrainingContext context) : base(context)
        { }

        [HttpGet]
        public IActionResult Login()
        {
            return View("Authorization");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User user)
        {
            
            User getAuthUser = db.UserDb
                    .GetAll().FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
            if (getAuthUser != null)
            {
                user.Role = db.RoleDb.GetById(
                    // ReSharper disable once PossibleNullReferenceException
                    db.UserDb.GetAll().FirstOrDefault(x => user != null && x.UserName == user.UserName).RoleId);
                Authenticate(user);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View("Authorization", user);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                bool checkForExistingUser = db.UserDb.GetAll().FirstOrDefault(x => x.UserName == user.UserName) == null;
                if (checkForExistingUser)
                {
                    // ReSharper disable once PossibleNullReferenceException
                    user.RoleId = db.RoleDb.GetAll().FirstOrDefault(x => x.RoleName == "NonApproved").RoleId;
                    user.TeamId = 1;
                    user.Role = db.RoleDb.GetById(user.RoleId);
                    db.UserDb.Insert(user);
                    Authenticate(user);
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    ModelState.AddModelError("", "This user already exist");
                }
            }

            return View(user);
        }

        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        private void Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.RoleName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
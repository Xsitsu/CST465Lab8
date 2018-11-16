using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CST465Lab8.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CST465Lab8.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private RoleManager<IdentityRole> _RoleManager;
        public AdminController(RoleManager<IdentityRole> rm)
        {
            _RoleManager = rm;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRole(string RoleName)
        {
            IdentityRole role = new IdentityRole();
            role.Name = RoleName;
            IdentityResult result = _RoleManager.CreateAsync(role).Result;
            return RedirectToAction("Index");
        }
    }
}
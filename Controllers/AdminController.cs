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
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private RoleManager<IdentityRole> _RoleManager;
        private UserManager<CST465Lab8User> _UserManager;
        public AdminController(RoleManager<IdentityRole> rm, UserManager<CST465Lab8User> um)
        {
            _RoleManager = rm;
            _UserManager = um;
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
        [HttpPost]
        public IActionResult AddUserToRole(string Email, string RoleName)
        {
            CST465Lab8User user = _UserManager.FindByEmailAsync(Email).Result;
            IdentityResult result = _UserManager.AddToRoleAsync(user, RoleName).Result;
            //Check the status of the result
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.Select(e => e.Description).Aggregate((a, b) => a + "," + b));

            }
            return RedirectToAction("Index");
        }
    }
}
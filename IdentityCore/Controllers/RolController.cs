using IdentityCore.Context;
using IdentityCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityCore.Controllers
{
    [Authorize]
    public class RolController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        public RolController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View(_roleManager.Roles.ToList());
        }
        public IActionResult AddRole()
        {
            return View(new RoleViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppRole appRole = new AppRole()
                {
                    Name = model.Name
                };
               var IdentityResult= await  _roleManager.CreateAsync(appRole);
                if (IdentityResult.Succeeded)
                {
                    return RedirectToAction("Index");

                }
                foreach (var error in IdentityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description); 
                }
            }
            return View(new RoleViewModel());
        }
    }
}

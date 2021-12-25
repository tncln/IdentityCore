using IdentityCore.Context;
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
    }
}

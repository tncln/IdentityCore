﻿using IdentityCore.Context;
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
    public class PanelController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public PanelController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
           var user= await _userManager.FindByNameAsync(User.Identity.Name);
            return View(user);
        }
        public async Task<IActionResult> UpdateUser()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel {
             Email=user.Email,
              Name=user.Name,
               PhoneNumber=user.PhoneNumber,
                PictureUrl=user.PictureUrl,
                 SurName=user.SurName
            };
            return View(model);
        }
        [AllowAnonymous]
        public IActionResult HerkesErissin()
        {
            return View();
        }
    }
}

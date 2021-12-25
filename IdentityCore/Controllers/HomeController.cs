using IdentityCore.Context;
using IdentityCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View(new SignInViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> GirisYap(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, true);

                if (result.IsLockedOut)
                {
                    var gelen = await _userManager.GetLockoutEndDateAsync(await _userManager.FindByNameAsync(model.UserName));

                    var kisitlananSure = gelen.Value;
                    var kalanDakika = kisitlananSure.Minute - DateTime.Now.Minute;
                     
                    ModelState.AddModelError("", $"5 kere yanlış giriş yaptığınız için Hesabınız kilitlendi. Hesabınız kalan dakika {kalanDakika} kadar kilitlenmiştir. ");
                    return View("Index", model);
                }
                if (result.IsNotAllowed)
                {
                    ModelState.AddModelError("", $"Önce lütfen email adresinizi doğrulayınız..");
                    return View("Index", model);
                }
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Panel");
                }
                var failedCount = await _userManager.GetAccessFailedCountAsync(await _userManager.FindByNameAsync(model.UserName));
                ModelState.AddModelError("", $"Kullanıcı Adı veya Şifre Hatalı {5 - failedCount} kadar yanlış girme hakkınız kaldı");
            }
            return View("Index", model);
        }
        public IActionResult KayitOl()
        {
            return View(new UserSignUpViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> KayitOl(UserSignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    Email = model.Email,
                    Name = model.Name,
                    SurName = model.SurName,
                    UserName = model.UserName
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
    }
}

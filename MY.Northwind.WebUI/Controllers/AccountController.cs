using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MY.Northwind.WebUI.Entity;
using MY.Northwind.WebUI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MY.Northwind.WebUI.Controllers
{
    public class AccountController : Controller
    {

        private UserManager<CustomIdentityUser> _userManager;

        private RoleManager<CustomIdentityRole> _roleManager;

        private SignInManager<CustomIdentityUser> _signInManager;

        public AccountController(UserManager<CustomIdentityUser> userManager, RoleManager<CustomIdentityRole> roleManager, SignInManager<CustomIdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public ActionResult Register()
        {

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {

            if (ModelState.IsValid)
            {
                CustomIdentityUser user = new CustomIdentityUser
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email
                };
                IdentityResult result = 
                    _userManager.CreateAsync(user, registerViewModel.Password).Result;
                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("Admin").Result)
                        //sistemde admin diye bir role var mı kontrolü
                    {
                        CustomIdentityRole role = new CustomIdentityRole
                        {
                            Name="Admin"
                            //role yoksa burada yeni role oluşturuldu.
                        };
                        IdentityResult roleResult = _roleManager.CreateAsync(role).Result;

                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("", "We couldn't add the role!");
                            return View(registerViewModel);
                        }
                    }

                    //role manager yoksa role manager oluşturulur:
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                    //kullanıcıya rol ekleme işlemini addtorole ile gerçekleştiriyoruz.
                    return RedirectToAction("Login", "Account");
                }

            }
            return View(registerViewModel);
        }


        public ActionResult Login()
        {

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult  Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password,
                    loginViewModel.RememberMe, false).Result;

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Admin");
                }
                ModelState.AddModelError("","Invalid login!");
            }
            return View(loginViewModel);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Logoff()
        {

            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Login");

        }
    }
}

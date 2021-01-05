using BLL.DTOs.User;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentsSystem.Controllers
{
    
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login(string returnUrl) // identity manages to pass returnUrl to this
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError("", "Invalid email or password");
            }
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}

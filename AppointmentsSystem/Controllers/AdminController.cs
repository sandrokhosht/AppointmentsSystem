using AppointmentsSystem.Models;
using BLL.DTOs.User;
using BLL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentsSystem.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<User> _userManager;
        private IUserOperation _userOperation;
        

        public AdminController(UserManager<User> userManager, IUserOperation userOperation)
        {
            _userManager = userManager;
            _userOperation = userOperation;
        }

        public IActionResult Index()
        {
            UserListVM model = new UserListVM
            {
                Users = _userOperation.GetAll()
                
            };
            return View(model);
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        /*[HttpPost]
        public async Task<IActionResult> CreateUser(UserCUDTO model)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    
                };

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach(IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(model);
        }*/
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCUVM model)
        {
            if (ModelState.IsValid)
            {
                model.User.UserName = model.User.Email;

                var result = await _userOperation.CreateUserAsync(model.User);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(model);
        }
    }
}

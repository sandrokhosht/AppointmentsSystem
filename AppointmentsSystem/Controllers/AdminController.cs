using AppointmentsSystem.Models;
using BLL.DTOs.User;
using BLL.Interfaces;
using BLL.Operations;
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
    public class AdminController : Controller
    {
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private readonly IAppointmentOperation _appointmentOperation;

        public AdminController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IAppointmentOperation appointmentOperation)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _appointmentOperation = appointmentOperation;
        }

        public IActionResult Index()
        {
            return View(_userManager.Users);
        }

        public async Task<IActionResult> EditUser(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            UserCUVM model = new UserCUVM
            {
                User = await _appointmentOperation.GetUser(id)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(UserCUVM model)
        {
            var role = await _roleManager.FindByNameAsync(model.RoleName);
            await _appointmentOperation.AddUserToRole(model.User, model.RoleName);
            await _roleManager.UpdateAsync(role);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CreateUser()
        {
            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCUDTO model)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    Email = model.Email,
                    UserName = model.Email,
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
        }

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleVM model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                var result = await _roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            
            return View(model);
        }
    }
}

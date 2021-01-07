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
        private IUserOperation _userOperation;
        private IRoleOperation _roleOperation;
        

        public AdminController(IUserOperation userOperation, IRoleOperation roleOperation)
        {
            _userOperation = userOperation;
            _roleOperation = roleOperation;
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

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleCUVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleOperation.CreateRoleAsync(model.Role);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(CreateRole));
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

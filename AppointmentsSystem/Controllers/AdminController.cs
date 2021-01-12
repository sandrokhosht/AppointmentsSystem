using AppointmentsSystem.Models;
using BLL.DTOs.Role;
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
        private readonly IUserOperation _userOperation;
        private readonly IRoleOperation _roleOperation;


        public AdminController(IUserOperation userOperation, IRoleOperation roleOperation)
        {
            _userOperation = userOperation;
            _roleOperation = roleOperation;
        }

        public IActionResult Index()
        {
            var model = new UserListVM
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

        public IActionResult RoleList()
        {
            var model = new RoleListVM
            {
                Roles = _roleOperation.GetAllRoles()
            };

            return View(model); 
        }


        // Role ID is passed from the URL to the action
        public async Task<IActionResult> EditRole(string id)
        {
            // Find the role by Role ID
            var role = await _roleOperation.FindRoleByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }

            var model = new RoleCUVM
            {
                Role = new RoleCUDTO
                {
                    Name = role.Name,
                    Id = role.Id
                }
            };


           // _userManager.AddToRoleAsync(myuser, model.Role.Name);

            foreach (var user in _userOperation.GetAll().ToList())
            {
                var isInRole = await _userOperation.IsUserInRoleAsync(user, model.Role.Name);
                if (isInRole)
                {
                    model.Users.Add(user);
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(RoleCUVM model)
        {
            var role = await _roleOperation.FindRoleByIdAsync(model.Role.Id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {model.Role.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                role.Name = model.Role.Name;

                var result = await _roleOperation.UpdateRoleAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(RoleList));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }
    }
}

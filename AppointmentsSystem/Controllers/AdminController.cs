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

        public async Task<IActionResult> EditUser(string id)
        {
            var user = new UserCUVM
            {
                User = await _userOperation.GetUserByIdAsync(id)
            };

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(UserCUVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userOperation.UpdateRoleAsync(model.User);
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
            var role = await _roleOperation.GetRoleByIdAsync(id);

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
            var role = await _roleOperation.GetRoleByIdAsync(model.Role.Id);

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
        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;

            var role = await _roleOperation.GetRoleByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            var model = new List<UserRoleVM>();

            foreach (var user in _userOperation.GetAll()) // add .tolist if needed
            {
                var userRoleViewModel = new UserRoleVM
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (await _userOperation.IsUserInRoleAsync(user,role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }

                model.Add(userRoleViewModel);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleVM> model, string roleId)
        {

            var role = await _roleOperation.GetRoleByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var userModel = new UserCUVM
                {
                    User = await _userOperation.GetUserByIdAsync(model[i].UserId)
                };


                IdentityResult result = null;

                if (model[i].IsSelected && !(await _userOperation.IsUserInRoleAsync(userModel.User, role.Name)))
                {
                    result = await _userOperation.AddUserToRoleAsync(userModel.User, role.Name);
                }
                else if (!model[i].IsSelected && await _userOperation.IsUserInRoleAsync(userModel.User, role.Name))
                {
                    result = await _userOperation.RemoveUserFromRoleAsync(userModel.User, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditRole", new { Id = roleId });
                }
            }

            return RedirectToAction("EditRole", new { Id = roleId });
        }
    }
}

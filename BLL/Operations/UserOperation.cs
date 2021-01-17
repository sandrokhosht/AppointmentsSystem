using AutoMapper;
using BLL.DTOs.User;
using BLL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Operations
{
    public class UserOperation : IUserOperation
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;

        public UserOperation(IUOW uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public IEnumerable<UserCUDTO> GetAll()
        {
            var model = _uow.User.FindAll();
            var users = _mapper.Map<IEnumerable<UserCUDTO>>(model);
            return users;
        }     

        public async Task<IdentityResult> CreateUserAsync(UserCUDTO model)     // Gets UserReadDTO as argument , transforms it into User entity class,
        {                                                                      // calls method Service/Repositories/UOW.User.CreateAsync(***) returns IdentityResult
            var user = _mapper.Map<User>(model);                               // errors(if there are any).
            var result = await _uow.User.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                _uow.Commit();
            }

            return result;
        }

        public async Task<bool> IsUserInRoleAsync(UserCUDTO model, string roleName)
        {
            var user = _mapper.Map<User>(model);
            var isInRole = await _uow.User.IsInRoleAsync(user, roleName);
            return isInRole;
        }

        public async Task<UserCUDTO> GetUserByIdAsync(string id)
        {
            var model = await _uow.User.FindByIdAsync(id);
            var user = _mapper.Map<UserCUDTO>(model);
            return user;
        }

        public async Task<IdentityResult> AddUserToRoleAsync(UserCUDTO model, string roleName)
        {
            var user = _mapper.Map<User>(model);
            var result = await _uow.User.AddToRoleAsync(user, roleName);
            return result;
        }
        public async Task<IdentityResult> RemoveUserFromRoleAsync(UserCUDTO model, string roleName)
        {
            var user = _mapper.Map<User>(model);
            var result = await _uow.User.RemoveFromRoleAsync(user, roleName);
            return result;
        }
    }
}

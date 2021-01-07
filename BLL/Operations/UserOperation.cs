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

        public IEnumerable<UserReadDTO> GetAll()
        {
            var model = _uow.User.FindAll();
            var users = _mapper.Map<IEnumerable<UserReadDTO>>(model);
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

        public async Task<bool> IsUserInRoleAsync(UserReadDTO model, string roleName)
        {
            var user = _mapper.Map<User>(model);
            var isInRole = await _uow.User.IsInRoleAsync(user, roleName);
            return isInRole;
        }
    }
}

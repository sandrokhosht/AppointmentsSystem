using BLL.DTOs.User;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserOperation
    {
        public IEnumerable<UserCUDTO> GetAll();

        public Task<IdentityResult> CreateUserAsync(UserCUDTO user);

        public Task<bool> IsUserInRoleAsync(UserCUDTO user, string roleName);

        public Task<UserCUDTO> GetUserByIdAsync(string id);

        public Task<IdentityResult> AddUserToRoleAsync(UserCUDTO user, string roleName);

        public Task<IdentityResult> RemoveUserFromRoleAsync(UserCUDTO model, string roleName);

        public Task<IdentityResult> UpdateRoleAsync(UserCUDTO model);

    }
}

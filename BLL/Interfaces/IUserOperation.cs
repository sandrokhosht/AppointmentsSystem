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
        public IEnumerable<UserReadDTO> GetAll();

        public Task<IdentityResult> CreateUserAsync(UserCUDTO user);

        public Task<bool> IsUserInRoleAsync(UserReadDTO user, string roleName);

    }
}

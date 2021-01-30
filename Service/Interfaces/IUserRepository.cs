using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        public Task<IdentityResult> CreateAsync(User user, string password);

        public Task<User> FindByEmailAsync(string email);

        public Task<bool> IsInRoleAsync(User user, string roleName);

        public Task<User> FindByIdAsync(string id);

        public Task<IdentityResult> AddToRoleAsync(User user, string roleName);

        public Task<IdentityResult> RemoveFromRoleAsync(User user, string roleName);

        public Task<IdentityResult> UpdateAsync(User user);

    }
}

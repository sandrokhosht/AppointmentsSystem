using DAL.Context;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private UserManager<User> _userManager { get; set; }

        public UserRepository(ApplicationDbContext context, UserManager<User> userManager)
            : base(context)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateAsync(User user, string password)
        {
            IdentityResult result = await _userManager.CreateAsync(user, password);           
            return result;
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;           
        }

        public async Task<bool> IsInRoleAsync(User user, string roleName)
        {
            bool isInRole = await _userManager.IsInRoleAsync(user, roleName);
            return isInRole;
        }

        public async Task<User> FindByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            //var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Id == id); // avoiding tracking exception
            return user;
        }

        public async Task<IdentityResult> AddToRoleAsync(User user, string roleName)
        {
            var result = await _userManager.AddToRoleAsync(user, roleName);
            return result;
        }

        public async Task<IdentityResult> RemoveFromRoleAsync(User user, string roleName)
        {
            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
            return result;
        }

    }
}

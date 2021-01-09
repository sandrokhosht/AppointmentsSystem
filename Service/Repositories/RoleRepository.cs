using DAL.Context;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repositories
{
    public class RoleRepository : RepositoryBase<IdentityRole>, IRoleRepository
    {
        private RoleManager<IdentityRole> _roleManager { get; set; }

        public RoleRepository(ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
            : base(context)
        {
            _roleManager = roleManager;
        }
        public async Task<IdentityResult> CreateAsync(string roleName)
        {
            var role = new IdentityRole
            {
                Name = roleName
            };

            var result = await _roleManager.CreateAsync(role);

            return result;
        }

        public IEnumerable<IdentityRole> GetAll()
        {
            var roles = _roleManager.Roles;
            return roles;
        }

        public async Task<IdentityRole> FindByIdAsync(string id)
        {
            
            var role = await _roleManager.FindByIdAsync(id);
            return role;
        }

        public async Task<IdentityResult> UpdateAsync(IdentityRole role)
        {
            var result = await _roleManager.UpdateAsync(role);
            return result;

        }
    }
}

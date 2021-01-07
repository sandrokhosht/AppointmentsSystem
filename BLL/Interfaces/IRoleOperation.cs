using BLL.DTOs.Role;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRoleOperation
    {
        public Task<IdentityResult> CreateRoleAsync(RoleCUDTO model);

        public IEnumerable<IdentityRole> GetAllRoles();

        public Task<RoleCUDTO> FindRoleByIdAsync(string id);

        public Task<IdentityResult> UpdateRoleAsync(RoleCUDTO model);
        
    }
}

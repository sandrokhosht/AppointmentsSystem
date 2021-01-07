using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IRoleRepository
    {
        public Task<IdentityResult> CreateAsync(string roleName);

        public IEnumerable<IdentityRole> GetAll();

        public Task<IdentityRole> FindByIdAsync(string id);

        public Task<IdentityResult> UpdateAsync(IdentityRole role);
    }
}

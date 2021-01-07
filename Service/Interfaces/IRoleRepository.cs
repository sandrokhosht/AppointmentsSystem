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
    }
}

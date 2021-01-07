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
    }
}

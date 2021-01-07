using AutoMapper;
using BLL.DTOs.Role;
using BLL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Operations
{
    public class RoleOperation : IRoleOperation
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;

        public RoleOperation(IUOW uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IdentityResult> CreateRoleAsync(RoleCUDTO model)
        {
            var role = _mapper.Map<IdentityRole>(model);
            var result = await _uow.Role.CreateAsync(role.Name);
            await _uow.CommitAsync();
            return result;
        }
    }
}

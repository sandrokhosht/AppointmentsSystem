using AutoMapper;
using BLL.DTOs.Role;
using BLL.Interfaces;
using DAL.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;
using Service.Repositories;
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

        public async Task<RoleCUDTO> FindRoleByIdAsync(string id)
        {
            var role = await _uow.Role.FindByIdAsync(id);
            var model = _mapper.Map<RoleCUDTO>(role);
            return model;

        }

        public IEnumerable<IdentityRole> GetAllRoles()
        {
            var roles = _uow.Role.GetAll();
            return roles;
        }

        public async Task<IdentityResult> UpdateRoleAsync(RoleCUDTO model)
        {
            var role = await _uow.Role.FindByIdAsync(model.Id);     // Getting role by provided id
            role.Name = model.Name;                                 // changing model's name by provided one from model
            var changedModel = _mapper.Map<IdentityRole>(role);      // Mapping it to return appropriate value
            var result = await _uow.Role.UpdateAsync(changedModel);  // Updates context itself , no need to call _uow.Commit()
            return result;                                          // Returns result of above method
        }

        



    }
}

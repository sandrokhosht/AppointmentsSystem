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

        public async Task<RoleCUDTO> GetRoleByIdAsync(string id)
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
            // Getting role by provided id
            var role = await _uow.Role.FindByIdAsync(model.Id);
            // changing model's name by provided one from model
            role.Name = model.Name;
                                                                                                //   var role = _mapper.Map<IdentityRole>(model); **Tracking error**
            // Updates context itself , no need to call _uow.Commit()
            var result = await _uow.Role.UpdateAsync(role);
            // Returns result of above method
            return result;                                          
        }

        



    }
}

using AutoMapper;
using BLL.DTOs.Appointment;
using BLL.DTOs.User;
using BLL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Operations
{
    public class AppointmentOperation : IAppointmentOperation
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        

        public AppointmentOperation(IUOW uow, IMapper mapper, UserManager<User> userManager)
        {
            _uow = uow;
            _mapper = mapper;
            _userManager = userManager;
        }

        public IEnumerable<AppointmentReadDTO> GetAll()
        {
            var appointments = _uow.Appointment.FindAll();
            return _mapper.Map<IEnumerable<AppointmentReadDTO>>(appointments);
        }

        public void CreateAppointment(AppointmentCUDTO model)
        {
            var appointment = _mapper.Map<Appointment>(model);
            _uow.Appointment.Create(appointment);
            _uow.Commit();
        }

        public AppointmentReadDTO GetAppointment(int id)
        {
            var model = _uow.Appointment.Get(id);
            var appointment = _mapper.Map<AppointmentReadDTO>(model);
            return appointment;
        }

        // USER OPERATION
        public async Task<UserCUDTO> GetUser(string id)
        {
            var model = await _userManager.FindByIdAsync(id);
            var user = _mapper.Map<UserCUDTO>(model);
            return user;
        }
        
        public async Task AddUserToRole(UserCUDTO model,string roleName)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            await _userManager.AddToRoleAsync(user, roleName);
            
        }
    }
}

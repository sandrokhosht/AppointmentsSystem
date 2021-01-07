using DAL.Context;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repositories
{
    public class UOW : IUOW
    {
        private ApplicationDbContext _context { get; set; }

        private UserManager<User> _userManager { get; set; }

        private RoleManager<IdentityRole> _roleManager { get; set; }

        private IAppointmentRepository _appointmentRepository;

        private IUserRepository _userRepository;

        private IRoleRepository _roleRepository;

        public UOW(ApplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IAppointmentRepository Appointment {

            get
            {
                if (_appointmentRepository == null)
                    _appointmentRepository = new AppointmentRepository(_context);
                return _appointmentRepository;
            }
            
        }

        public IUserRepository User
        {
            get
            
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_context, _userManager);
                return _userRepository;
            }

        }

        public IRoleRepository Role
        {
            get

            {
                if (_roleRepository == null)
                    _roleRepository = new RoleRepository(_context, _roleManager);
                return _roleRepository;
            }

        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}

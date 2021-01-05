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

        private IAppointmentRepository _appointmentRepository;

        private IUserRepository _userRepository;

        public UOW(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
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

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}

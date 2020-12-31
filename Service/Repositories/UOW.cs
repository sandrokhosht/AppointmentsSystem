using DAL.Context;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Repositories
{
    public class UOW : IUOW
    {
        private AppointmentDbContext _context { get; set; }

        private IAppointmentRepository _appointmentRepository;
        public UOW(AppointmentDbContext context)
        {
            _context = context;
        }

        public IAppointmentRepository Appointment {

            get
            {
                if (_appointmentRepository == null)
                    _appointmentRepository = new AppointmentRepository(_context);
                return _appointmentRepository;
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

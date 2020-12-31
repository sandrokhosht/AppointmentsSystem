using DAL.Context;
using DAL.Entities;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Repositories
{
    public class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(AppointmentDbContext context)
            : base(context)
        {
        }
    }
}

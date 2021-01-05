using DAL.Context;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Repositories
{
    public class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}

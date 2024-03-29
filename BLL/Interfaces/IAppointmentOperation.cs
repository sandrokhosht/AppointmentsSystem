﻿using BLL.DTOs.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAppointmentOperation
    {
        public IEnumerable<AppointmentReadDTO> GetAll();

        public void CreateAppointment(AppointmentCUDTO model);

        public AppointmentReadDTO GetAppointment(int id);
    }
}

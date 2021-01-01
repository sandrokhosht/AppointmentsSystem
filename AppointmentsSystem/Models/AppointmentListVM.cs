using BLL.DTOs.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentsSystem.Models
{
    public class AppointmentListVM
    {
        public IEnumerable<AppointmentListDTO> Appointments { get; set; }
    }
}

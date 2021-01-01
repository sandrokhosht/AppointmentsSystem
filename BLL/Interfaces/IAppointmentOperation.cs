using BLL.DTOs.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAppointmentOperation
    {
        public IEnumerable<AppointmentListDTO> GetAll();

        public void CreateAppointment(AppointmentCUDTO model);
    }
}

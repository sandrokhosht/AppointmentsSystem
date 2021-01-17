using AutoMapper;
using BLL.DTOs.Appointment;
using BLL.Interfaces;
using DAL.Entities;
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

        public AppointmentOperation(IUOW uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
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
            var model = _uow.Appointment.GetById(id);
            var appointment = _mapper.Map<AppointmentReadDTO>(model);
            return appointment;
        }
    }
}

using AutoMapper;
using BLL.DTOs.Appointment;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Appointment, AppointmentListDTO>();

            CreateMap<AppointmentCUDTO, Appointment>();
        }
    }
}

using AutoMapper;
using BLL.DTOs.Appointment;
using BLL.DTOs.User;
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
            CreateMap<Appointment, AppointmentReadDTO>();

            CreateMap<AppointmentCUDTO, Appointment>();

            CreateMap<AppointmentReadDTO, Appointment>();

            CreateMap<User, UserReadDTO>();

            CreateMap<UserReadDTO, User>();

            CreateMap<UserCUDTO, User>();


        }
    }
}

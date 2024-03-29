﻿using AutoMapper;
using BLL.DTOs.Appointment;
using BLL.DTOs.Role;
using BLL.DTOs.User;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
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

            CreateMap<User, UserCUDTO>();

            CreateMap<UserCUDTO, User>();

            CreateMap<UserReadDTO, User>();

            CreateMap<RoleCUDTO, IdentityRole>();

            CreateMap<IdentityRole, RoleCUDTO>();


        }
    }
}

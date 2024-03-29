﻿using BLL.DTOs.Role;
using BLL.DTOs.User;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentsSystem.Models
{
    public class RoleCUVM
    {
        public RoleCUDTO Role { get; set; }

        public List<UserCUDTO> Users { get; set; }


        // Avoiding Nullpointerexception
        public RoleCUVM()
        {
            Users = new List<UserCUDTO>();
        }
    }
}

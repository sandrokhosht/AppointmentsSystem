﻿using BLL.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentsSystem.Models
{
    public class UserCUVM
    {
        public UserCUDTO User { get; set; }
        public string RoleName { get; set; }
    }
}

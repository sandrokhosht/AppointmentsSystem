﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentsSystem.Models
{
    public class CreateRoleVM
    {
        [Required]
        public string RoleName { get; set; }
    }
}

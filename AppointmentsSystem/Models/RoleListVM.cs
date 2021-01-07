using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentsSystem.Models
{
    public class RoleListVM
    {
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}

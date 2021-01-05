using BLL.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentsSystem.Models
{
    public class UserListVM
    {
       public IEnumerable<UserReadDTO> Users { get; set; }
    }
}

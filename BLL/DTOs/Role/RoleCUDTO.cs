using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Role
{
    public class RoleCUDTO
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}

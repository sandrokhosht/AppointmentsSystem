using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Appointment
{
    public class AppointmentCUDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(maximumLength:20, MinimumLength = 2, ErrorMessage = "Field should contain min of 2 and max of 20 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(maximumLength: 20, MinimumLength = 2, ErrorMessage = "Field should contain min of 2 and max of 20 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(maximumLength: 11, MinimumLength = 11, ErrorMessage = "Field should contain 11 characters")]
        [RegularExpression("^[0-9]*", ErrorMessage = "Field should be numeric type")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Required field")]
        [RegularExpression("[F,M]{1}$", ErrorMessage = "Invalid gender field")]
        public char Gender { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(maximumLength: 400, MinimumLength = 2, ErrorMessage = "Field should contain min of 2 and max of 400 characters")]
        public string Description { get; set; }
    }
}

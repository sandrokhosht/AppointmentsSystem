using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Appointment
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public int Gender { get; set; }

        public string Description { get; set; }
    }
}

using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public static class DatabaseInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment()
                {
                    Id = 1,
                    FirstName = "Abc",
                    LastName = "bca",
                    Description = "adadsdasdas",
                    PhoneNumber = "1213231",
                    Gender = 'M',

                });
        }

        
    }
}

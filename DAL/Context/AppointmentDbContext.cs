using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class AppointmentDbContext : DbContext
    {
        public AppointmentDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Appointment>()
                .Property(a => a.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Appointment>()
                .Property(a => a.LastName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Appointment>()
                .Property(a => a.Description)
                .HasMaxLength(400)
                .IsRequired();

            modelBuilder.Entity<Appointment>()
                .Property(a => a.PhoneNumber)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}

using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<IdentityRole> RolesSet { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Appointment>()
                .Property(a => a.FirstName)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Appointment>()
                .Property(a => a.LastName)
                .HasMaxLength(20)
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

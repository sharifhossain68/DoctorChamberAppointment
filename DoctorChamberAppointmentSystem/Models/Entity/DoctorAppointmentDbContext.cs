using DoctorChamberAppointmentMangementSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DoctorChamberAppointmentMangementSystem.Models.Entity
{
    public class DoctorAppointmentDbContext:DbContext
    {
        public DbSet<Login> Login { get; set; }

        public DbSet<Register> Registers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Country> Coutries { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Patient> Patient { get; set; }


    }
}
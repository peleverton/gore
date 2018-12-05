using Gore.Domain.Models;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Gore.Infra.Data.Mappings;
using Microsoft.AspNetCore.Hosting;

namespace Gore.Infra.Data.Context
{
    public class GoreContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        //public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BloodType> BloodTypes { get; set; }
        //public DbSet<MedicalAppointment> MedicalAppointments { get; set; }
        //public DbSet<MedicalProcedure> MedicalProcedures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.ApplyConfiguration(new DoctorMap());
            //modelBuilder.ApplyConfiguration(new PatientMap());
            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new BloodTypeMap());
            //modelBuilder.ApplyConfiguration(new MedicalAppointmentMap());
            //modelBuilder.ApplyConfiguration(new MedicalProcedureMap());


            base.OnModelCreating(modelBuilder);
        }
               
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            

            var config = new  ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            optionsBuilder.UseMySql(config.GetConnectionString("DefaultConnection"));
            //Desabilitar o carregamento preguiçoso.
            //optionsBuilder.UseLazyLoadingProxies();
        }
    }
}

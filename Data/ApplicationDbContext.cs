using Diadiabetes_App.Models;
using Microsoft.EntityFrameworkCore;
using Diadiabetes_App.model;

namespace Diadiabetes_App
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }

        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Medical_Informations> Medical_Informations { get; set; }
        public DbSet<Meals> Meals { get; set; }
        public DbSet<BodyCompositionData> BodyCompositionData { get; set; }
        public DbSet<Graphs> Graphs { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<PatientRecords> PatientRecords { get; set; }
        public DbSet<Account> Account { get; set; }

    }
}

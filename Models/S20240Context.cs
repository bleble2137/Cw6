using Cw6.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Cw6.Models
{
    public class S20240Context : DbContext
    {
        public S20240Context()
        {

        }

        public S20240Context(DbContextOptions<S20240Context> options) : base(options)
        {

        }

        /*
         * Migration commands that can be executed in NuGet Package Manager console:
         * 
         * Add-Migration ShortDescriptionOfMigration
         * Update-database
         * Remove-Migration
         */
        public virtual DbSet<Patient> Patients { get; set; }

        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }

        public virtual DbSet<Medicament> Medicaments { get; set; }
        public virtual DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PatientEf());
            modelBuilder.ApplyConfiguration(new DoctorEf());
            modelBuilder.ApplyConfiguration(new PrescriptionEf());
            modelBuilder.ApplyConfiguration(new MedicamentEf());
            modelBuilder.ApplyConfiguration(new PrescriptionMedicamentEf());
        }
    }
}
using Cw6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Cw6.Configurations
{
    public class DoctorEf : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> entity)
        {
            entity.HasKey(e => e.IdDoctor).HasName("Doctor_pk");
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            entity.ToTable("Doctor");

            IEnumerable<Doctor> e_doctors = new List<Doctor>
                {
                    new Doctor
                    {
                        IdDoctor = 1,
                        FirstName = "Pan",
                        LastName = "Pomidor",
                        Email = "pomidor@tomato.com"
                    },
                    new Doctor
                    {
                        IdDoctor = 2,
                        FirstName = "Ziemniak",
                        LastName = "Le Frytt",
                        Email = "warzywa_sa@zdrowe.com"
                    },
                    new Doctor
                    {
                        IdDoctor = 3,
                        FirstName = "Vasco",
                        LastName = "Da Gama",
                        Email = "podrozojzvasco@boat.com"
                    }
                };

            entity.HasData(e_doctors);
        }
    }
}
using Cw6.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Cw6.Configurations
{
    public class PatientEf : IEntityTypeConfiguration<Patient>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Patient> entity)
        {
            entity.HasKey(e => e.IdPatient).HasName("Patient_pk");
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Birthdate).IsRequired();

            entity.ToTable("Patient");

            IEnumerable<Patient> e_patients = new List<Patient>
                {
                    new Patient {
                        IdPatient = 1,
                        FirstName = "Wolfgang",
                        LastName = "Mozart",
                        Birthdate = DateTime.Parse("1756-01-27")
                    },
                    new Patient {
                        IdPatient = 2,
                        FirstName = "Frederic",
                        LastName = "Chopin",
                        Birthdate = DateTime.Parse("1849-10-17")
                    },
                    new Patient {
                        IdPatient = 3,
                        FirstName = "Jerzy",
                        LastName = "Krawczk",
                        Birthdate = DateTime.Parse("1921-08-24")
                    },
                };

            entity.HasData(e_patients);
        }
    }
}
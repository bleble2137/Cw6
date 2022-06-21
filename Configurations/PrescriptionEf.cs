using Cw6.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Cw6.Configurations
{
    public class PrescriptionEf : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Prescription> entity)
        {
            entity.HasKey(e => e.IdPrescription).HasName("Prescription_pk");
            entity.Property(e => e.Date).IsRequired();
            entity.Property(e => e.DueDate).IsRequired();
            entity.ToTable("Prescription");

            entity.HasOne(e => e.IdPatientNavigation)
            .WithMany(e => e.Prescriptions)
            .HasForeignKey(e => e.IdPatient)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Patient_Prescription");

            entity.HasOne(e => e.IdDoctorNavigation)
            .WithMany(e => e.Prescriptions)
            .HasForeignKey(e => e.IdDoctor)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Doctor_Prescription");

            IEnumerable<Prescription> e_prescriptions = new List<Prescription>
                {
                    new Prescription
                    {
                        IdPrescription = 1,
                        Date = DateTime.Parse("2011-04-13"),
                        DueDate = DateTime.Parse("2072-04-174"),
                        IdPatient = 2,
                        IdDoctor = 1
                    },
                    new Prescription
                    {
                        IdPrescription = 2,
                        Date = DateTime.Parse("2020-01-02"),
                        DueDate = DateTime.Parse("2023-04-27"),
                        IdPatient = 1,
                        IdDoctor = 1
                    }
                };

            entity.HasData(e_prescriptions);
        }
    }
}
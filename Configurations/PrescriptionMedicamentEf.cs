using Cw6.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Cw6.Configurations
{
    public class PrescriptionMedicamentEf : IEntityTypeConfiguration<PrescriptionMedicament>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PrescriptionMedicament> entity)
        {
            entity.HasKey(e => new { e.IdMedicament, e.IdPrescription }).HasName("PrescriptionMedicament_pk");
            entity.Property(e => e.Dose);
            entity.Property(e => e.Details).IsRequired().HasMaxLength(100);

            entity.ToTable("Prescription_Medicament");

            entity.HasOne(e => e.IdMedicamentNavigation)
            .WithMany(e => e.PrescriptionMedicaments)
            .HasForeignKey(e => e.IdMedicament)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Medicament_PrescriptionMedicament");

            entity.HasOne(e => e.IdPrescriptionNavigation)
            .WithMany(e => e.PrescriptionMedicaments)
            .HasForeignKey(e => e.IdPrescription)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Prescription_PrescriptionMedicament");

            IEnumerable<PrescriptionMedicament> e_prescriptionMedicaments = new List<PrescriptionMedicament>
                {
                    new PrescriptionMedicament
                    {
                        IdMedicament = 1,
                        IdPrescription = 1,
                        Dose = 100,
                        Details = "eat a lot"
                    },
                    new PrescriptionMedicament
                    {
                        IdMedicament = 1,
                        IdPrescription = 2,
                        Dose = 25,
                        Details = "once a week"
                    },
                };

            entity.HasData(e_prescriptionMedicaments);
        }
    }
}
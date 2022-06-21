using Cw6.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Cw6.Configurations
{
    public class MedicamentEf : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Medicament> entity)
        {
            entity.HasKey(e => e.IdMedicament).HasName("Medicament_pk");
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Type).IsRequired().HasMaxLength(100);

            entity.ToTable("Medicament");

            IEnumerable<Medicament> e_medicaments = new List<Medicament>
                {
                    new Medicament {
                        IdMedicament = 1,
                        Name = "Paracetamol",
                        Description = "When you have headache",
                        Type = "Solid"
                    },
                    new Medicament {
                        IdMedicament = 2,
                        Name = "Emla",
                        Description = "When you use needles",
                        Type = "Fluid"
                    }
                };

            entity.HasData(e_medicaments);
        }
    }
}
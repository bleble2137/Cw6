using System;
using System.Collections.Generic;

namespace Cw6.Dtos.Responses
{
    public class PrescriptionDto
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public PatientDto IdPatientNavigation { get; set; }
        public DoctorDto IdDoctorNavigation { get; set; }
        public ICollection<PrescriptionMedicamentDto> PrescriptionMedicaments { get; set; }
    }
}
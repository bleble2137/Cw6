using System;
using System.Collections.Generic;

namespace Cw6.Models
{
    public class Prescription
    {
        public Prescription()
        {
            PrescriptionMedicaments = new HashSet<PrescriptionMedicament>();
        }
        public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }


        public int IdPrescription { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }


        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }


        public virtual Patient IdPatientNavigation { get; set; }
        public virtual Doctor IdDoctorNavigation { get; set; }

    }
}
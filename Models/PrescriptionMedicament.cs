using System;

namespace Cw6.Models
{
    public class PrescriptionMedicament
    {
        public int IdMedicament { get; set; }
        public int IdPrescription { get; set; }
        public string Details { get; set; }
        public int? Dose { get; set; }
        public virtual Medicament IdMedicamentNavigation { get; set; }

        public virtual Prescription IdPrescriptionNavigation { get; set; }


    }
}
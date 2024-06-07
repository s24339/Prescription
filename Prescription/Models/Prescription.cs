using System;
using System.Collections.Generic;

namespace Prescription.Models
{
    public class Prescription
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public int IdDoctor { get; set; }
        public int IdPatient { get; set; }
        public virtual Patient Patient { get; set; } = null!;
        public virtual Doctor Doctor { get; set; } = null!;
        public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; } = null!;

        public object getDueDate()
        {
            return DueDate;
        }

        public object getDate()
        {
            return Date;
        }
    }
}
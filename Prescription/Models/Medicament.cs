using System.Collections.Generic;

namespace Prescription.Models
{
    public class Medicament
    {
        public int IdMedicament { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Type { get; set; } = null!;
        public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments{ get; set; } = null!;
    }
}
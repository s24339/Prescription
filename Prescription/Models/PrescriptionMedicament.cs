namespace Prescription.Models
{
    public class PrescriptionMedicament
    {
        public int IdMedicament { get; set; }
        public int IdPrescription { get; set; }
        public int? Dose { get; set; }
        public string Details { get; set; } = null!;
        public Medicament Medicament { get; set; } = null!;
        public Prescription Prescription { get; set; } = null!;
    }
}
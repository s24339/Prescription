using System;
using System.Collections.Generic;

namespace Prescription.Models
{
    public class Patient
    {
        public int IdPatient { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; } = null!;
    }
}
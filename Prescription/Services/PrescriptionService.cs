using System;
using System.Threading.Tasks;
using Prescription.Models;

namespace Prescription.Services
{
    public interface IPrescriptionServices
    {
        Task<Models.Prescription> AddPrescription(Patient patient, Doctor doctor, Models.Prescription Prescription);
    }
    
    
    public class PrescriptionService : IPrescriptionServices
    {
        private readonly DBContext _dbContext;
        
        public PrescriptionService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<Models.Prescription> AddPrescription(Models.Prescription prescription,Medicament medicament, Patient patient, Doctor doctor)
        {
            var existingPatient = await _dbContext.Doctors.FindAync(patient);
            if (existingPatient == null)
            {
                existingPatient.FirstName = patient.FirstName;
                existingPatient.LastName = patient.LastName;
                existingPatient.BirthDate = patient.BirthDate;

                _dbContext.Doctors.Add(existingPatient);
                await _dbContext.SaveChangesAsync();
            }

            var existingMedicament = await _dbContext.Medicaments.FindAsync(medicament);
            if (existingMedicament == null)
            {
                throw new Exception("Medicament does not exist.");
            }

            if (prescription.getDueDate() >= prescription.getDate())
            {
                _dbContext.Prescriptions.Add(prescription);
                await _dbContext.SaveChangesAsync();
            }


            return prescription;
        }
    }
}
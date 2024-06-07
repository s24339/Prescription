using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prescription.Models;
using Prescription.Services;

namespace Prescription.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionServices _prescriptionServices;

        public PrescriptionController(IPrescriptionServices prescriptionServices)
        {
            _prescriptionServices = prescriptionServices;
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(Models.Prescription prescription, Patient patient, Medicament medicament, Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                var newPrescription = new Models.Prescription
                {
                    Date = prescription.Date;
                    DueDate = pescription.DueDate;
                    IdDoctor = prescription.IdDoctor;
                    IdPatien = prescription.IdPatient;
                };
                
                var addPrescription = await _prescriptionServices.AddPrescription(patient,doctor,prescription);
                return CreatedAtAction(nameof(Get), new { id = addPrescription.getID() }, addPrescription);
            }
            return BadRequest(ModelState);
        }
    }
}
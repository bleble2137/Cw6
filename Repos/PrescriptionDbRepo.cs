using Cw6.Dtos.Responses;
using Cw6.Models;
using Cw6.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Cw6.Repositories.Implementations
{
    public class PrescriptionDbRepo : IPrescriptionDbRepo
    {
        private readonly S20240Context _context;

        public PrescriptionDbRepo(S20240Context context)
        {
            _context = context;
        }
        public async Task<PrescriptionDto> GetPrescription(int idPrescription)
        {
            return await _context.Prescriptions
                .Select(p => new PrescriptionDto
                {
                    IdPrescription = p.IdPrescription,
                    Date = p.Date,
                    DueDate = p.DueDate,
                    IdDoctorNavigation = new DoctorDto
                    {
                        IdDoctor = p.IdDoctor,
                        FirstName = p.IdDoctorNavigation.FirstName,
                        LastName = p.IdDoctorNavigation.LastName,
                        Email = p.IdDoctorNavigation.Email
                    },
                    IdPatientNavigation = new PatientDto
                    {
                        IdPatient = p.IdPatient,
                        FirstName = p.IdPatientNavigation.FirstName,
                        LastName = p.IdPatientNavigation.LastName,
                        Birthdate = p.IdPatientNavigation.Birthdate
                    },
                    PrescriptionMedicaments = p.PrescriptionMedicaments
                        .Select(pm => new PrescriptionMedicamentDto
                        {
                            Name = pm.IdMedicamentNavigation.Name,
                            Description = pm.IdMedicamentNavigation.Description,
                            Type = pm.IdMedicamentNavigation.Type,
                            Dose = pm.Dose,
                            Details = pm.Details
                        }).ToList()
                })
                .FirstOrDefaultAsync(p => p.IdPrescription == idPrescription);
        }
    }
}
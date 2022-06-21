using Cw6.Dtos.Requests;
using Cw6.Dtos.Responses;
using Cw6.Models;
using Cw6.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Cw6.Repositories.Implementations
{
    public class DoctorDbRepo : IDoctorDbRepo
    {
        private readonly S20240Context _context;

        public DoctorDbRepo(S20240Context context)
        {
            _context = context;
        }

        public async Task<DoctorDto> GetDoctor(int idDoctor)
        {
            return await _context.Doctors.Select(d => new DoctorDto
            {
                IdDoctor = d.IdDoctor,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Email = d.Email
            }).FirstOrDefaultAsync(d => d.IdDoctor == idDoctor);
        }


        public async Task<bool> DeleteDoctor(int idDoctor)
        {
            Doctor doctor = await _context.Doctors.SingleOrDefaultAsync(d => d.IdDoctor == idDoctor);

            if (doctor is null)
            {
                return false;
            }

            var prescriptionExists = await _context.Prescriptions.AnyAsync(d => d.IdDoctor == idDoctor);
            if (prescriptionExists)
            {
                return false;
            }

            _context.Doctors.Remove(doctor);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddDoctor(DoctorCreateDto doctorCreateDto)
        {
            bool doctorExists = await _context.Doctors.AnyAsync(d => d.Email == doctorCreateDto.Email);

            if (doctorExists)
            {
                return false;
            }

            await _context.Doctors.AddAsync(new Doctor
            {
                FirstName = doctorCreateDto.FirstName,
                LastName = doctorCreateDto.LastName,
                Email = doctorCreateDto.Email
            });

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateDoctor(int idDoctor, DoctorUpdateDto doctorUpdateDto)
        {
            Doctor doctor = await _context.Doctors.SingleOrDefaultAsync(d => d.IdDoctor == idDoctor);

            if (doctor is null)
            {
                return false;
            }

            doctor.Email = doctorUpdateDto.Email;
            doctor.FirstName = doctorUpdateDto.FirstName;
            doctor.LastName = doctorUpdateDto.LastName;

            return await _context.SaveChangesAsync() > 0;
        }

    }
}
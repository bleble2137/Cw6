using Cw6.Dtos.Requests;
using Cw6.Dtos.Responses;
using System.Threading.Tasks;

namespace Cw6.Repositories.Interfaces
{
    public interface IDoctorDbRepo
    {
        Task<DoctorDto> GetDoctor(int idDoctor);
        Task<bool> DeleteDoctor(int idDoctor);

        Task<bool> AddDoctor(DoctorCreateDto doctorCreateDto);
        Task<bool> UpdateDoctor(int idDoctor, DoctorUpdateDto doctorUpdateDto);
    }
}
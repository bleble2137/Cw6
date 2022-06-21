using Cw6.Dtos.Responses;
using System.Threading.Tasks;

namespace Cw6.Repositories.Interfaces
{
    public interface IPrescriptionDbRepo
    {
        Task<PrescriptionDto> GetPrescription(int idPrescription);
    }
}
using Cw6.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cw6.Controllers
{
    [ApiController]
    [Route("api/prescription")]
    public class PrescriptionController : ControllerBase
    {

        private readonly IPrescriptionDbRepo _repository;

        public PrescriptionController(IPrescriptionDbRepo dbRepository)
        {
            _repository = dbRepository;
        }

        [HttpGet("{idPrescription}")]
        public async Task<IActionResult> GetPrescription([FromRoute] int idPrescription)
        {
            var prescription = await _repository.GetPrescription(idPrescription);
            return Ok(prescription);
        }
    }
}
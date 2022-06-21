using Cw6.Dtos.Requests;
using Cw6.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cw6.Controllers
{
    [ApiController]
    [Route("api/doctor")]
    public class DoctorController : ControllerBase
    {

        private readonly IDoctorDbRepo _repository;

        public DoctorController(IDoctorDbRepo dbRepository)
        {
            _repository = dbRepository;
        }

        [HttpGet("{idDoctor}")]
        public async Task<IActionResult> GetDoctor([FromRoute] int idDoctor)
        {
            var doctor = await _repository.GetDoctor(idDoctor);
            if (doctor is null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }

        [HttpDelete("{idDoctor}")]
        public async Task<IActionResult> DeleteDoctor([FromRoute] int idDoctor)
        {
            if (!await _repository.DeleteDoctor(idDoctor))
            {
                return BadRequest("Remove doctor failed");
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PostDoctor([FromBody] DoctorCreateDto doctorCreateDto)
        {
            var isDoctorAdded = await _repository.AddDoctor(doctorCreateDto);
            if (!isDoctorAdded)
            {
                return BadRequest("Add doctor failed");
            }

            return Ok();
        }


        [HttpPut("{idDoctor}")]
        public async Task<IActionResult> PutDoctor([FromRoute] int idDoctor, [FromBody] DoctorUpdateDto doctorUpdateDto)
        {
            if (!await _repository.UpdateDoctor(idDoctor, doctorUpdateDto))
            {
                return NotFound("Update doctor failed");
            }

            return Ok();
        }

    }
}
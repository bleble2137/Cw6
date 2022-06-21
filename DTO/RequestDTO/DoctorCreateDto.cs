using System.ComponentModel.DataAnnotations;

namespace Cw6.Dtos.Requests
{
    public class DoctorCreateDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
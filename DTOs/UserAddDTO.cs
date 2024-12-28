using System.ComponentModel.DataAnnotations;

namespace DevOps_HW.DTOs
{
    public class UserAddDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }
}

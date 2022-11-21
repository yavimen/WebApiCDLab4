using System.ComponentModel.DataAnnotations;

namespace WebApi.ModelViews
{
    public class DoctorUpdateView
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Length of position more than 50.")]
        [MinLength(5, ErrorMessage = "Length of position less than 5.")]
        public string Position { get; set; } = null!;

        [Required]
        [MaxLength(50, ErrorMessage = "Length of department more than 50.")]
        [MinLength(5, ErrorMessage = "Length of department less than 5.")]
        public string Department { get; set; } = null!;
    }
}

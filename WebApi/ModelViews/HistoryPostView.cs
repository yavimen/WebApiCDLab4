using System.ComponentModel.DataAnnotations;

namespace WebApi.ModelViews
{
    public class HistoryPostView
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Length of full name more than 50.")]
        [MinLength(5, ErrorMessage = "Length of full name less than 5.")]
        public string PatientFullName { get; set; } = null!;

        [Required]
        [MaxLength(50, ErrorMessage = "Length of contacts more than 50.")]
        [MinLength(5, ErrorMessage = "Length of contacts less than 5.")]
        public string PatientContacts { get; set; } = null!;

        [Required]
        [MaxLength(50, ErrorMessage = "Length of diagnosis more than 50.")]
        [MinLength(4, ErrorMessage = "Length of diagnosis less than 4.")]
        public string Diagnosis { get; set; } = null!;

        [Required]
        [MaxLength(50, ErrorMessage = "Length of department more than 50.")]
        [MinLength(5, ErrorMessage = "Length of department less than 5.")]
        public string Department { get; set; } = null!;

        [Required]
        [MaxLength(50, ErrorMessage = "Length of treatment more than 50.")]
        [MinLength(5, ErrorMessage = "Length of treatment less than 5.")]
        public string Treatment { get; set; } = null!;
    }
}

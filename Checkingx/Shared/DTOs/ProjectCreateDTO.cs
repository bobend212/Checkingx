using System.ComponentModel.DataAnnotations;

namespace Checkingx.Shared.DTOs
{
    public class ProjectCreateDTO
    {
        [Required]
        public string Number { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int CheckingPriority { get; set; }
    }
}
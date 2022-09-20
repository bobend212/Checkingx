using System.ComponentModel.DataAnnotations;

namespace Checkingx.Shared.DTOs
{
    public class CheckingCreateDTO
    {
        [Required]
        public int ProjectId { get; set; }

        [Required]
        public int CheckItemId { get; set; }

        public string? Description { get; set; }

        public string Status { get; set; } = string.Empty;

        public List<Image> Images { get; set; } = new List<Image>();
    }
}
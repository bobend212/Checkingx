using System.ComponentModel.DataAnnotations;

namespace Checkingx.Shared.DTOs
{
    public class CheckItemCreateDTO
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;

        [Required]
        public int Priority { get; set; }

        public int OrderNo { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Checkingx.Shared.DTOs
{
    public class CheckingCreateDTO
    {
        [Required]
        public int ProjectId { get; set; }

        [Required]
        public int CheckItemId { get; set; }

        public string Description { get; set; }
        public bool IsError { get; set; }
        public bool IsCorrected { get; set; }
        public bool IsNA { get; set; }
    }
}
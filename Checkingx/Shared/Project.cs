using System.ComponentModel.DataAnnotations;

namespace Checkingx.Shared
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Required]
        public string Number { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int CheckingPriority { get; set; } = 1;

        public List<Checking>? Checking { get; set; }

    }
}
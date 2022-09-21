namespace Checkingx.Shared
{
    public class Checking
    {
        public int CheckingId { get; set; }
        public Project? Project { get; set; }
        public int ProjectId { get; set; }
        public CheckItem? CheckItem { get; set; }
        public int CheckItemId { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; } = string.Empty;

        public List<Image> Images { get; set; } = new List<Image>();

        public DateTime CheckDate { get; set; } = DateTime.Now;
        public DateTime? ReviewDate { get; set; }
    }
}
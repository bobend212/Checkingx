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
        public bool IsError { get; set; }
        public bool IsCorrected { get; set; }
    }
}
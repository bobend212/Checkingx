namespace Checkingx.Shared
{
    public class CheckItem
    {
        public int CheckItemId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int Priority { get; set; } = 1;
    }
}
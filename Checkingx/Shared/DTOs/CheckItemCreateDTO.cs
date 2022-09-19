namespace Checkingx.Shared.DTOs
{
    public class CheckItemCreateDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int Priority { get; set; }
    }
}
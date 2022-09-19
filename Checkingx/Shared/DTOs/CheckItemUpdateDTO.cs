namespace Checkingx.Shared.DTOs
{
    public class CheckItemUpdateDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int Priority { get; set; }
    }
}
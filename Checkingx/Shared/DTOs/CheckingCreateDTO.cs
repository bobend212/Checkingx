namespace Checkingx.Shared.DTOs
{
    public class CheckingCreateDTO
    {
        public int ProjectId { get; set; }
        public int CheckItemId { get; set; }
        public string Description { get; set; }
        public bool IsError { get; set; }
        public bool IsCorrected { get; set; }
        public bool IsNA { get; set; }
    }
}
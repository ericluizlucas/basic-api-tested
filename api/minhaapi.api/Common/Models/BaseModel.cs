namespace minhaapi.Common.Models
{
    public class BaseModel
    {
        public long Id { get; set; }
        public string? Uuid { get; set; }
        public bool Enable { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ViewUuid { get => Uuid?.Substring(0,8); }

        public BaseModel()
        {
            CreatedAt = DateTime.Now;
            Enable = true;
        }
    }
}
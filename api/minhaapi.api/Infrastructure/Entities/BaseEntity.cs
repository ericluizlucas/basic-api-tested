namespace minhaapi.Infrastructure.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public string Uuid { get; set; }
        public bool Enable { get; set; }
        public DateTime CreatedAt { get; set; }

        public BaseEntity()
        {
            Uuid = Guid.NewGuid().ToString();
            Enable = true;
            CreatedAt = DateTime.Now;
        }
    }
}
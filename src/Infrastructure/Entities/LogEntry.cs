namespace Infrastructure.Entities
{
    public class LogEntry
    {
        public int Id { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public required string Level { get; set; }
        public required string Message { get; set; }
        public required string Exception { get; set; }
    }
}

namespace APIWebApplication.DTO.Request
{
    /// <summary>
    /// Represents a request DTO (Data Transfer Object) for updating an access log entry.
    /// </summary>
    public class UpdateAccessLogRequest
    {
        public DateTime? EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
        public int? CurrentVisitorCount { get; set; }
    }
}

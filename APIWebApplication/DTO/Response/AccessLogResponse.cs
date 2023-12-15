namespace APIWebApplication.DTO.Response
{
    /// <summary>
    /// Represents a response DTO (Data Transfer Object) for an access log entry.
    /// </summary>
    public class AccessLogResponse
    {
        public int Id { get; set; }
        public int MuseumAreaId { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }
        public int CurrentVisitorCount { get; set; }
    }
}

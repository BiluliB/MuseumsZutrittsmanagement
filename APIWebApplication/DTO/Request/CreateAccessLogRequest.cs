using System.ComponentModel.DataAnnotations;

namespace APIWebApplication.DTO.Request
{
    /// <summary>
    /// Represents a request DTO (Data Transfer Object) for creating an access log entry.
    /// </summary>
    public class CreateAccessLogRequest
    {
        [Required]
        public int MuseumAreaId { get; set; }

        [Required]
        public DateTime EntryTime { get; set; }

        [Required]
        public DateTime ExitTime { get; set; }

        [Required]
        public int CurrentVisitorCount { get; set; }
    }
}

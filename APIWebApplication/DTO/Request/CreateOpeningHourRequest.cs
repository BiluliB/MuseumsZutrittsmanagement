using System.ComponentModel.DataAnnotations;

namespace APIWebApplication.DTO.Request
{
    /// <summary>
    /// Represents a request DTO (Data Transfer Object) for creating an opening hour record for a museum area.
    /// </summary>
    public class CreateOpeningHourRequest
    {
        [Required]
        public int MuseumAreaId { get; set; }

        [Required]
        public string Weekday { get; set; }

        [Required]
        public TimeSpan Opens { get; set; }

        [Required]
        public TimeSpan Closes { get; set; }
    }
}

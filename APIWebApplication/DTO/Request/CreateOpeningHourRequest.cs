using System.ComponentModel.DataAnnotations;

namespace APIWebApplication.DTO.Request
{
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

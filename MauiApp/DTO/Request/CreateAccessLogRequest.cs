using System.ComponentModel.DataAnnotations;

namespace MuseumsZutrittMauiApp.DTO.Request
{
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

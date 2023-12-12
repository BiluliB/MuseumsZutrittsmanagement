using System.ComponentModel.DataAnnotations;

namespace APIWebApplication.DTO.Request
{
    public class CreateVisitorCapacityRequest
    {
        [Required]
        public int MuseumAreaId { get; set; }

        [Required]
        public int MaxVisitorCount { get; set; }
    }
}

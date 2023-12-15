using System.ComponentModel.DataAnnotations;

namespace APIWebApplication.DTO.Request
{
    /// <summary>
    /// Represents a request DTO (Data Transfer Object) for creating a visitor capacity record for a museum area.
    /// </summary>
    public class CreateVisitorCapacityRequest
    {
        [Required]
        public int MuseumAreaId { get; set; }

        [Required]
        public int MaxVisitorCount { get; set; }
    }
}

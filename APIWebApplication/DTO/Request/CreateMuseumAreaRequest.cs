using System.ComponentModel.DataAnnotations;

namespace APIWebApplication.DTO.Request
{
    /// <summary>
    /// Represents a request DTO (Data Transfer Object) for creating a museum area.
    /// </summary>
    public class CreateMuseumAreaRequest
    {
        [Required]
        public string AreaName { get; set; }

        [Required]
        public string AreaDescription { get; set; }

        [Required]
        public string AreaLocation { get; set; }

        [Required]
        public string AccessRules { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace APIWebApplication.DTO.Request
{
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

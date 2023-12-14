using System.ComponentModel.DataAnnotations;

namespace MuseumsZutrittMauiApp.DTO.Request
{
    public class UpdateMuseumAreaRequest
    {
        public string? AreaName { get; set; }

       
        public string? AreaDescription { get; set; }

     
        public string? AreaLocation { get; set; }

    
        public string? AccessRules { get; set; }
    }
}

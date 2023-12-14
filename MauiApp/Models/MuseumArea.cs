namespace MuseumsZutrittMauiApp.Models
{
    public class MuseumArea
    {
        public int Id { get; set; }
        public string AreaName { get; set; }
        public string AreaDescription { get; set; }
        public string AreaLocation { get; set; }
        public string AccessRules { get; set; }

        // Lazy Loading für die Navigationseigenschaften
        public virtual ICollection<VisitorCapacity> VisitorCapacities { get; set; }
        public virtual ICollection<OpeningHour> OpeningHours { get; set; }
    }
}

namespace APIWebApplication.Models
{
    /// <summary>
    /// Model for Museum area
    /// </summary>
    public class MuseumArea
    {
        public int Id { get; set; }
        public string AreaName { get; set; }
        public string AreaDescription { get; set; }
        public string AreaLocation { get; set; }
        public string AccessRules { get; set; }

        // Lazy loading for navigation properties
        public virtual ICollection<VisitorCapacity> VisitorCapacities { get; set; }
        public virtual ICollection<OpeningHour> OpeningHours { get; set; }
    }
}

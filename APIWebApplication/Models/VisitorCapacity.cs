namespace APIWebApplication.Models
{
    /// <summary>
    /// Model for visitor capacity
    /// </summary>
    public class VisitorCapacity
    {
        public int Id { get; set; }
        public int MuseumAreaId { get; set; }

        public virtual MuseumArea MuseumArea { get; set; }
        public int MaxVisitorCount { get; set; }
    }

}

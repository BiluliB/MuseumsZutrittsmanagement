namespace APIWebApplication.Models
{
    public class OpeningHour
    {
        public int Id { get; set; }
        public int MuseumAreaId { get; set; }

        public virtual MuseumArea MuseumArea { get; set; }
        public string Weekday { get; set; }
        public TimeSpan Opens { get; set; }
        public TimeSpan Closes { get; set; }
    }

}

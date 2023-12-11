namespace APIWebApplication.Models
{
    public class OpeningHour
    {
        public int ID { get; set; }
        public int MuseumAreaID { get; set; }

        public virtual MuseumArea MuseumArea { get; set; }
        public string Weekday { get; set; }
        public TimeSpan Opens { get; set; }
        public TimeSpan Closes { get; set; }
    }

}

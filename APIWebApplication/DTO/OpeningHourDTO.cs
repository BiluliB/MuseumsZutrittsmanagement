namespace APIWebApplication.DTO
{
    public class OpeningHourDTO
    {
        public int ID { get; set; }
        public int MuseumAreaID { get; set; }
        public string Weekday { get; set; }
        public TimeSpan Opens { get; set; }
        public TimeSpan Closes { get; set; }
        public string MuseumAreaName { get; set; }
    }
}

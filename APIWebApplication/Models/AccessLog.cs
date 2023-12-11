namespace APIWebApplication.Models
{
    public class AccessLog
    {
        public int ID { get; set; }
        public int MuseumAreaID { get; set; }

        public virtual MuseumArea MuseumArea { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }
        public int CurrentVisitorCount { get; set; }
    }

}

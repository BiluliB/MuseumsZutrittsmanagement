namespace APIWebApplication.Models
{
    /// <summary>
    /// Model for Accesslog
    /// </summary>
    public class AccessLog
    {
        public int Id { get; set; }
        public int MuseumAreaId { get; set; }

        public virtual MuseumArea MuseumArea { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }
        public int CurrentVisitorCount { get; set; }
    }

}

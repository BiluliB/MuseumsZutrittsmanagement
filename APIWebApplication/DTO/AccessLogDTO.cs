namespace APIWebApplication.DTO
{
    public class AccessLogDTO
    {
        public int ID { get; set; }
        public int MuseumAreaID { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }
        public int CurrentVisitorCount { get; set; }
        public string MuseumAreaName { get; set; }
    }
}

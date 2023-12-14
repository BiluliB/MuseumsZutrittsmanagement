namespace MuseumsZutrittMauiApp.DTO.Request
{
    public class UpdateAccessLogRequest
    {
        
        
        public DateTime? EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
        public int? CurrentVisitorCount { get; set; }
    }
}

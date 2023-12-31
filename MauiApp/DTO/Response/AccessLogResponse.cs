﻿namespace MuseumsZutrittMauiApp.DTO.Response
{
    public class AccessLogResponse
    {
        public int Id { get; set; }
        public int MuseumAreaId { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }
        public int CurrentVisitorCount { get; set; }
    }
}

namespace MuseumsZutrittMauiApp.DTO.Response
{
    public class OpeningHourResponse
    {
        public int Id { get; set; }
        public int MuseumAreaId { get; set; }
        public string Weekday { get; set; }
        public TimeSpan Opens { get; set; }
        public TimeSpan Closes { get; set; }
        
    }
}

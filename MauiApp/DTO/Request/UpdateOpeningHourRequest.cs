namespace MuseumsZutrittMauiApp.DTO.Request
{
    public class UpdateOpeningHourRequest
    {
        public int? MuseumAreaId { get; set; }
        public string? Weekday { get; set; }
        public TimeSpan? Opens { get; set; }
        public TimeSpan? Closes { get; set; }

    }
}

namespace APIWebApplication.DTO.Request
{
    /// <summary>
    /// Represents a request DTO (Data Transfer Object) for updating an opening hour record for a museum area.
    /// </summary>
    public class UpdateOpeningHourRequest
    {
        public int? MuseumAreaId { get; set; }
        public string? Weekday { get; set; }
        public TimeSpan? Opens { get; set; }
        public TimeSpan? Closes { get; set; }

    }
}

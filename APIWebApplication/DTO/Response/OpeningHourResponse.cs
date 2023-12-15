namespace APIWebApplication.DTO.Response
{
    // <summary>
    /// Represents a response DTO (Data Transfer Object) for an opening hour record of a museum area.
    /// </summary>
    public class OpeningHourResponse
    {
        public int Id { get; set; }
        public int MuseumAreaId { get; set; }
        public string Weekday { get; set; }
        public TimeSpan Opens { get; set; }
        public TimeSpan Closes { get; set; }
        
    }
}

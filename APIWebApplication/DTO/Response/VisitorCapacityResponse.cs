namespace APIWebApplication.DTO.Response
{
    /// <summary>
    /// Represents a response DTO (Data Transfer Object) for the visitor capacity of a museum area.
    /// </summary>
    public class VisitorCapacityResponse
    {
        public int Id { get; set; }
        public int MuseumAreaId { get; set; }
        public int MaxVisitorCount { get; set; }
    }
}

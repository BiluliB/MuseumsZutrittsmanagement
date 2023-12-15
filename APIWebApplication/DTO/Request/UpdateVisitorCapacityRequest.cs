namespace APIWebApplication.DTO.Request
{
    /// <summary>
    /// Represents a request DTO (Data Transfer Object) for updating the visitor capacity of a museum area.
    /// </summary>
    public class UpdateVisitorCapacityRequest
    {
        public int? MaxVisitorCount { get; set; }
    }
}

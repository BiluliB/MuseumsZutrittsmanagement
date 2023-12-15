namespace APIWebApplication.DTO.Response
{
    /// <summary>
    /// Represents a response DTO (Data Transfer Object) for a museum area.
    /// </summary>
    public class MuseumAreaResponse
    {
        public int Id { get; set; }
        public string AreaName { get; set; }
        public string AreaDescription { get; set; }
        public string AreaLocation { get; set; }
        public string AccessRules { get; set; }
    }
}

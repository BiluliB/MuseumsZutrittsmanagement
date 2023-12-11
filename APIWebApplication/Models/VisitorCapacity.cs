namespace APIWebApplication.Models
{
    public class VisitorCapacity
    {
        public int ID { get; set; }
        public int MuseumAreaID { get; set; }

        public virtual MuseumArea MuseumArea { get; set; }
        public int MaxVisitorCount { get; set; }
    }

}

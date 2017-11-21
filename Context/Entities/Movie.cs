namespace Context.Entities
{
    public class Movie : TrackableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public int MovieTypeId { get; set; }
        public MovieType MovieType { get; set; }
    }
}
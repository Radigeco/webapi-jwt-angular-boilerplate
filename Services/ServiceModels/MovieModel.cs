namespace Services.ServiceModels
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MovieTypeId { get; set; }
    }

    public class MovieJoinModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int MovieTypeId { get; set; }
        public MovieTypeModel MovieTypeModel { get; set; }
    }

    public class MovieTypeModel
    {
        public int Id { get; set; }
      
    }
}

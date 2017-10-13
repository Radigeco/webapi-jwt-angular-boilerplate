using Infrastructure;
using Infrastructure.Implementation;

namespace Context.Entities
{
    public class Movie : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
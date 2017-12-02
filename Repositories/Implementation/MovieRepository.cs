using Ambient.Context.Interfaces;
using Context.Entities;
using Infrastructure.Implementation;
using Repositories.Interface;

namespace Repositories.Implementation
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        
        public MovieRepository(IAmbientDbContextLocator ambientDbContextLocator ) : base(ambientDbContextLocator)
        {
        }
    }
}

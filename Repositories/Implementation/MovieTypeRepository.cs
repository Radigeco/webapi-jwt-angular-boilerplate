using Ambient.Context.Interfaces;
using Context.Entities;
using Infrastructure.Implementation;
using Repositories.Interface;

namespace Repositories.Implementation
{
    public class MovieTypeRepository : GenericRepository<MovieType>, IMovieTypeRepository
    {
        public MovieTypeRepository(IAmbientDbContextLocator contextLocator) : base(contextLocator)
        {
        }
    }
}
using System.Data.Entity;
using Context;
using Context.Entities;
using Infrastructure;
using Infrastructure.Implementation;
using Repositories.Interface;

namespace Repositories.Implementation
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(IContextWrapper contextWrapper) : base(contextWrapper)
        {
        }
    }
}

using System.Data.Entity;
using Context.Entities;
using Infrastructure;
using Repositories.Interface;

namespace Repositories.Implementation
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(DbContext context) : base(context)
        {
        }
    }
}

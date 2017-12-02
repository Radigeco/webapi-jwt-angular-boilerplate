using System.Data.Entity;
using Ambient.Context.Implementations;
using Ambient.Context.Interfaces;
using Context;

namespace Infrastructure
{
    public class MoviesScopeLocator : AmbientDbContextLocator, IAmbientDbContextLocator
    {
        public new DbContext Get()
        {
            return base.Get<MoviesDbContext>();
        }
    }
}
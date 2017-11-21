using System.Data.Entity;

namespace Context
{
    public class ContextWrapper : IContextWrapper
    {
        public DbContext GetContext()
        {
            return new WebSolutionDbContext();
        }
    }
}
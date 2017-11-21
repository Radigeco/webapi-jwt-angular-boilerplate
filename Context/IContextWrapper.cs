using System.Data.Entity;

namespace Context
{
    public interface IContextWrapper
    {
        DbContext GetContext();
    }
}
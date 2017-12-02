using System.Collections.Generic;
using Services.ServiceModels;

namespace Services.Interface
{
    public interface IMovieService
    {
        IEnumerable<MovieModel> GetAll();
        MovieModel Add(MovieModel model);
        MovieModel Update(MovieModel model);
        void Delete(int id);
        MovieModel GetById(int id);
        IEnumerable<MovieModel> MapperGetAll();
        IEnumerable<MovieJoinModel> GetJoined();
    }
}

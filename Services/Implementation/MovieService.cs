using System.Collections.Generic;
using System.Linq;
using Ambient.Context.Interfaces;
using Context.Entities;
using Repositories.Interface;
using Services.Interface;
using Services.ServiceModels;
using AutoMapper;

namespace Services.Implementation
{

    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMovieTypeRepository _movieTypeRepository;
        private readonly IMapper _mapper;
        private readonly IDbContextScopeFactory _contextScopeFactory;

        public MovieService(IMovieRepository movieRepository, IMapper mapper, IDbContextScopeFactory contextScopeFactory, IMovieTypeRepository movieTypeRepository)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _contextScopeFactory = contextScopeFactory;
            _movieTypeRepository = movieTypeRepository;
        }

        public IEnumerable<MovieModel> GetAll()
        {
            using (var scope = _contextScopeFactory.CreateReadOnly())
            {
                return _movieRepository.GetAllActive().ToList().Select(x => new MovieModel
                {
                    Description = x.Description,
                    Title = x.Title,
                    Id = x.Id
                });
            }
        }

        public IEnumerable<MovieModel> MapperGetAll()
        {
            using (var scope = _contextScopeFactory.CreateReadOnly())
            {
                var movies = _movieRepository.GetAllActive().ToList();
                var movieModels = _mapper.Map<List<MovieModel>>(movies);
                return movieModels;
            }
        }

        public IEnumerable<MovieJoinModel> GetJoined()
        {
            using (var scope = _contextScopeFactory.Create())
            {
                var movies = _movieRepository.Set();
                var movieTypes = _movieTypeRepository.Set();
                var joined = from movie in movies
                             join movieType in movieTypes
                                 on movie.MovieTypeId equals movieType.Id
                             select new MovieJoinModel
                             {
                                 Id = movie.Id,
                                 MovieTypeModel = new MovieTypeModel
                                 {
                                     Id = movieType.Id
                                 },
                                 MovieTypeId = movieType.Id,
                                 Description = movie.Description,
                                 Title = movie.Title
                             };

                return joined.ToList();
            }
        }

        public MovieModel Add(MovieModel model)
        {
            using (var scope = _contextScopeFactory.Create())
            {
                var entity = new Movie
                {
                    IsDeleted = false,
                    Description = model.Description,
                    Title = model.Title,
                    MovieTypeId = model.MovieTypeId
                };
                _movieRepository.Add(entity);
                _movieRepository.Save();
                return new MovieModel
                {
                    Description = entity.Description,
                    Title = entity.Title,
                    Id = entity.Id
                };
            }
        }

        public MovieModel Update(MovieModel model)
        {
            using (var scope = _contextScopeFactory.Create())
            {
                var entity = _movieRepository.GetById(model.Id);
                entity.Title = model.Title;
                entity.MovieTypeId = model.MovieTypeId;
                entity.Description = model.Description;
                _movieRepository.Edit(entity);
                _movieRepository.Save();
                return new MovieModel
                {
                    Description = entity.Description,
                    Title = entity.Title,
                    Id = entity.Id
                };
            }
        }

        public void Delete(int id)
        {
            using (var scope = _contextScopeFactory.Create())
            {
                _movieRepository.Delete(id);
                _movieRepository.Save();
            }
        }

        public MovieModel GetById(int id)
        {
            using (var scope = _contextScopeFactory.CreateReadOnly())
            {
                var entity = _movieRepository.GetById(id);
                return new MovieModel
                {
                    Title = entity.Title,
                    Description = entity.Description,
                    Id = entity.Id
                };
            }
        }
    }
}

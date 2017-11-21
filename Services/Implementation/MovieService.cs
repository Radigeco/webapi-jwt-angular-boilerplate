using System.Collections.Generic;
using System.Linq;
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
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public IEnumerable<MovieModel> GetAll()
        {
            return _movieRepository.GetAllActive().ToList().Select(x => new MovieModel
            {
                Description = x.Description,
                Title = x.Title,
                Id = x.Id
            });
        }

        public IEnumerable<MovieModel> MapperGetAll()
        {
            var movies = _movieRepository.GetAllActive().ToList();
            var movieModels = _mapper.Map<List<MovieModel>>(movies);
            return movieModels;
        }

        public MovieModel Add(MovieModel model)
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

        public MovieModel Update(MovieModel model)
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

        public void Delete(int id)
        {
            _movieRepository.Delete(id);
            _movieRepository.Save();
        }

        public MovieModel GetById(int id)
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

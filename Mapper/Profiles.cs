using AutoMapper;
using Context.Entities;
using Services.ServiceModels;
using System.Collections.Generic;

namespace Mapper
{
    public static class MapperConfig
    {
        public static List<Profile> GetProfiles()
        {
            return new List<Profile>
            {
              new MovieProfile(),
            };
        }
    }

    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieModel>();
            CreateMap<MovieModel, Movie>();
        }
    }
}

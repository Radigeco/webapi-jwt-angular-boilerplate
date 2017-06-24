using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Mapper
{
    public static class MapperSetup
    {
        private static MapperConfiguration _config;

        private static IMapper _mapper;

        private static List<Profile> _mappingConfigurations;

        static MapperSetup()
        {
            _mappingConfigurations = new List<Profile>();
        }

        public static IMapper GetMapper()
        {
            if (_mapper == null)
            {
                BuildMapper();
                _mapper = _config.CreateMapper();
            }
            return _mapper;
        }

        private static void BuildMapper()
        {
            _config = new MapperConfiguration(
                cfg =>
                {
                    foreach (var profile in _mappingConfigurations)
                    {
                        cfg.AddProfile(profile);
                    }
                });
            _mapper = _config.CreateMapper();
        }

        public static void RegisterProfile(Profile profile)
        {
            _mappingConfigurations.Add(profile);
        }

        public static void RegisterProfiles(List<Profile> profiles)
        {
            _mappingConfigurations = _mappingConfigurations.Concat(profiles).ToList();
        }
    }
}

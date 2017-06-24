using Autofac;
using AutoMapper;
using Context;
using Mapper;
using Repositories.Implementation;
using Services.Implementation;

namespace Websolution.DI
{
    public static class DiRegistrar
    {
        public static void RegisterRepositories(ContainerBuilder builder)
        {
            //registers all repositories inside Repositories.Implementation namespace, manual registration can also be done
            builder.RegisterAssemblyTypes(typeof(MovieRepository).Assembly)
             .Where(x => x.Namespace != null && x.Namespace.EndsWith("Repositories.Implementation"))
             .AsImplementedInterfaces().WithParameter("context", new WebSolutionDbContext());

        }

        public static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(MovieService).Assembly)
                .Where(x => x.Namespace != null && x.Namespace.EndsWith("Services.Implementation"))
                .AsImplementedInterfaces();
        }
        public static void RegisterMapper(ContainerBuilder builder)
        {
            builder.Register(context => MapperSetup.GetMapper()).As<IMapper>();
        }
    }
}
using Autofac;
using Context;
using Repositories.Implementation;

namespace Websolution.DI
{
    public static class DiRegistrar
    {
        public static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(MovieRepository).Assembly)
             .Where(x => x.Namespace != null && x.Namespace.EndsWith("Repositories.Implementation"))
             .AsImplementedInterfaces().WithParameter("context", new ApplicationDbContext());


            //builder.RegisterType<BenchmarkService>().As<IBenchmarkService>();

        }
    }
}
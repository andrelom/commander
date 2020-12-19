using System.Linq;
using Commander.Utilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Commander.Extensions
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder UseCommander(this IHostBuilder builder)
        {
            return builder.ConfigureServices(ConfigureServices);
        }

        #region Private Methods

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICommander, Commander>();

            AssemblyUtility.GetControllerTypes().ToList()
                .ForEach(controller => services.AddSingleton(controller));
        }

        #endregion
    }
}

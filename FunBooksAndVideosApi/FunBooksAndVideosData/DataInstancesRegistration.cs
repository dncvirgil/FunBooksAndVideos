using FunBooksAndVideos.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FunBooksAndVideos.Data
{
    public static class DataInstancesRegistration
    {
        public static void RegisterDataInstances(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}

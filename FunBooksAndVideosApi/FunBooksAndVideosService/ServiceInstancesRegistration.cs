using FunBooksAndVideos.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FunBooksAndVideos.Service
{
    public static class ServiceInstancesRegistration
    {
        public static void RegisterServiceInstances(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProductService, ProductService>();
            serviceCollection.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
        }
    }
}

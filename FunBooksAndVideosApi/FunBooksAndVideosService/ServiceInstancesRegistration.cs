using FunBooksAndVideos.Service.Interfaces;
using FunBooksAndVideos.Service.Processor;
using FunBooksAndVideos.Service.Processor.Strategy;
using Microsoft.Extensions.DependencyInjection;

namespace FunBooksAndVideos.Service
{
    public static class ServiceInstancesRegistration
    {
        public static void RegisterServiceInstances(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProductService, ProductService>();
            serviceCollection.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
            serviceCollection.AddScoped<IPurchaseOrderProcessor, PurchaseOrderProcessor>();
            serviceCollection.AddScoped<IPurchaseOrderProcessingStrategy, MembershipOrderProcessingStrategy>();
            serviceCollection.AddScoped<IPurchaseOrderProcessingStrategy, PhysicalOrderProcessingStrategy>();
            serviceCollection.AddScoped<IPurchaseOrderProcessingStrategy, OnlineOrderProcessingStrategy>();
        }
    }
}

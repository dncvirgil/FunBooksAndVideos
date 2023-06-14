using FunBooksAndVideos.Processor.Strategy;
using Microsoft.Extensions.DependencyInjection;

namespace FunBooksAndVideos.Processor
{
    public static class ProcessorInstancesRegistration
    {
        public static void RegisterProcessorInstances(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IPurchaseOrderProcessor, PurchaseOrderProcessor>();
            serviceCollection.AddScoped<IPurchaseOrderProcessingStrategy, MembershipOrderProcessingStrategy>();
            serviceCollection.AddScoped<IPurchaseOrderProcessingStrategy, PhysicalOrderProcessingStrategy>();
            serviceCollection.AddScoped<IPurchaseOrderProcessingStrategy, OnlineOrderProcessingStrategy>();
        }
    }
}

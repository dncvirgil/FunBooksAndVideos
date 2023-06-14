using FunBooksAndVideos.Data.Repositories;
using FunBooksAndVideos.Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FunBooksAndVideos.Data
{
    public static class DataInstancesRegistration
    {
        public static void RegisterDataInstances(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProductRepository, ProductRepository>();
            serviceCollection.AddScoped<ICustomerMembershipRepository, CustomerMembershipRepository>();
            serviceCollection.AddScoped<ICustomerProductRepository, CustomerProductRepository>();
            serviceCollection.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
            serviceCollection.AddScoped<IShippingRepository, ShippingRepository>();
            serviceCollection.AddScoped<IMembershipTypeRepository, MembershipTypeRepository>();
            serviceCollection.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}

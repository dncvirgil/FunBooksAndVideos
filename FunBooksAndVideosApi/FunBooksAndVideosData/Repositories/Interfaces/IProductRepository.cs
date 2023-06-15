using FunBooksAndVideos.Domain;

namespace FunBooksAndVideos.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Entities.Product>> GetProducts(ProductTypeEnum productType);
        Task<Entities.Product?> GetProductByName(string name);
    }
}

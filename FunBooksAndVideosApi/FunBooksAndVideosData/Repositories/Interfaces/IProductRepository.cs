using FunBooksAndVideos.Domain;

namespace FunBooksAndVideos.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts(ProductTypeEnum productType);
        Task<Product?> GetProductByName(string name);
    }
}

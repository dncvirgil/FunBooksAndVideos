using FunBooksAndVideos.Domain;

namespace FunBooksAndVideos.Service.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts(ProductTypeEnum productType);
    }
}

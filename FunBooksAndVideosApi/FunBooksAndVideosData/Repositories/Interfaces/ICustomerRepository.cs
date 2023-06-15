using FunBooksAndVideos.Data.Entities;

namespace FunBooksAndVideos.Data.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer?> Get(int id);
    }
}

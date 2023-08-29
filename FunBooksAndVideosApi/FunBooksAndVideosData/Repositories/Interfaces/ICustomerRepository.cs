namespace FunBooksAndVideos.Data.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Domain.Customer?> Get(int id);
    }
}

using FunBooksAndVideos.Data.Entities;
namespace FunBooksAndVideos.Data.Repositories.Interfaces
{
    public interface IMembershipTypeRepository
    {
        Task<MembershipType> GetByName(string name);
    }
}

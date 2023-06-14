using FunBooksAndVideos.Data.Entities;
using FunBooksAndVideos.Data.Repositories.Interfaces;

namespace FunBooksAndVideos.Data.Repositories
{
    public class MembershipTypeRepository : IMembershipTypeRepository
    {
        private readonly BookAndVideoContext _context;
        public MembershipTypeRepository(BookAndVideoContext context)
        {
            _context = context;
        }

        public async Task<MembershipType> GetByName(string name)
        {
            var membershipType = _context.MembershipTypes.FirstOrDefault(x => x.Name == name);
            return membershipType;
        }
    }
}

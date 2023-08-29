using FunBooksAndVideos.Data.Entities;
using FunBooksAndVideos.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FunBooksAndVideos.Data.Repositories
{
    public class MembershipTypeRepository : IMembershipTypeRepository
    {
        private readonly BookAndVideoContext _context;
        public MembershipTypeRepository(BookAndVideoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<MembershipType> GetByName(string name)
        {
            var membershipType = await _context.MembershipTypes.FirstOrDefaultAsync(x => x.Name == name);
            return membershipType;
        }
    }
}

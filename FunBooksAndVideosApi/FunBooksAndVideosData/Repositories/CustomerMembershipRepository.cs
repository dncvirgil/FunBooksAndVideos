using FunBooksAndVideos.Data.Entities;
using FunBooksAndVideos.Data.Repositories.Interfaces;

namespace FunBooksAndVideos.Data.Repositories
{
    public class CustomerMembershipRepository : ICustomerMembershipRepository
    {
        private readonly BookAndVideoContext _context;
        public CustomerMembershipRepository(BookAndVideoContext _context)
        {
            this._context = _context;
        }

        public async Task Add(int customerId, int membershipTypeId)
        {
            var customerMembership = new CustomerMembership()
            {
                CustomerId = customerId,
                MembershipTypeId = membershipTypeId
            };

            _context.CustomerMembership.Add(customerMembership);
            _context.SaveChanges();
        }
    }
}

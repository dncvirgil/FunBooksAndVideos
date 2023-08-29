using FunBooksAndVideos.Data.Entities;
using FunBooksAndVideos.Data.Repositories.Interfaces;

namespace FunBooksAndVideos.Data.Repositories
{
    public class CustomerMembershipRepository : ICustomerMembershipRepository
    {
        private readonly BookAndVideoContext context;
        public CustomerMembershipRepository(BookAndVideoContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(int customerId, int membershipTypeId)
        {
            var customerMembership = new CustomerMembership()
            {
                CustomerId = customerId,
                MembershipTypeId = membershipTypeId
            };

            context.CustomerMembership.Add(customerMembership);
            await context.SaveChangesAsync();
        }
    }
}

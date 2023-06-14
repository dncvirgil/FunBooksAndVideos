using System;

namespace FunBooksAndVideos.Data.Repositories.Interfaces
{
    public interface ICustomerMembershipRepository
    {
        Task Add(int customerId, int membershipTypeId);
    }
}

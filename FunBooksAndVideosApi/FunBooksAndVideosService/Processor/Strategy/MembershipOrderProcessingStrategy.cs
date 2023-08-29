using FunBooksAndVideos.Data.Repositories.Interfaces;
using FunBooksAndVideos.Domain;

namespace FunBooksAndVideos.Service.Processor.Strategy
{
    public class MembershipOrderProcessingStrategy : IPurchaseOrderProcessingStrategy
    {
        public List<string> ProductType { get => new() { "Membership" }; }

        private readonly ICustomerMembershipRepository customerMembershipRepository;
        private readonly IMembershipTypeRepository membershipTypeRepository;

        public MembershipOrderProcessingStrategy(ICustomerMembershipRepository customerMembershipRepository,
                                                 IMembershipTypeRepository membershipTypeRepository)
        {
            this.customerMembershipRepository = customerMembershipRepository ?? throw new ArgumentNullException(nameof(customerMembershipRepository));
            this.membershipTypeRepository = membershipTypeRepository ?? throw new ArgumentNullException(nameof(membershipTypeRepository));
        }

        public async Task Process(PurchaseOrder purchaseOrder, Product product)
        {
            var membership = await membershipTypeRepository.GetByName(product.Name);
            await customerMembershipRepository.Add(purchaseOrder.Customer.Id, membership.Id);
        }
    }
}

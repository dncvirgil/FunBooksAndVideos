using FunBooksAndVideos.Data.Entities;
using FunBooksAndVideos.Data.Repositories.Interfaces;

namespace FunBooksAndVideos.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BookAndVideoContext _context;
        public CustomerRepository(BookAndVideoContext context)
        {
            _context = context;
        }

        public async Task<Customer> Get(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x=> x.Id == id);
            return customer;
        }
    }
}

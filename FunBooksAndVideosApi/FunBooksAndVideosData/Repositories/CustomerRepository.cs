using FunBooksAndVideos.Data.Entities;
using FunBooksAndVideos.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FunBooksAndVideos.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BookAndVideoContext context;
        public CustomerRepository(BookAndVideoContext context)
        {
            this.context = context;
        }

        public async Task<Customer?> Get(int id)
        {
            var customer = await context.Customers.FirstOrDefaultAsync(x=> x.Id == id);
            return customer;
        }
    }
}

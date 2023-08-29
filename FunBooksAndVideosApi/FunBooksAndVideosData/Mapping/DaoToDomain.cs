namespace FunBooksAndVideos.Data.Mapping
{
    public static class DaoToDomain
    {
        public static Domain.Product ToDomain(this Entities.Product product)
        {
            return new Domain.Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Url = product.Url,
                ProductType = new Domain.ProductType
                { 
                    Id = product.ProductType.Id,
                    Name = product.ProductType.Name
                }
            };
        }

        public static Domain.Customer ToDomain(this Entities.Customer customer)
        {
            return new Domain.Customer
            {
                Id = customer.Id,
                Name= customer.Name,
                Email=customer.Email,
                BillingAddress=customer.BillingAddress,
                DeliveryAddress=customer.DeliveryAddress
            };
        }
    }
}

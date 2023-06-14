using Microsoft.EntityFrameworkCore;

namespace FunBooksAndVideos.Data.Entities
{
    [Index(nameof(Name), IsUnique = false, Name = "Index_Product_Name")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Url { get; set; }
        public int ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }
    }
}

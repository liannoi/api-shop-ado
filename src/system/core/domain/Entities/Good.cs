using System.Collections.Generic;

namespace ShopAdo.System.Core.Domain.Entities
{
    public class Good
    {
        public Good()
        {
            Photo = new HashSet<Photo>();
            SalePos = new HashSet<SalePos>();
        }

        public int GoodId { get; set; }
        public string GoodName { get; set; }
        public int? ManufacturerId { get; set; }
        public int? CategoryId { get; set; }
        public decimal Price { get; set; }
        public decimal GoodCount { get; set; }

        public Category Category { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public ICollection<Photo> Photo { get; set; }
        public ICollection<SalePos> SalePos { get; set; }
    }
}
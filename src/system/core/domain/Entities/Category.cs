using System.Collections.Generic;

namespace ShopAdo.System.Core.Domain.Entities
{
    public class Category
    {
        public Category()
        {
            Good = new HashSet<Good>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Good> Good { get; set; }
    }
}
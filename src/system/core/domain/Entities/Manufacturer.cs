using System.Collections.Generic;

namespace ShopAdo.System.Core.Domain.Entities
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            Good = new HashSet<Good>();
        }

        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }

        public ICollection<Good> Good { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace ShopAdo.System.Core.Domain.Entities
{
    public class Sale
    {
        public Sale()
        {
            SalePos = new HashSet<SalePos>();
        }

        public int SaleId { get; set; }
        public DateTime HireDate { get; set; }
        public int UserId { get; set; }

        public ICollection<SalePos> SalePos { get; set; }
    }
}
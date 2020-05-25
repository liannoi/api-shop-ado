namespace ShopAdo.System.Core.Domain.Entities
{
    public class SalePos
    {
        public int SalePosId { get; set; }
        public int SaleId { get; set; }
        public int GoodId { get; set; }
        public int GoodCount { get; set; }
        public decimal UnitPrice { get; set; }

        public Good Good { get; set; }
        public Sale Sale { get; set; }
    }
}
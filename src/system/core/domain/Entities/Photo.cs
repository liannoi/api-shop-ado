namespace ShopAdo.System.Core.Domain.Entities
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public int GoodId { get; set; }
        public string PhotoPath { get; set; }

        public Good Good { get; set; }
    }
}
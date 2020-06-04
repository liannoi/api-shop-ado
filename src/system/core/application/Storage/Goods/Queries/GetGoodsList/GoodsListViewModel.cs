using System.Collections.Generic;
using ShopAdo.System.Core.Application.Storage.Goods.Queries.GetGoodDetail;

namespace ShopAdo.System.Core.Application.Storage.Goods.Queries.GetGoodsList
{
    public class GoodsListViewModel
    {
        public IList<GoodDetailViewModel> Goods { get; set; }
    }
}
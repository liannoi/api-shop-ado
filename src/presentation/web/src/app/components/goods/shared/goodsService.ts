import {AbstractApiService} from '../../../common/services/abstractApiService';
import {GoodModel} from './goodModel';
import {GoodsListViewModel} from './goodsListViewModel';
import {goodsEndpoint} from '../../../addresses';

export class GoodsService extends AbstractApiService<GoodModel, GoodsListViewModel> {
    constructor() {
        super(goodsEndpoint);
    }
}

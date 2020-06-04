import React from 'react';

import {NavLink} from 'react-router-dom';

import './GoodsList.css';
import {GoodsListViewModel} from '../shared/goodsListViewModel';
import {GoodsService} from '../shared/goodsService';
import {LinkCreate} from '../../common/LinkCreate/LinkCreate';

type GoodsListProps = {};
type GoodsListState = { viewModel: GoodsListViewModel };

export class GoodsList extends React.Component<GoodsListProps, GoodsListState> {
    private goodsService: GoodsService;

    public constructor(props: GoodsListProps) {
        super(props);
        this.state = {viewModel: {goods: []}};
        this.goodsService = new GoodsService();
    }

    public async componentDidMount(): Promise<void> {
        await this.fetchGoods();
    }

    public render() {
        return (
            <React.Fragment>
                <div className="row mt-5 mb-4 text-center">
                    <div className="col-sm-12">
                        <h2>Goods</h2>
                    </div>
                </div>

                <LinkCreate/>

                <div className="row mb-4">
                    <div className="col-sm-12">
                        <table className="table border table-sm table-striped">
                            <thead className="thead-light table-bordered">
                            <tr>
                                <th>Name</th>
                                <th>Manufacturer</th>
                                <th>Category</th>
                                <th>Price</th>
                                <th>Count</th>
                                <th className="text-black-50">Actions</th>
                            </tr>
                            </thead>
                            <tbody>
                            {
                                this.state.viewModel.goods.map((item, index) => (
                                    <tr key={index}>
                                        <td>{item.goodName}</td>
                                        <td>{item.manufacturer.manufacturerName}</td>
                                        <td>{item.category?.categoryName}</td>
                                        <td>{item.price}</td>
                                        <td>{item.goodCount}</td>

                                        <td>
                                            <NavLink
                                                className="btn btn-light border btn-sm mr-2 pl-3 pr-3 font-weight-bolder"
                                                to={`/goods/${item.goodId}`}>
                                                Photos
                                            </NavLink>

                                            <NavLink
                                                className="btn btn-light border btn-sm mr-2 pl-3 pr-3 font-weight-bolder disabled"
                                                to="">
                                                Edit
                                            </NavLink>

                                            <NavLink
                                                className="btn btn-light border btn-sm pl-3 pr-3 font-weight-bolder disabled"
                                                to="">
                                                Delete
                                            </NavLink>
                                        </td>
                                    </tr>
                                ))
                            }
                            </tbody>
                        </table>
                    </div>
                </div>
            </React.Fragment>
        );
    }

    private async fetchGoods(): Promise<void> {
        this.setState({viewModel: await this.goodsService.getAll()});
    }
}

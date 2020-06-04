import React from 'react';

import {Card, CardColumns} from 'react-bootstrap';

import {GoodPhotoModel} from '../shared/goodPhotoModel';
import {GoodsService} from '../shared/goodsService';
import {serverAddress} from '../../../addresses';
import './GoodPhotos.css';

type GoodPhotosProps = { match: { params: { id: number } } }
type GoodPhotosState = { photos: GoodPhotoModel[] }

export class GoodPhotos extends React.Component<GoodPhotosProps, GoodPhotosState> {
    private goodId: number = 0;
    private goodsService: GoodsService;

    constructor(props: GoodPhotosProps) {
        super(props);
        this.state = {photos: []};
        this.goodsService = new GoodsService();
    }

    public async componentDidMount(): Promise<void> {
        this.goodId = this.props.match.params.id;
        await this.fetchGoodPhotos();
    }

    // Примитивная реализация паттерна "Шаблонный метод".
    public render() {
        let shouldRenderDefault: boolean = this.state.photos.length > 0;

        if (shouldRenderDefault) {
            return this.renderDefault();
        }

        return this.renderNoPhoto();
    }

    private renderNoPhoto() {
        return (
            <React.Fragment>
                <div className="row mt-5 mb-5 text-center">
                    <div className="col-sm-12">
                        <h1 className="text-center font-weight-bolder mt-5  message-default">
                            This product doesn't contain <br/> any photos.
                        </h1>
                    </div>
                </div>
            </React.Fragment>
        );
    }

    private renderDefault() {
        return (
            <React.Fragment>
                <div className="row mt-5 mb-4 text-center">
                    <div className="col-sm-12">
                        <h2>Gallery</h2>
                    </div>
                </div>

                {this.renderCardColumns()}
            </React.Fragment>
        );
    }

    private renderCardColumns() {
        return <CardColumns>
            {
                this.state.photos.map((item, index) => (
                    <Card key={index}>
                        <Card.Img variant="top" src={`${serverAddress}${item.photoPath}`}/>
                    </Card>
                ))
            }
        </CardColumns>;
    }

    private async fetchGoodPhotos(): Promise<void> {
        this.setState({photos: (await this.goodsService.getById(this.goodId)).photos});
    }
}

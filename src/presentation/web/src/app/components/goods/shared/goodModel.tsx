import {CategoryModel} from '../../categories/shared/categoryModel';
import {ManufacturerModel} from '../../manufacturers/shared/manufacturerModel';
import {GoodPhotoModel} from './goodPhotoModel';

export interface GoodModel {
    goodId: number;
    goodName: string;
    manufacturer: ManufacturerModel;
    category: CategoryModel | null;
    price: number;
    goodCount: number;
    photos: GoodPhotoModel[];
}

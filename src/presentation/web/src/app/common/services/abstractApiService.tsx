import {ApiService} from './apiService';

export abstract class AbstractApiService<TModel, TListModel> implements ApiService<TModel, TListModel> {
    protected endpoint: string;

    protected constructor(endpoint: string) {
        this.endpoint = endpoint;
    }

    public getAll(): Promise<TListModel> {
        return fetch(this.endpoint).then(response => response.json());
    }

    public create(model: TModel): Promise<TModel> {
        throw new Error();
    }

    public delete(id: number): Promise<TModel> {
        throw new Error();
    }

    public getById(id: number): Promise<TModel> {
        return fetch(`${this.endpoint}/${id}`).then(response => response.json());
    }

    public update(id: number, model: TModel): Promise<TModel> {
        throw new Error();
    }
}

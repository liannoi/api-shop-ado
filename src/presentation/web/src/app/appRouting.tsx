import React from 'react';

import {Route} from 'react-router-dom';

import {Home} from './components/common/Home/Home';
import {GoodsList} from './components/goods/GoodsList/GoodsList';
import {GoodPhotos} from './components/goods/GoodPhotos/GoodPhotos';

export const routes = [
    {
        path: '/goods/:id',
        component: GoodPhotos,
    },
    {
        path: '/goods',
        component: GoodsList,
    },
    {
        path: '/',
        component: Home,
    },
];

export const AppRouting = (route: any) => {
    return (
        <Route path={route.path} render={props => (<route.component {...props} routes={route.routes}/>)}/>
    );
};

import React from 'react';

import {Route} from 'react-router-dom';

import {Home} from './components/common/Home/Home';

export const routes = [
    /*{
        path: '/goods',
        component: GoodsList,
    },*/
    {
        path: '/',
        component: Home,
    },
];

// @ts-ignore
export const AppRouting = route => {
    return (
        <Route path={route.path} render={props => (<route.component {...props} routes={route.routes}/>)}/>
    );
};

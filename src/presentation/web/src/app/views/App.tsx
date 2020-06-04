import React from 'react';

import {Switch} from 'react-router-dom';
import {Container} from 'react-bootstrap';

import {AppRouting, routes} from '../appRouting';
import {NavTopMenu} from '../components/common/NavTopMenu/NavTopMenu';

export const App = () => {
    return (
        <React.Fragment>
            <NavTopMenu/>

            <Container>
                <main role="main">
                    <Switch>
                        {routes.map((route, index) => <AppRouting key={index} {...route} />)}
                    </Switch>
                </main>
            </Container>
        </React.Fragment>
    );
};

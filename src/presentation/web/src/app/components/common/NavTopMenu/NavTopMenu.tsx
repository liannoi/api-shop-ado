import React from 'react';
import {NavLink} from 'react-router-dom';
import {Container, Nav, Navbar} from 'react-bootstrap';

import './NavTopMenu.css';

export const NavTopMenu = () => {
    return (
        <header>
            <Navbar bg="dark" expand="lg" variant="dark">
                <Container>
                    <NavLink className="navbar-brand" to="/">Hometask</NavLink>
                    <Navbar.Toggle aria-controls="top-menu-header"/>

                    <Navbar.Collapse id="top-menu-header">
                        <Nav className="mr-auto">
                            <NavLink className="nav-link" to="/goods">Goods</NavLink>
                        </Nav>
                    </Navbar.Collapse>
                </Container>
            </Navbar>
        </header>
    );
};

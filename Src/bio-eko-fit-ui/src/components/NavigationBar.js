import React from 'react';
import Navbar from 'react-bootstrap/Navbar';
import Nav from 'react-bootstrap/Nav';
import { Link } from "react-router-dom";


const NavigationBar = () => 
    <Navbar bg="light" expan="lg">
        <Navbar.Brand href={'/'}>Bio-Eko-Fit</Navbar.Brand>
        <Nav className="mr-auto">
          <Link style={{marginRight: 10}} to={'/products'}>Produkty</Link>
          <Link style={{marginRight: 10}} to={'/meals'}>Posiłki</Link>
          <Link style={{marginRight: 10}} to={'/menus'}>Jadłospisy</Link>
        </Nav>        
    </Navbar>

export default NavigationBar;
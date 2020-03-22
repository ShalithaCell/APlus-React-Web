import React, { Component, Fragment } from 'react';
import { Link, NavLink } from 'react-router-dom';
import { NavbarBrand } from 'reactstrap';
import { library } from '@fortawesome/fontawesome-svg-core'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCheckSquare, faCoffee } from '@fortawesome/free-solid-svg-icons'
import NavItem from 'reactstrap/es/NavItem';

library.add(faCheckSquare, faCoffee);

export default  class Navbar extends Component
{
	render()
	{
		return (
    <header>
        <ul id="gn-menu" className="gn-menu-main">
            <li className="gn-trigger">
                <a className="gn-icon gn-icon-menu"><span>Menu</span></a>
                <nav className="gn-menu-wrapper">

                    <div className="gn-scroller">
                        <ul className="gn-menu">
                            <li className="gn-search-item">
                                <input placeholder="Search" type="search" className="gn-search"/>
                                <a className="gn-icon gn-icon-search"><span>Search</span>
                                </a>
                            </li>
                            <li>
                                <NavLink tag={ Link } className="gn-icon" to="/"><i className="fa fa-home" aria-hidden="true"></i> Home</NavLink>
                                <ul className="gn-submenu">
                                    <li><NavLink tag={ Link } className="gn-icon gn-icon-illustrator" to="/counter">Counter</NavLink></li>
                                    <li><NavLink tag={ Link } className="gn-icon gn-icon-photoshop" to="/fetch-data">Fetch data</NavLink></li>
                                </ul>
                            </li>

                        </ul>
                    </div>

                </nav>
            </li>
            <li>
                <NavbarBrand tag={ Link } to="/">WebPortal</NavbarBrand>
            </li>
            <Fragment>
                <NavItem>
                    <NavLink tag={ Link } className="text-dark" to={ '/' } >Register</NavLink>
                </NavItem>
                <NavItem>
                    <NavLink tag={ Link } className="text-dark" to={ '/' } >Login</NavLink>
                </NavItem>
            </Fragment>
        </ul>
    </header>
		);
	}
}

import React, { Component, Fragment } from 'react';
import { Link, NavLink } from 'react-router-dom';
import { NavbarBrand } from 'reactstrap';
import NavItem from 'reactstrap/es/NavItem';
import { connect } from 'react-redux';
import { doLogOut } from '../redux/userActions';
import { DestroySession } from '../services/sessionManagement';
import { withRouter } from "react-router-dom";

class Navbar extends Component
{

    logout = (e) => {
        e.preventDefault();

        this.props.doLogOut();
        DestroySession();

        this.props.history.push("/");
        window.location.reload();
    }

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
                    <NavLink tag={ Link } className="text-dark" to={ '/' } >Hello { this.props.items.userName }</NavLink>
                </NavItem>
                <NavItem>
                    <a className="text-dark" onClick={ this.logout } >Logout</a>
                </NavItem>
            </Fragment>
        </ul>
    </header>
		);
	}
}

const mapStateToProps = (state) => ({
    items : state.user
})

export default connect(mapStateToProps, { doLogOut })(withRouter(Navbar));

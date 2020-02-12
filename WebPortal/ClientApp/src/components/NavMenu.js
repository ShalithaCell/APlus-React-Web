import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import { LoginMenu } from './api-authorization/LoginMenu';
//import './NavMenu.css';
import { library } from '@fortawesome/fontawesome-svg-core'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCheckSquare, faCoffee } from '@fortawesome/free-solid-svg-icons'

library.add(faCheckSquare, faCoffee);

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
    }

    componentDidMount() {
        window.InitNavBar();
    }

    

  render () {
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
                                    <a className="gn-icon gn-icon-search"><span>Search</span></a>
                                </li>
                                    <li>
                                        <NavLink tag={Link} className="gn-icon gn-icon-download" to="/">Home</NavLink>
                                        <ul className="gn-submenu">
                                            <li><NavLink tag={Link} className="gn-icon gn-icon-illustrator" to="/counter">Counter</NavLink></li>
                                            <li><NavLink tag={Link} className="gn-icon gn-icon-photoshop" to="/fetch-data">Fetch data</NavLink></li>
                                        </ul>
                                    </li>
                                    <li>
                                    <a className="gn-icon gn-icon-cog">Settings</a>
                                    <ul className="gn-submenu">
                                        <li><a href="/AppUsers" className="gn-icon"><i className="fa fa-users" aria-hidden="true"></i> Users</a></li>
                                        <li><a href="/Identity/Account/Register" className="gn-icon"><i className="fa fa-user-o" aria-hidden="true"></i> New User</a></li>
                                        </ul>
                                    </li>
                                    <li><a className="gn-icon gn-icon-help">Help</a></li>
                                    <li>
                                    <a className="gn-icon gn-icon-archive">Archives</a>
                                    <ul className="gn-submenu">
                                        <li><a className="gn-icon gn-icon-article">Articles</a></li>
                                        <li><a className="gn-icon gn-icon-pictures">Images</a></li>
                                        <li><a className="gn-icon gn-icon-videos">Videos</a></li>
                                        </ul>
                                    </li>
                            </ul>
                        </div>
                        
                    </nav>
            </li>
                <li>
                    <NavbarBrand tag={Link} to="/">WebPortal</NavbarBrand>
                </li>
                <LoginMenu>
                </LoginMenu>
        </ul>
      </header>
    );
  }
}

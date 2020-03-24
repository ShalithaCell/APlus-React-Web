import React, { Component } from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom'
import logo from './logo.svg';
import './App.css';
import home from './component/home'
import login from './component/login'
import sales from '../src/sales'
import addSupplier from './component/addSupplier'
import informSupplier from './component/informSupplier'
import sales_homes from './component/sales_home'

class App extends Component {
	render(){
		return (
    <BrowserRouter>
        <div className="App">
            <Switch>
                <Route path='/home' component={ home } />
                <Route path='/login' component={ login } />
                <Route path='/sales' component={ sales } />
                <Route path='/addSupplier' component={ addSupplier } />
                <Route path='/informSupplier' component={ informSupplier } />
                <Route path='/sales_homes' component={ sales_homes } />
                
            </Switch>
        </div>
    </BrowserRouter>
		);
	}
}

export default App;

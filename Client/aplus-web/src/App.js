import React, { Component } from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom'
import logo from './logo.svg';
import './App.css';
import home from './component/home'
import login from './component/login'
import customeradd from './component/customeradd'
import customer_list from './component/customer_list'

class App extends Component {
	render(){
		return (
    <BrowserRouter>
        <div className="App">
            <Switch>
                <Route path='/home' component={ home } />
                <Route path='/login' component={ login } />
                <Route path='/customeradd' component={ customeradd } />
                <Route path='/customer_list' component={ customer_list } />
            </Switch>
        </div>
    </BrowserRouter>
		);
	}
}

export default App;

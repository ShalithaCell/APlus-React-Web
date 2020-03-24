import React, { Component } from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom'
import logo from './logo.svg';
import './App.css';
import home from './component/home'
import login from './component/login'
import Attendance from './component/Attendance'
import EmployeeRequest from './component/EmployeeRequest'
import AddRequest from './component/AddRequest'
import UpdateRequest from './component/UpdateRequest'
import request from './component/request'

class App extends Component {
	render(){
		return (
    <BrowserRouter>
        <div className="App">
            <Switch>
                <Route path='/home' component={ home } />
                <Route path='/login' component={ login } />
                <Route path='/Attendance' component={ Attendance } />
                <Route path='/EmployeeRequest' component={ EmployeeRequest } />
                <Route path='/AddRequest' component={ AddRequest } />
                <Route path='/UpdateRequest' component={ UpdateRequest } />
                <Route path='/request' component={ request } />
            </Switch>
        </div>
    </BrowserRouter>
		);
	}
}

export default App;

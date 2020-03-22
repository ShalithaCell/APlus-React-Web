import React, { Component } from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom'
import logo from './logo.svg';
import './App.css';
import home from './component/home'
import login from './component/login'
import add from './component/add'
import chart from './component/chart'

class App extends Component {
	render(){
		return (
    <BrowserRouter>
        <div className="App">
            <Switch>
                <Route path='/home' component={ home } />
                <Route path='/login' component={ login } />
                <Route path= '/add' component={ add }/>
                <Route path= '/chart' component={ chart }/>

            </Switch>
        </div>
    </BrowserRouter>
		);
	}
}

export default App;

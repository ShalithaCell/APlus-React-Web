import React, { Component } from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom'
import logo from './logo.svg';
import './App.css';
import home from './component/home'

class App extends Component {
	render(){
		return (
    <BrowserRouter>
        <div className="App">
            <Switch>
                <Route path='/' component={ home } />
            </Switch>
        </div>
    </BrowserRouter>
		);
	}
}

export default App;

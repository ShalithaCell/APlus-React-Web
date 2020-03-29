/* eslint-disable camelcase */
import React, { Component } from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom'
import logo from './logo.svg';
import './App.css';
import home from './component/home'
import login from './component/login'
import checkout from './component/checkout'
import transactions from './component/transactions'
import payment_form from './component/payment_form'
import review from './component/review'
import salary_management from './component/salary_management'

class App extends Component {
    // eslint-disable-next-line class-methods-use-this
    render() {
        return (
            <BrowserRouter>
                <div className="App">
                    <Switch>
                        <Route path='/home' component={ home } />
                        <Route path='/login' component={ login } />
                        <Route path='/checkout' component={ checkout } />
                        <Route path='/payment_form' component={ payment_form } />
                        <Route path='/review' component={ review } />
                        <Route path='/transactions' component={ transactions } />
                        <Route path='/salary_management' component={ salary_management } />
                    </Switch>
                </div>
            </BrowserRouter>
        );
    }
}

export default App;

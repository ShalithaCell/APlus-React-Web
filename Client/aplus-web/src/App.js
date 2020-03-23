/* eslint-disable */
import React, { Component } from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom'
import logo from './logo.svg';
import { connect } from 'react-redux';
import { setUserState } from './redux/userActions';
import { IsAuthenticated } from './services/authenticationService';
import Loader from 'react-loader-spinner'
import './App.css';
import 'react-loader-spinner/dist/loader/css/react-spinner-loader.css'
import home from './component/home'
import login from './component/login'
import add from './component/add'
import chart from './component/chart'
import update from './component/update';
import register from './component/register';
import RegisterRole from './component/role/registerRole';


class App extends Component {

	constructor(props) {
		super(props)
		this.state = { auth: false }
	}

	render(){
		return (
    <BrowserRouter>
        <div className="App">
			{ IsAuthenticated(this.props.setUserState) ?
				<Switch>
					<Route exact path='/login' component={ login } />
					<Route exact path='/add' component={ add }/>
					<Route exact path='/chart' component={ chart }/>
					<Route exact path='/' component={ home } />
					<Route exact path='/home' component={ home }/>
					<Route exact path='/register' component={ register }/>
					<Route exact path='/registerRole' component={ RegisterRole }/>
				</Switch>
				:
				<Switch>
					<Route path='/' component={ login } />
				</Switch>
			}

            {this.props.loader ?
                <div className="to-center">
                    <Loader
						type="Triangle"
						color="#00BFFF"
						height={ 200 }
						width={ 200 }
						visible={ true }
					/>
                </div>
				:
                <div></div>
			}
        </div>
    </BrowserRouter>
		);
	}
}

const mapStateToProps = (state) => ({
	loader : state.system.loader
})

export default connect(mapStateToProps, { setUserState })(App);

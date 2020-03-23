import React, { Component } from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom'
import logo from './logo.svg';
import Loader from 'react-loader-spinner'
import './App.css';
import 'react-loader-spinner/dist/loader/css/react-spinner-loader.css'
import home from './component/home'
import login from './component/login'
import storeAdd from './component/storeAdd'
import storeChart from './component/storeChart'
import storeUpdate from './component/storeUpdate';
import { connect } from 'react-redux';


class App extends Component {
	render(){
		return (
    <BrowserRouter>
        <div className="App">
            <Switch>
                <Route exact path='/login' component={ login } />
                <Route exact path= '/storeAdd' component={ storeAdd }/>
                <Route exact path= '/storeChart' component={ storeChart }/>
                <Route exact path='/' component={ home } />
                <Route exact path= '/storeUpdate' component={ storeUpdate } />
            </Switch>
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

export default connect(mapStateToProps, null)(App);

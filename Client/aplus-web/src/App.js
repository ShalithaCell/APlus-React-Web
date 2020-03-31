/* eslint-disable camelcase */
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
import checkout from './component/checkout'
import transactions from './component/transactions'
import payment_form from './component/payment_form'
import review from './component/review'
import salary_management from './component/salary_management'
import addSupplier from './component/addSupplier'
import informSupplier from './component/informSupplier'
import sales_homes from './component/sales_home'
import Attendance from './component/Attendance'
import EmployeeRequest from './component/EmployeeRequest'
import AddRequest from './component/AddRequest'
import UpdateRequest from './component/UpdateRequest'
import request from './component/request'
import customeradd from './component/customeradd'
import storeAdd from './component/storeAdd'
import storeChart from './component/store/storeChart'
import storeUpdate from './component/storeUpdate';
import register from './component/register';
import RegisterRole from './component/role/registerRole';
import SessionExpire from './component/sessionExpire';
import updateinventory from './component/updateinventory';
import dashboard from './component/dashboard'
import storeDashboard from './component/storeDashboard';
import map from './component/store/map';
import storePlan from './component/storePlan';
import addinventory from './component/addinventory';
import listOfRoles from './component/role/listOfRoles';
import { ToastContainer } from 'react-toastify';

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
                    <Route exact path= '/storeAdd' component={ storeAdd }/>
                    <Route exact path= '/storeChart' component={ storeChart }/>
                    <Route exact path= '/storeUpdate' component={ storeUpdate } />
                    <Route exact path='/' component={ home } />
                    <Route exact path='/home' component={ home }/>
                    <Route exact path='/register' component={ register }/>
                    <Route exact path='/registerRole' component={ RegisterRole }/>
                    <Route exact path='/roles' component={ listOfRoles }/>
                    <Route exact path='/customeradd' component={ customeradd } />
                    <Route exact path='/EmployeeRequest' component={ EmployeeRequest } />
                    <Route exact path='/AddRequest' component={ AddRequest } />
                    <Route exact path='/UpdateRequest' component={ UpdateRequest } />
                    <Route exact path='/request' component={ request } />
                    <Route exact path='/addinventory' component={ addinventory } />
                    <Route exact path='/addSupplier' component={ addSupplier } />
                    <Route exact path='/informSupplier' component={ informSupplier } />
                    <Route exact path='/sales_homes' component={ sales_homes } />
                    <Route exact path='/updateinventory' component={ updateinventory } />
                    <Route exact path='/dash' component={ dashboard } />
                    <Route exact path= '/storeDashboard' component={ storeDashboard } />
                    <Route exact path= '/storePlan' component={ map } />
                    <Route exact path='/checkout' component={ checkout } />
                    <Route exact path='/payment_form' component={ payment_form } />
                    <Route exact path='/review' component={ review } />
                    <Route exact path='/transactions' component={ transactions } />
                    <Route exact path='/salary_management' component={ salary_management } />
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
            <SessionExpire />
            <ToastContainer />
        </div>
    </BrowserRouter>
		);
	}
}

const mapStateToProps = (state) => ({
	loader : state.system.loader
})

export default connect(mapStateToProps, { setUserState })(App);

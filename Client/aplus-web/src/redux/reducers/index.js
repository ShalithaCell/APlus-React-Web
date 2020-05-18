import { combineReducers } from 'redux';
import userReducer from './userReducer'
import systemDefaults from './systemDefaults';
import roleReducer from './roleReducer';
import inventoryReducer from './inventoryReducer';
import supplierReducer from './supplierReducer';
import transactionReducer from './transactionReducer'
import customerReducers from './customerReducers';
import requestReducer from './requestReducer';
import branchReducer from './branchReducer';
import billReducer from './billReducer';
import orgReducer from './orgReducer';
import attendanceReducer from './attendanceReducer';

const reducers = combineReducers(
	{
		user        : userReducer,
		system      : systemDefaults,
		role        : roleReducer,
		customer    : customerReducers,
		inventory  	: inventoryReducer,
		transaction : transactionReducer,
		request     : requestReducer,
		branch      : branchReducer,
    supplier    : supplierReducer,
		bill        : billReducer,
		org         : orgReducer,
   	supplier    : supplierReducer,
	  attendance  : attendanceReducer
	});

export default reducers;	

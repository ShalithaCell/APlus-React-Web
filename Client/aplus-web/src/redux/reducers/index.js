import { combineReducers } from 'redux';
import userReducer from './userReducer'
import systemDefaults from './systemDefaults';
import roleReducer from './roleReducer';
import inventoryReducer from './inventoryReducer';
import transactionReducer from './transactionReducer';
import supplierReducer from './supplierReducer';
import transactionReducer from './transactionReducer'
import requestReducer from './requestReducer';
import branchReducer from './branchReducer';

const reducers = combineReducers(
	{
		user        : userReducer,
		system      : systemDefaults,
		role        : roleReducer,
		inventory  	: inventoryReducer,
		transaction : transactionReducer,
		transaction : transactionReducer,
		request     : requestReducer,
		branch      : branchReducer,
    supplier : supplierReducer
	});

export default reducers;	
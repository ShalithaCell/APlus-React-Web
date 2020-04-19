import { combineReducers } from 'redux';
import userReducer from './userReducer'
import systemDefaults from './systemDefaults';
import roleReducer from './roleReducer';
import supplierReducer from './supplierReducer';
import transactionReducer from './transactionReducer'
import requestReducer from './requestReducer';
import branchReducer from './branchReducer';

const reducers = combineReducers(
	{
		user        : userReducer,
		system      : systemDefaults,
		role        : roleReducer,
		transaction : transactionReducer,
		request     : requestReducer,
		branch      : branchReducer,
    supplier : supplierReducer
	});

export default reducers;

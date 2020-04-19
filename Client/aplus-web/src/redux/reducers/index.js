import { combineReducers } from 'redux';
import userReducer from './userReducer'
import systemDefaults from './systemDefaults';
import roleReducer from './roleReducer';
import transactionReducer from './transactionReducer'
import branchReducer from './branchReducer';

const reducers = combineReducers(
	{
		user        : userReducer,
		system      : systemDefaults,
		role        : roleReducer,
		transaction : transactionReducer,
		branch      : branchReducer
	});

export default reducers;

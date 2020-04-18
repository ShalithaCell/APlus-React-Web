import { combineReducers } from 'redux';
import userReducer from './userReducer'
import systemDefaults from './systemDefaults';
import roleReducer from './roleReducer';
import inventoryReducer from './inventoryReducer';
import transactionReducer from './transactionReducer';

const reducers = combineReducers(
	{
		user        : userReducer,
		system      : systemDefaults,
		role        : roleReducer,
		inventory  	: inventoryReducer,
		transaction : transactionReducer
	});

export default reducers;

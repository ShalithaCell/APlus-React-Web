import { combineReducers } from 'redux';
import userReducer from './userReducer'
import systemDefaults from './systemDefaults';
import roleReducer from './roleReducer';
import transactionReducer from './transactionReducer'
import requestReducer from './requestReducer';

const reducers = combineReducers(
	{
		user        : userReducer,
		system      : systemDefaults,
		role        : roleReducer,
		transaction : transactionReducer,
		request     : requestReducer
	});

export default reducers;

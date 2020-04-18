import { combineReducers } from 'redux';
import userReducer from './userReducer'
import systemDefaults from './systemDefaults';
import roleReducer from './roleReducer';
import supplierReducer from './supplierReducer';

const reducers = combineReducers(
	{
		user     : userReducer,
		system   : systemDefaults,
		role     : roleReducer,
		supplier : supplierReducer
	});

export default reducers;

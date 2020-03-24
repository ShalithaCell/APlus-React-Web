import { combineReducers } from 'redux';
import userReducer from './userReducer'
import systemDefaults from './systemDefaults';
import roleReducer from './roleReducer';

const reducers = combineReducers(
	{
		user   : userReducer,
		system : systemDefaults,
		role   : roleReducer
	});

export default reducers;

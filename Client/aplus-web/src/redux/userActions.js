import { DO_LOGIN, DO_LOGOUT, POPUP_SPINNER, SET_SESSION_EXPIRED, UPDATE_USER_LIST } from './actionTypes';
import axios from 'axios';
import { LOGIN_ENDPOINT, PASSWORD_RESET_ENDPOINT, REGISTER_USER_ENDPOINT, SYNC_USER_LIST_ENDPOINT } from '../config';
import { GetSession } from '../services/sessionManagement';
import { decrypt } from '../services/EncryptionService';

export const doLogin = (email, password) => async (dispatch) =>
{
	let success = false;
	let resData;

	//API call
	await axios({
		method : 'post',
		url    : LOGIN_ENDPOINT,
		data   : {
			email : email, password : password
		}
	})
		.then(function(response)
		{
			resData = response.data;
			success = true;
		})
		.catch(function(error)
		{
			resData = error;
			console.log(error);
		});

	//Check API call is success or not
	if(success){
		dispatch({
			type    : DO_LOGIN,
			payload : resData
		});

		return { 'success': resData.authenticated, 'data': resData, 'error': false };
	}else{
		return { 'success': success, 'data': resData, 'error': true };
	}

}

export const doLogOut = () => (dispatch) => {
	dispatch({
		type    : DO_LOGOUT,
		payload : null
	});
}

export const setUserState = ( data ) => (dispatch) =>
{
	dispatch({
		type    : DO_LOGIN,
		payload : data
	});
}

export const resetUserPassword = (email) => async (dispatch) => {
	//API call
	let success = false;
	let message = '';
	await axios.post(PASSWORD_RESET_ENDPOINT, { 'Email': email } )
		.then((response) => {
			success = true;
			message = response.data;
		})
		.catch((error) => {
			console.log(error.response);
			success = false;
			message = response.data;
		});
	
	return { 'success': success, 'message': message };
}

export const updateUserList = (currentUserRole) => async (dispatch) => {

	const localData = JSON.parse(GetSession());
	let token = localData.sessionData.token;
	token = decrypt(token); //decrypt the token

	//spinner
	dispatch({
		type    : POPUP_SPINNER,
		payload : true
	});

	//API call
	axios({
		method  : 'post',
		url     : SYNC_USER_LIST_ENDPOINT,
		headers : { Authorization: 'Bearer ' + token },
		data    : { 'roleId': currentUserRole }
	})
		.then(function(response)
		{
			dispatch({
				type    : UPDATE_USER_LIST,
				payload : response.data
			});

			//spinner
			dispatch({
				type    : POPUP_SPINNER,
				payload : false
			});
		})
		.catch(function(error)
		{
			if(error.response.status === 401){
				dispatch({
					type    : SET_SESSION_EXPIRED,
					payload : true
				});

			}
			throw error;
		});
}

export const createNewUser = (userObj) => async (dispatch) => {

	const localData = JSON.parse(GetSession());
	let token = localData.sessionData.token;
	token = decrypt(token); //decrypt the token

	//spinner
	dispatch({
		type    : POPUP_SPINNER,
		payload : true
	});

	let result = false;

	//API call
	await axios({
		method  : 'post',
		url     : REGISTER_USER_ENDPOINT,
		headers : { Authorization: 'Bearer ' + token },
		data    : userObj 
	})
		.then(function(response)
		{
			//spinner
			dispatch({
				type    : POPUP_SPINNER,
				payload : false
			});

			result = response.data;
		})
		.catch(function(error)
		{
			//spinner
			dispatch({
				type    : POPUP_SPINNER,
				payload : false
			});

			if(error.response.status === 401){
				dispatch({
					type    : SET_SESSION_EXPIRED,
					payload : true
				});

			}
			throw error;
		});

	return result;
}

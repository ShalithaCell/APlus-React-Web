import { DO_LOGIN, GET_TOKEN } from './actionTypes';
import axios from 'axios';
import { LOGIN_ENDPOINT } from '../config';

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

		return { "success": resData.authenticated, "data": resData, "error": false };
	}else{
		return { "success": success, "data": resData, "error": true };
	}

}

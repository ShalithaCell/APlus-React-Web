import { DO_LOGIN, GET_TOKEN } from './actionTypes';
import axios from 'axios';
import { LOGIN_ENDPOINT } from '../config';

export const doLogin = (email, password) => (dispatch) =>
{
	axios({
		method : 'post',
		url    : LOGIN_ENDPOINT,
		data   : {
			email : email, password : password
		}
	}).then((res) => dispatch({
			type    : DO_LOGIN,
			payload : res.data
		}));

}

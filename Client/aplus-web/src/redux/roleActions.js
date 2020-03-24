import { SET_SESSION_EXPIRED, UPDATE_ROLE_LIST } from './actionTypes';
import axios from 'axios';
import { GET_ROLE_LIST_ENDPOINT } from '../config';
import { decrypt } from '../services/EncryptionService';
import { GetSession } from '../services/sessionManagement';
import { SetSessionExpiredStatus } from './systemActions';

export const updateRoleDetails = (roles)  => async (dispatch) =>
{

	const localData = JSON.parse(GetSession());
	let token = localData.sessionData.token;
	token = decrypt(token); //decrypt the token

	//API call
	axios({
		method  : 'get',
		url     : GET_ROLE_LIST_ENDPOINT,
		headers : { Authorization: "Bearer " + token }
	})
		.then(function(response)
		{
			dispatch({
				type    : UPDATE_ROLE_LIST,
				payload : response.data
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

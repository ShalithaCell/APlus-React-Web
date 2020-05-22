/* eslint-disable camelcase */
import { ADD_SALARY, VIEW_SALARY } from './actionTypes';
import axios from 'axios';
import { ADD_SALARY_ENDPOINT, VIEW_SALARY_ENDPOINT, DELETE_SALARY_ENDPOINT } from '../config';
import { decrypt } from '../services/EncryptionService';
import { GetSession } from '../services/sessionManagement';
import { SetSessionExpiredStatus } from './systemActions';
import { useState } from 'react';
import { SET_SESSION_EXPIRED } from '../redux/actionTypes';

export const addSalary = (values) => async (dispatch) =>
{
	const localData = JSON.parse(GetSession());
	let token = localData.sessionData.token;
	token = decrypt(token);

	const success = false;
	let resData;
	console.log(token);
	const salaryObj = {
			Name        : values.name,
			Designation : values.designation,
            Eid         : values.eid,
            Basic       : values.basic,
            Bonus       : values.bonus,       
            Attendance  : values.attendance,
            For_month   : values.for_month,
            Total       : values.total
	}

	//API call
	await axios({
		method  : 'post',
		url     : ADD_SALARY_ENDPOINT,
		headers : { Authorization: 'Bearer ' + token },
		data    : salaryObj
	})
		.then(function(response)
		{
			console.log(response);
		})
		.catch(function(error)
		{
			console.log(error);
			if (error.response.status === 401) {
				dispatch({
					type    : SET_SESSION_EXPIRED,
					payload : true
				})
			}
			throw error;
		});

	//Check API call is success or not
	// if(success){
	// 	dispatch({
	// 		type    : ADD_SALARY,
	// 		payload : resData
	// 	});

	// 	return { 'success': resData.authenticated, 'data': resData, 'error': false };
	// }else{
	// 	return { 'success': success, 'data': resData, 'error': true };
	// }

}
export const viewSalary = () => async (dispatch) => {
	const localData = JSON.parse(GetSession());
	let token = localData.sessionData.token;
	token = decrypt(token);

	let responseData;

	axios({
		method  : 'get',
		url     : VIEW_SALARY_ENDPOINT,
		headers : { Authorization: 'Bearer ' + token }
	})
		.then(function (response) {
			dispatch({
				type    : VIEW_SALARY,
				payload : response.data
			});

			return response.data;
		})
		.catch(function (error) {
			console.log(error);
			
/*									if(error.response.status === 401){
			
										dispatch({
											type    : SET_SESSION_EXPIRED,
											payload : true
										});
										return
									}
									throw error;*/
		}

		);
}

export const deleteSal = (id) => async (dispatch) => {

	const localData = JSON.parse(GetSession());
	let token = localData.sessionData.token;
	token = decrypt(token); //decrypt the token

	let responseData;

	//API call
	await axios({
		method  : 'post',
		url     : DELETE_SALARY_ENDPOINT,
		headers : {
			Authorization : 'Bearer ' + token
		},
		data : { id }
	})
		.then(function (response) {
			responseData = true;
		})
		.catch(function (error) {
			if (error.response.status === 401) {
				dispatch({
					type    : SET_SESSION_EXPIRED,
					payload : true
				});

			} else if (error.response.status === 409) {
				responseData = false;
			}else if (error.response.status === 500) {
				console.log("error");}
			throw error;
		});

	return responseData;

}
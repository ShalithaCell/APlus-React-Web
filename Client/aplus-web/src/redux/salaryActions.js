/* eslint-disable camelcase */
import { ADD_SALARY } from './actionTypes';
import axios from 'axios';
import { ADD_SALARY_ENDPOINT } from '../config';

export const addSalary = (salary_id, name, eid, basic, bonus, designation, attendance, paid_date, for_month, total) => async () =>
{

	let success = false;
	let resData;

	//API call
	await axios({
		method : 'post',
        url    : ADD_SALARY_ENDPOINT,
		data   : {
            Salary_id   : salary_id, 
            Name        : name,
            Eid         : eid,
            Basic       : basic,
            Bonus       : bonus,
            Designation : designation,
            Attendance  : attendance,
            Paid_date   : paid_date,
            For_month   : for_month,
            Total       : total
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
			type    : ADD_SALARY,
			payload : resData
		});

		return { 'success': resData.authenticated, 'data': resData, 'error': false };
	}else{
		return { 'success': success, 'data': resData, 'error': true };
	}

}

export const setUserState = ( data ) => (dispatch) =>
{
	dispatch({
		type    : ADD_SALARY,
		payload : data
	});
}

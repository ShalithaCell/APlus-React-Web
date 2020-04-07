// /* eslint-disable camelcase */
// import { ADD_TRANS } from './actionTypes';
// import axios from 'axios';
// import { ADD_TRANSACTION_ENDPOINT } from '../config';

// export const addTransaction = (transid, userid, desc, date, time, qty, unit, total) => async () =>
// {

// 	let success = false;
// 	let resData;

// 	//API call
// 	await axios({
// 		method : 'post',
//         url    : ADD_TRANSACTION_ENDPOINT,
// 		data   : {
//             Transaction_ID : transid, 
//             User_ID        : userid,
//             Description    : desc,
//             Date           : date,
//             Time           : time,
//             Qty            : qty,
//             Unit           : unit,
//             Total          : total
// 		}
// 	})
// 		.then(function(response)
// 		{
// 			resData = response.data;
// 			success = true;
// 		})
// 		.catch(function(error)
// 		{
// 			resData = error;
// 			console.log(error);
// 		});

// 	//Check API call is success or not
// 	if(success){
// 		dispatch({
// 			type    : ADD_TRANS,
// 			payload : resData
// 		});

// 		return { 'success': resData.authenticated, 'data': resData, 'error': false };
// 	}else{
// 		return { 'success': success, 'data': resData, 'error': true };
// 	}

// }

// export const setUserState = ( data ) => (dispatch) =>
// {
// 	dispatch({
// 	    type    : ADD_TRANS,
// 		payload : data
// 	});
// }

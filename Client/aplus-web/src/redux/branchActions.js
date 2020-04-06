import { GetSession } from '../services/sessionManagement';
import { decrypt } from '../services/EncryptionService';
import axios from 'axios';
import { ADD_BRANCH } from '../config';

export const branchActions = ()  => async () =>
{
	const localData = JSON.parse(GetSession());
	let token = localData.sessionData.token;
	token = decrypt(token); //decrypt the token

	let success = false;
	let resData;

	const user = {
		B_Name     : add.bName,
		Org_Name   : add.orgName,
		B_Location : add.location,
		B_Phone    : add.tpNo,
		B_Employee : add.noofEmployee
	}

	await axios({
		method  : 'post',
		url     : ADD_BRANCH,
		headers : { Authorization: 'Bearer ' + token },
		data    : user
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
}	
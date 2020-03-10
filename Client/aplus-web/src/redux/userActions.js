import { DO_LOGIN, GET_TOKEN } from './actionTypes';

export const doLogin = () => (dispatch) => 
{
		fetch( 'https://localhost:44317/users/authenticate', {
			method  : 'post',
			headers : {
				'Accept'       : 'application/json, text/plain, */*',
				'Content-Type' : 'application/json'
			},
			body : JSON.stringify({ email: "shalithax@gmail.com", password: "Mvc@2018" })
		}).then((res) => res.json())
			.then( (data) => dispatch({
				type    : DO_LOGIN,
				payload : data
			}));

}

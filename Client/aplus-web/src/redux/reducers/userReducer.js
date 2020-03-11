import { DO_LOGIN, GET_TOKEN } from '../actionTypes';
import { encrypt } from '../../services/EncryptionService';

const initialState = {
	authenticated : false,
	userID        : null,
	userName      : null,
	roleID        : null,
	role          : null,
	email         : null,
	orgID         : null,
	token         : null
}

export default function(state = initialState, action)
{
		switch (action.type)
		{
			case DO_LOGIN :
				return {
					...state,
					authenticated : action.payload.authenticated,
					userID        : action.payload.userID,
					userName      : action.payload.userName,
					roleID        : action.payload.roleID,
					role          : action.payload.role,
					email         : action.payload.email,
					orgID         : action.payload.orgID,
					token         : encrypt(action.payload.token)
				}
			default :
				return state;
		}
}

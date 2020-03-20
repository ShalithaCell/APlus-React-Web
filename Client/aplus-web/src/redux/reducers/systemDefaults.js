import { POPUP_DIALOG_FORGOTPASSWORD } from '../actionTypes';

const initialState = {
	popupForgotpwDialog : false
}

export default function(state = initialState, action)
{
	switch (action.type)
	{
		case POPUP_DIALOG_FORGOTPASSWORD :
			return {
				...state,
				popupForgotpwDialog : action.payload
			}
		default :
			return state;
	}
}

import { POPUP_DIALOG_FORGOTPASSWORD, POPUP_SPINNER } from '../actionTypes';

const initialState = {
	popupForgotpwDialog : false,
	loader              : false
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
		case POPUP_SPINNER :
			console.log(action.payload);
			return {
				...state,
				loader : action.payload
			}
		default :
			return state;
	}
}

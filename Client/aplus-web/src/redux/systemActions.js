import { POPUP_DIALOG_FORGOTPASSWORD, POPUP_SPINNER, SET_SESSION_EXPIRED } from './actionTypes';

export const popupPasswordResetDialog = ( popuped ) => (dispatch) => {
	dispatch({
		type    : POPUP_DIALOG_FORGOTPASSWORD,
		payload : popuped
	});
}

export const popupSpinner = ( popuped ) => (dispatch) => {
	dispatch({
		type    : POPUP_SPINNER,
		payload : popuped
	});
}

export const SetSessionExpiredStatus = ( expired ) => (dispatch) => {
	console.log('called SetSessionExpiredStatus');
	dispatch({
		type    : SET_SESSION_EXPIRED,
		payload : expired
	});
}

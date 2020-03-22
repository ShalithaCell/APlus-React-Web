import { POPUP_DIALOG_FORGOTPASSWORD, POPUP_SPINNER } from './actionTypes';

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

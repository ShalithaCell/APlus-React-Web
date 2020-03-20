import { POPUP_DIALOG_FORGOTPASSWORD } from './actionTypes';

export const popupPasswordResetDialog = ( popuped ) => (dispatch) => {
	dispatch({
		type    : POPUP_DIALOG_FORGOTPASSWORD,
		payload : popuped
	});
}

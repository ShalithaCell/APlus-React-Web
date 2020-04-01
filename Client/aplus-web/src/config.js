//api url
export const API_TARGET = 'https://localhost:44317/api/';

//Encryption secret key
export const SECRET_KEY = 'cbM2vLOTDUzL0nebSMH7Mutv7MY41HgOnzzF3VYv';

//local storage identification
export const IDENTIFICATION_STORAGE = '27761234452352463563452566';

//toast types
export const TOAST_SUCCESS = 'Success';
export const TOAST_ERROR = 'Error';
export const TOAST_WARN = 'Warning';
export const TOAST_INFO = 'Info';

//API end-points
export const LOGIN_ENDPOINT = API_TARGET +'users/authenticate';
export const PASSWORD_RESET_ENDPOINT = API_TARGET +'users/resetPassword';
export const SYNC_USER_LIST_ENDPOINT = API_TARGET +'users/getAllUsers';
export const SYNC_USER_Name_LIST_ENDPOINT = API_TARGET +'users/getUserNames';
export const REGISTER_USER_ENDPOINT = API_TARGET +'users/registerUser';

export const GET_ROLE_LIST_ENDPOINT = API_TARGET +'roles/getRoles';
export const REGISTER_NEW_ROLE_ENDPOINT = API_TARGET +'roles/registerRole';
export const GET_ROLE_ENDPOINT = API_TARGET +'roles/getRoleInfomation';
export const UPDATE_ROLE_ENDPOINT = API_TARGET +'roles/updateRole';
export const REMOVE_ROLE_ENDPOINT = API_TARGET +'roles/removeRole';

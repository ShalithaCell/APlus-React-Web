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
export const GET_ROLE_LIST_ENDPOINT = API_TARGET +'roles/getRoles';
export const REGISTER_NEW_ROLE_ENDPOINT = API_TARGET +'roles/registerRole';
export const GET_ROLE_ENDPOINT = API_TARGET +'roles/getRoleInfomation';
export const UPDATE_ROLE_ENDPOINT = API_TARGET +'roles/updateRole';
export const REMOVE_ROLE_ENDPOINT = API_TARGET +'roles/removeRole';
export const ADD_BILL_TRANSACTION_ENDPOINT = API_TARGET +'cashier/addBill';

export const ADD_SUPPLIER_ENDPOINT = API_TARGET +'supplier/addSupplier';
export const REMOVE_SUPPLIER_ENDPOINT = API_TARGET +'supplier/removeSupplier';
export const GET_SUPPLIER_ENDPOINT = API_TARGET +'supplier/getSupplier';
export const UPDATE_SUPPLIER_ENDPOINT = API_TARGET +'supplier/addSupplier';
export const UPDATE_SUPPLIER_DETAILS_ENDPOINT = API_TARGET +'supplier/addSupplier';
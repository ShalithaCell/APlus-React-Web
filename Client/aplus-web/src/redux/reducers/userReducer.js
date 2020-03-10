import { DO_LOGIN, GET_TOKEN } from '../actionTypes';

const initialState = {
	items : []
}

export default function(state = initialState, action)
{
		switch (action.type)
		{
			case DO_LOGIN :
				return {
					...state, items : action.payload
				}
			default :
				return state;
		}
}

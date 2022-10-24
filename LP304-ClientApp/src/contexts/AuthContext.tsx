import { createContext, useReducer } from "react";
import User from "../models/db/User";

interface Action {
    type: string;
    payload: User;
}

export const AuthContext = createContext<any>({});

export const authReducer = (state: Object, action: Action) => {

    switch (action.type) {
        case 'LOGIN':
            return { user: action.payload }
        case 'LOGOUT':
            return { user: null }
        default:
            return state
    }
}

interface Props {
    children: React.ReactNode
}

export const AuthContextProvider: React.FC<Props> = (Props) => {
    const [state, dispatch] = useReducer(authReducer, {
        user: JSON.parse(localStorage.getItem('user') || '{}')
    })

    return (
        <AuthContext.Provider value={{ state, dispatch }}>
            {Props.children}
        </AuthContext.Provider>
    )

}
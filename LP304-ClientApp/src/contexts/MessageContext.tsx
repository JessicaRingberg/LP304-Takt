import { createContext, useReducer } from "react";

interface Action {
    type: string;
    message: string;
}

export const MesasgeContext = createContext<any>({});

export const messageReducer = (state: Object, action: Action) => {

    switch (action.type) {
        case 'SUCCESS':
            return { messages: { error: false, message: action.message } }
        case 'ERROR':
            return { messages: { error: true, message: action.message } }
        case 'RESET':
            return { messages: {} }
        default:
            return state
    }
}

interface Props {
    children: React.ReactNode
}

export const MessageContextProvider: React.FC<Props> = (Props) => {
    const [state, dispatch] = useReducer(messageReducer, {
        messages: {}
    })

    return (
        <MesasgeContext.Provider value={{ state, dispatch }}>
            {Props.children}
        </MesasgeContext.Provider>
    )

}
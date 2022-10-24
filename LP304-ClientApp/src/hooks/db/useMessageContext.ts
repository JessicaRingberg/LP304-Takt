
import { useContext } from "react";
import { MesasgeContext } from "../../contexts/MessageContext";

export const useMessageContext = () => {

    const context = useContext(MesasgeContext)

    if (!context) {
        throw Error('useMessageContext must be used inside an MessageContextProvider')
    }

    return context;
}
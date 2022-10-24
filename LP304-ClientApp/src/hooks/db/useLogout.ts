import { Cookies } from "react-cookie"
import { useNavigate } from "react-router-dom"
import { useAuthContext } from "./useAuthContext"

export const useLogout = () => {
    const cookie = new Cookies()
    const navigate = useNavigate()
    const { dispatch } = useAuthContext()

    const logout = () => {
        localStorage.removeItem('user')
        
        cookie.remove("refresh")
        cookie.remove("token")
        
        dispatch({type: 'LOGOUT'})
        navigate("/login")
    }

    return {logout}

}
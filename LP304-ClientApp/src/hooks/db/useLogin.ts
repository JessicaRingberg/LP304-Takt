import { useAuthContext } from "./useAuthContext";
import { useState } from "react";
import ILogin from "../../models/db/Login";
import { Cookies } from 'react-cookie';
import { useNavigate } from "react-router-dom";
import { useMessageContext } from "./useMessageContext";
import User from "../../models/db/User";

export const useLogin = () => {
    const navigate = useNavigate();
    const [error, setError] = useState<string | null>(null)
    const [isLoading, setIsLoading] = useState<boolean>(false)
    const { dispatch } = useAuthContext();
    const { dispatch : dispatch2 } = useMessageContext()
    let cookie = new Cookies()


    const login = async (loginCred: ILogin) => {
        setIsLoading(true)
        setError(null)

        const response = await fetch('https://localhost:7112/api/User/Login', {
            method: 'POST',
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(loginCred)
        });
        const json = await response.json()

        if (!response.ok) {
            setIsLoading(false)
            setError(json.error)
        }

        if (response.status === 400) {
            setIsLoading(false)
            dispatch2({type: "ERROR", message: "Either the email or the password is incorrect."})
        }

        if (response.ok) {
            let user: User = json.user
            user.keepLoggedIn = loginCred.keepLoggedIn
            localStorage.setItem('user', JSON.stringify(user))
            cookie.set("token", json.jwt)
            cookie.set("refresh", json.refreshToken.token)

            dispatch({type: "LOGIN", payload: json.user})
            setIsLoading(false)
            navigate("/")
        }
    }

    return { login, isLoading, error }
}
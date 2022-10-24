import { useState } from "react";
import { Cookies } from "react-cookie";
import { useMessageContext } from "./useMessageContext"

export const usePost = (url: string) => {
    const [data, setData] = useState();
    const [isPending, setIsPending] = useState<boolean>(true);
    const [postError, setPostError] = useState<string | null>(null)
    const { dispatch } = useMessageContext()
    let cookie = new Cookies();

    const post = (value: Object) => {
        const abortFetch = new AbortController();

        fetch(url, {
            method: 'POST',
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + cookie.get("token")
            },
            signal: abortFetch.signal,
            body: JSON.stringify(value)
        }).then(res => {
            if (!res.ok) {
                dispatch({type: "ERROR", message: "Could not add company" })
                throw Error('Could not add the data.')
            }
            return res.json()
        }).then(data => {
            setData(data)
            dispatch({type: "SUCCESS", message: "Company added" })
            setIsPending(false)
            setPostError(null)
        }).catch(err => {
            if (err.name === "AbortError") {

            } else {
                setPostError(err.message)
                setIsPending(false)
            }
        })
        return () => abortFetch.abort();
    }

    return { post, data, isPending, postError }
}
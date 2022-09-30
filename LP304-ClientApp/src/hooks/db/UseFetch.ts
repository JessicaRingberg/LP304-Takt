import { useEffect, useState } from "react";
import { Cookies } from 'react-cookie';

const useFetch = (url: string) => {
    const [data, setData] = useState();
    const [isPending, setIsPending] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);
    var cookie = new Cookies();
    

    useEffect(() => {
        const abortFetch = new AbortController();
        const token: any = window.sessionStorage.getItem("token")

        fetch(url, {
            headers: { "Authorization": "Bearer " + cookie.get("token")},
            signal: abortFetch.signal
        }).then(res => {
                if (!res.ok) {
                    throw Error('Could not fetch the data for that resource')
                }
                return res.json()
            })
            .then(data => {
                setData(data)
                setIsPending(false)
                setError(null)
            })
            .catch(err => {
                if(err.name === "AbortError") {
                    
                } else {
                    setIsPending(false)
                    setError(err.message)
                }
            })
            return () => abortFetch.abort();
    }, [url])

    return { data, isPending, error }
}

export default useFetch;
import { useState } from "react";
import { Cookies } from 'react-cookie';

const useFetch = () => {
    const [data, setData] = useState();
    const [isPending, setIsPending] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);
    let cookie = new Cookies();


    const fetchEntity = (url: string) => {
        const abortFetch = new AbortController();

        fetch(url, {
            headers: { "Authorization": "Bearer " + cookie.get("token") },
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
                if (err.name === "AbortError") {

                } else {
                    setIsPending(false)
                    setError(err.message)
                }
            })
        return () => abortFetch.abort();
    }

    return {fetchEntity , data, isPending, error }
}

export default useFetch;
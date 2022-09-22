import { useEffect, useState } from "react";
<<<<<<<< HEAD:LP304-ClientApp/src/hooks/db/UseFetch.ts
========
import Company from '../../../models/Company';

>>>>>>>> development:LP304-ClientApp/src/hooks/db/usefetch/UseFetch.ts

const UseFetch = (url: string) => {
    const [data, setData] = useState();
    const [isPending, setIsPending] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null)

    useEffect(() => {
        const abortFetch = new AbortController();

        fetch(url, {signal: abortFetch.signal})
            .then(res => {
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

export default UseFetch;
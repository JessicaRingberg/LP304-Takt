import { useEffect, useState } from "react";
import Company from '../../models/Company';


const UseFetch = (url: string) => {
    const [data, setData] = useState<Company[]>();
    const [isPending, setIsPending] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null)

    useEffect(() => {
        fetch(url)
            .then(res => {
                if (!res.ok) {
                    throw Error('Could not fetch the data for that resource')
                }
                return res.json()
            })
            .then(data => {
                console.log(data)
                setData(data)
                setIsPending(false)
                setError(null)
            })
            .catch(err => {
                setIsPending(false)
                setError(err.message)
            })
    }, [])

    return { data, isPending, error }
}

export default UseFetch;
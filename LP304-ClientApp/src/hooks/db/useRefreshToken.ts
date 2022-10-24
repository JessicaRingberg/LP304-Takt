import { useEffect, useState } from "react";
import { Cookies } from 'react-cookie';

export const useRefreshToken = () => {
    const [isRefreshed, setIsRefreshed] = useState<boolean>(true);

    let cookie = new Cookies();
    const token: any = cookie.get("token")
    const refreshToken: any = cookie.get("refresh")

    const refresh = async () => {
        fetch('https://localhost:7112/api/User/refresh-token?token=' + encodeURIComponent(refreshToken), {
            method: 'POST',
            headers: { "Content-Type": "application/x-www-form-urlencoded" },
        }).then(res => {
            if (!res.ok) {
                setIsRefreshed(false)
                throw Error('Could not fetch the data for that resource')
            }
            return res.json()
        }).then(data => {
            cookie.set("token", data.data)
            cookie.set("refresh", data.message.split(" ")[2].split(":")[1])
        }).catch(err => {
            if (err.name === "AbortError") {

            } else {

            }
        })
    }

    return { refresh, isRefreshed }
}

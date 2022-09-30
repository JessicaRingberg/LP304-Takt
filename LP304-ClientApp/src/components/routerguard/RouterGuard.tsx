import { Route } from "react-router-dom";

const RouteGuard = ({ }) => {

    function hasJWT() {
        let flag = false;

        //check user has JWT token
        localStorage.getItem("token") ? flag = true : flag = false

        return flag
    }

    return (
        <div>
        </div>
    );
};

export default RouteGuard;
import jwtDecode from "jwt-decode";
import { Cookies } from "react-cookie";
import { Navigate } from "react-router-dom";
import { useAuthContext } from "../../hooks/db/useAuthContext";
import { useRefreshToken } from "../../hooks/db/useRefreshToken"

export type Props = {
  element: JSX.Element;
  authenticationPath: string;
  role: string[];
};


export default function ProtectedRoute({ element, authenticationPath, role }: Props) {
  const { state } = useAuthContext()
  const { refresh, isRefreshed } = useRefreshToken()
  const cookie = new Cookies()
  var jwt: any = jwtDecode(cookie.get('token'));
  var dateNow = Date.now().toString().substring(0, 10);
  var jwtNotExpired = jwt.exp > dateNow

  if (state.user.role && jwtNotExpired) {
    if (role.includes(state.user.role)) {
      return element;
    } else {
      return null;
    }
  } else if (!jwtNotExpired && state.user.keepLoggedIn) {
    refresh()
    if (isRefreshed) {
      return element;
    } else {
      return null
    }
  } else {
    return <Navigate to={{ pathname: authenticationPath }} />;
  }
};
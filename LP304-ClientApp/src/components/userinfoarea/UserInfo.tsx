import './UserInfo.css'
import User from '../../models/db/User'
import { useLogout } from '../../hooks/db/useLogout'

interface Props {
    showUserInfo: boolean,
    setShowUserInfo: React.Dispatch<React.SetStateAction<boolean>>,
    user: User
}

const UserInfo: React.FC<Props> = ({ showUserInfo, setShowUserInfo, user }) => {
    const { logout } = useLogout()

    const handleLogout = () => {
        logout()
    }

    return (
        <div className="user-info-container">
            {showUserInfo && <div className="user-info-content slide-in">
                <div>
                    <ul>
                        <p>Information</p>
                        <li>
                            <p>{user.firstName}</p>
                        </li>
                        <li>
                            <p>{user.lastName}</p>
                        </li>
                    </ul>
                </div>
                <button className="user-settings">Settings</button>
                <button onClick={handleLogout} className="user-logout" >Logout</button>
            </div>}
        </div>
    );
}

export default UserInfo;
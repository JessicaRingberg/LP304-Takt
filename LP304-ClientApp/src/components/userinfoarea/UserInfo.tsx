import './UserInfo.css'

interface Props {
    showUserInfo: boolean,
    setShowUserInfo: React.Dispatch<React.SetStateAction<boolean>>
}

const UserInfo: React.FC<Props> = ({ showUserInfo, setShowUserInfo }) => {
    const firstName: string = "Jonas";
    const lastName: string = "Fredriksson"

    return (
        <div className="user-info-container">
            {showUserInfo && <div className="user-info-content slide-in">
                <div>
                    <ul>
                        <p>Information</p>
                        <li>
                            <p>{firstName}</p>
                        </li>
                        <li>
                            <p>{lastName}</p>
                        </li>
                    </ul>
                </div>
                <button className="user-settings">Settings</button>
                <button className="user-logout">Logout</button>
            </div>}
        </div>
    );
}

export default UserInfo;
import { NavLink } from "react-router-dom";
import './Links.css'
import home from '../../../assets/icons/home.png'
import settings from '../../../assets/icons/settings.png'
import arrow from '../../../assets/icons/down-filled-triangular-arrow.png'
import { useState } from "react";
import { useAuthContext } from "../../../hooks/db/useAuthContext";

interface Props {
    handleMenuClose?: () => void;
}

const Links: React.FC<Props> = ({ handleMenuClose }) => {
    const { state } = useAuthContext()
    const [showSubSettings, setShowSubSettings] = useState(false);

    const handleSubSettingsOpen = (e: any) => {
        e.preventDefault();
        setShowSubSettings(true)
    }

    const handleSubSettingsClose = (e: any) => {
        e.preventDefault();
        setShowSubSettings(false)
    }

    return (
        <ul className="links">
            <li>
                <NavLink to="/" onClick={handleMenuClose} ><img src={home} alt="Takt" />Takt</NavLink>
            </li>
            <li>
                <NavLink to="/events" onClick={handleMenuClose} ><img src={home} alt="Events" />Events</NavLink>
            </li>
            <li>
                <NavLink to="/alarms" onClick={handleMenuClose} ><img src={home} alt="Alarms" />Alarms</NavLink>
            </li>
            <li onMouseLeave={handleSubSettingsClose}>
                <NavLink to="/settings" onClick={handleSubSettingsOpen} >
                    <img src={settings} alt="Settings" />
                    Settings
                    <img src={arrow} alt="settings" className="down-arrow" />
                </NavLink>
                {showSubSettings && <ul id="sub-settings" className="sub-links" onMouseLeave={handleSubSettingsClose}>
                    <li>
                        <NavLink to="/settings/companies" onClick={handleMenuClose} >General</NavLink>
                    </li>
                    {state.user?.role === "Admin" &&
                        <div className="admin-pages">
                            <li>
                                <NavLink to="/settings/companies" onClick={handleMenuClose} >Companies</NavLink>
                            </li>
                            <li>
                                <NavLink to="/settings/companies" onClick={handleMenuClose} >Users</NavLink>
                            </li>
                        </div>}
                    <li>
                        <NavLink to="/settings/mqtt" onClick={handleMenuClose} >MQTT</NavLink>
                    </li>
                </ul>}
            </li>
        </ul>
    );
}

export default Links;
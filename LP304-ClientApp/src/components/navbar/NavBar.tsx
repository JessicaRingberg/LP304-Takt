import './NavBar.css';
import logo from '../../assets/icons/logo.svg'
import menu from '../../assets/icons/menu.png'
import home from '../../assets/icons/home.png'
import account from '../../assets/icons/account.png'
import settings from '../../assets/icons/settings.png'
import arrow from '../../assets/icons/down-filled-triangular-arrow.png'
import { NavLink } from 'react-router-dom';
import Sidebar from '../sidebar/Sidebar';


function NavBar() {
    return (
        <div>
            <nav className="navbar">
                <img src={logo} className="app-logo" alt="logo" />
                <div className="links-container">
                    <div className="links">
                        <NavLink to="/"><img src={home} />Home</NavLink>
                        <NavLink to="/Takt"><img src={home} />Takt</NavLink>
                        <a href="/History"><img src={home} />History</a>
                        <a href="/Users"><img src={home} />Users</a>
                        <a href="/Settings"><img src={settings} />Settings<img className="down-arrow" src={arrow} /></a>

                    </div>
                </div>
                <div className="right-menu-context">
                    <div className="rest-connected">
                        <p>Rest-api
                            <span className="rest-status">●</span>
                        </p>
                    </div>
                    <div className="user-info">
                        <img src={account} className="account-icon" alt="account" />
                        <p>Jonas</p>
                    </div>
                    <img src={menu} onClick={Sidebar} className="burger-menu-icon" alt="Menu" />
                </div>
            </nav>
            <div className="submenu">
                <a href="/settings/bidisp4">BiDisp4</a>
                <a href="/settings/takt-configure">Takt configure</a>
                <a href="/settings/user-settings">User settings</a>
            </div>
        </div>
    );
}

export default NavBar;
import './NavBar.css';
import logo from '../../assets/icons/logo.svg'
import menu from '../../assets/icons/menu.png'
import account from '../../assets/icons/account.png'
import { useState } from 'react';
import Links from './links/Links';
import { NavLink } from 'react-router-dom';
import UserInfo from '../userinfoarea/UserInfo';
import { useAuthContext } from '../../hooks/db/useAuthContext';

const NavBar: React.FC = () => {
    const [menuOpen, setMenuOpen] = useState(false)
    const [showUserInfo, setShowUserInfo] = useState(false)
    const user= {id: 1, firstName: 'Jonas', lastName: 'Fredriksson', email: 'kofisk@hotmail.com', role: 'Admin'}
    const { state } = useAuthContext()

    const style = {
        display: 'flex'
      };

    const handleMenuOpen = () => {
        setMenuOpen(true)
    }

    const handleMenuClose = () => {
        setMenuOpen(false)
    }

    const handleUserOpen = () => {
        setShowUserInfo(true)
    }

    return (
        <header>

            <nav className="navbar">
                <NavLink to={"/"}><img src={logo} className="app-logo" alt="logo" /></NavLink>
                
                {menuOpen && <div className="links-container" style={style}>
                    <div className="menu-background" onClick={handleMenuClose}></div>

                    <Links handleMenuClose={handleMenuClose} />
                </div>}
                <div className="links-container">
                    <Links />
                </div>

                <div className="right-menu-context">
                    <div className="rest-connected">
                        <p>Rest-api
                            <span className="rest-status">●</span>
                        </p>
                    </div>
                    <div className="user-info" onClick={handleUserOpen}>
                        <img src={account} className="account-icon" alt="account" />
                        <p>{state.user?.firstName}</p>
                        <UserInfo showUserInfo={showUserInfo} setShowUserInfo={setShowUserInfo} user={user} />
                    </div>
                    <img src={menu} onClick={handleMenuOpen} className="burger-menu-icon" alt="Menu" />
                </div>
            </nav>

            <div className="submenu">
                <a href="/settings/bidisp4">BiDisp4</a>
                <a href="/settings/takt-configure">Takt configure</a>
                <a href="/settings/user-settings">User settings</a>
            </div>
        </header>
    );
}

export default NavBar;
import './Footer.css';
import logo from '../../assets/icons/logo.svg'

function Footer() {
    return (
        <footer className="footer">
            <img src={logo} />
            <p>Hedekullevägen 24</p>
            <p>461 38 Trollhättan</p>
            <p>SWEDEN</p>
        </footer>
    );
}

export default Footer;
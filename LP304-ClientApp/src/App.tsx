import NavBar from './components/navbar/NavBar';
import Takt from './pages/Takt/Takt';
import Footer from './components/footer/Footer';
import Events from './pages/events/Events';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Alarms from './pages/alarms/Alarms';
import Settings from './pages/settings/Settings';
import Login from './pages/login/Login';
import CompanySettings from './pages/settings/companysettings/CompanySettings';
import MqttConnection from './pages/settings/mqttconnection/MqttConnection';
import { useContext } from 'react';

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <NavBar />
        <Routes>
          <Route path="/" element={<Takt />} />
          <Route path="/events" element={<Events />} />
          <Route path="/alarms" element={<Alarms />} />
          <Route path="/settings" element={<Settings />} />
          <Route path="/settings/companies" element={<CompanySettings />} />
          <Route path="/settings/mqtt" element={<MqttConnection />} />
          <Route path="/login" element={<Login />} />
        </Routes>

        <Footer />
      </div>

    </BrowserRouter>
  );
}

export default App;

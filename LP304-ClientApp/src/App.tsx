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
import AreaSettings from './pages/settings/areasettings/AreaSettings';

function App() {

  function hasJWT() {
    let flag = false;

    console.log(window.sessionStorage.getItem("token"));
    
    fetch('https://localhost:7112/api/User/Verify', {
      method: 'POST',
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(window.sessionStorage.getItem("token"))
    }).then(res => {
      if (!res.ok) {
        throw Error('Could not fetch the data for that resource')
      }
      return res.json()
    }).then(data => {
      window.sessionStorage.setItem("token", data.data)
      console.log(data);
    }).catch(err => {
      if (err.name === "AbortError") {

      } else {

      }
    })
   
    return flag
}

  return (
    <BrowserRouter>
      <div className="App">
        <NavBar />
        <Routes>
          <Route path="/" element={hasJWT() ? <Takt /> : <Login/>} /> 
          <Route path="/events" element={<Events />} />
          <Route path="/events?page=:id" element={<Events />} />
          <Route path="/alarms" element={<Alarms />} />
          <Route path="/settings" element={<Settings />} />
          <Route path="/settings/companies" element={<CompanySettings />} />
          <Route path="/settings/companies/:id" element={<AreaSettings />} />
          <Route path="/settings/mqtt" element={<MqttConnection />} />
          <Route path="/login" element={<Login />} />
        </Routes>

        <Footer />
      </div>

    </BrowserRouter>
  );
}

export default App;

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
import ProtectedRoute from "./components/routerguard/RouterGuard";
import Message from "./components/message/Message";

function App() {

  return (
    <BrowserRouter>
    <Message />
      <div className="App">
        <NavBar />

        <Routes>
          <Route
            path='/*'
            element={
              <ProtectedRoute
                authenticationPath="/login"
                element={<Takt />}
                role={["User", "Admin"]} />}
          />
          <Route
            path="/events"
            element={
              <ProtectedRoute
                authenticationPath="/login"
                element={<Events />}
                role={["User","Admin"]} />}
          />
          <Route
            path="/events?page=:id"
            element={
              <ProtectedRoute
                authenticationPath="/login"
                element={<Events />}
                role={["User", "Admin"]} />}
          />
          <Route
            path="/alarms"
            element={
              <ProtectedRoute
                authenticationPath="/login"
                element={<Alarms />}
                role={["User", "Admin"]} />}
          />
          <Route
            path="/settings"
            element={
              <ProtectedRoute
                authenticationPath="/login"
                element={<Settings />}
                role={["User", "Admin"]} />}
          />
          <Route
            path="/settings/companies"
            element={
              <ProtectedRoute
                authenticationPath="/login"
                element={<CompanySettings />}
                role={["Admin"]} />}
          />
          <Route
            path="/settings/companies/:id"
            element={<ProtectedRoute
              authenticationPath="/login"
              element={<AreaSettings />}
              role={["User", "Admin"]} />}
          />
          <Route
            path="/settings/mqtt"
            element={<ProtectedRoute
              authenticationPath="/login"
              element={<MqttConnection />}
              role={["User", "Admin"]} />}
          />
          <Route
            path="/login"
            element={<Login />}
          />
        </Routes>

        <Footer />
      </div>
    </BrowserRouter>
  );
}

export default App;

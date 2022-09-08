import NavBar from './components/navbar/NavBar';
import Takt from './pages/Takt/Takt';
import Footer from './components/footer/Footer';
import Events from './pages/events/Events';
import { BrowserRouter, Route, Router, Routes } from 'react-router-dom';
import Alarms from './pages/alarms/Alarms';
import Settings from './pages/settings/Settings';

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <NavBar />
        <main>
          <Routes>
            <Route path="/" element={<Takt/>} />
            <Route path="/events" element={<Events/>} />
            <Route path="/alarms" element={<Alarms/>} />
            <Route path="/settings" element={<Settings/>} />
          </Routes>
        </main>
        <Footer />
      </div>
    </BrowserRouter>
  );
}

export default App;

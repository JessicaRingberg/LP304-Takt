import NavBar from './components/navbar/NavBar';
import Home from './pages/home/Home';
import Footer from './components/footer/Footer';
import Takt from './pages/order/Takt';
import { BrowserRouter, Route, Routes } from 'react-router-dom';

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <NavBar />
        <div className="content">
          <Routes>
            <Route path="/" element={<Home/>} />
            <Route path="/takt" element={<Takt/>} />
          </Routes>
          
        </div>
        <Footer />
      </div>
    </BrowserRouter>
  );
}

export default App;

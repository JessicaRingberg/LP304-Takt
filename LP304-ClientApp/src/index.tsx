import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import { AuthContextProvider } from './contexts/AuthContext';
import { MessageContextProvider } from './contexts/MessageContext';


const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

root.render(
  <React.StrictMode>
    <AuthContextProvider>
      <MessageContextProvider>
        <App />
      </MessageContextProvider>
    </AuthContextProvider>
  </React.StrictMode>
);
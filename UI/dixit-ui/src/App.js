import React from 'react';
import './App.css';
import StartPage from './pages/StartPage';
import { ToastProvider } from 'react-toast-notifications';

function App() {

  return (
    <ToastProvider placement='bottom-right' 
                    transitionDuration={400} 
                    autoDismissTimeout={3000} 
                    autoDismiss={true}>
      <StartPage/>
    </ToastProvider>
  );
}

export default App;

import React from 'react';
import './App.css';
import StartPage from './pages/StartPage/StartPage';
import GameRoomPage from './pages/GameRoom/GameRoomPage';
import { Route, Routes } from 'react-router-dom';
import { RootPages } from './constants/AppRoutes';

function App() {

  return (
    <Routes>
      <Route path={RootPages.START_PAGE} element={<StartPage/>} />
      <Route path={`${RootPages.ROOMS}/:id`} element={<GameRoomPage/>} />
    </Routes>
  );
}

export default App;
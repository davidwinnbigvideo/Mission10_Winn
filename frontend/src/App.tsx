import React, { useState } from 'react';
import './App.css';
import Header from './Header';
import BowlerList from './Bowler/BowlerList';

function App() {
  return (
    <div className="App">
      <Header title="List of Marlins and Sharks Bowlers" />
      <BowlerList />
    </div>
  );
}

export default App;

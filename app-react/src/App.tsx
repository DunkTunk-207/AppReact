import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Header from './components/Header/Header';
import Navigation from './components/Navigation/Navigation';
import Projects from './pages/Projects';
import Financials from './pages/Financials';
import Approvals from './pages/Approvals';
import Administration from './pages/Administration';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';

const App: React.FC = () => {
  return (
    <BrowserRouter>
      <div className="app">
        <Header />
        <Navigation />
        <main className="main-content">
          <Routes>
            <Route path="/" element={<Projects />} />
            <Route path="/financials" element={<Financials />} />
            <Route path="/approvals" element={<Approvals />} />
            <Route path="/administration" element={<Administration />} />
          </Routes>
        </main>
      </div>
    </BrowserRouter>
  );
};

export default App;
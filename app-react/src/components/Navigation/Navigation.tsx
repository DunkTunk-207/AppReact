// src/components/Navigation/Navigation.tsx
import React, { useState } from 'react';
import { NavLink } from 'react-router-dom';
import CreateProjectModal from '../Modal/CreateProjectModal';
import './Navigation.css';

const Navigation: React.FC = () => {
  const [isModalOpen, setIsModalOpen] = useState(false);

  return (
    <>
      <nav className="main-nav">
        <ul>
          <li>
            <NavLink to="/" end>Projects</NavLink>
          </li>
          <li>
            <NavLink to="/financials">Financials</NavLink>
          </li>
          <li>
            <NavLink to="/approvals">Approvals</NavLink>
          </li>
          <li>
            <NavLink to="/administration">Administration</NavLink>
          </li>
        </ul>
        <button 
          className="new-project-btn"
          onClick={() => setIsModalOpen(true)}
        >
          + New Project
        </button>
      </nav>

      <CreateProjectModal
        isOpen={isModalOpen}
        onClose={() => setIsModalOpen(false)}
      />
    </>
  );
};

export default Navigation;
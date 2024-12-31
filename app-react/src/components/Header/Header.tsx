import React from 'react';
import './Header.css';

const Header: React.FC = () => {
  return (
    <div className="header">
      <div className="logo">SLR | Sustain</div>
      <div className="user-info">Dang Tuan Anh</div>
    </div>
  );
};

export default Header;
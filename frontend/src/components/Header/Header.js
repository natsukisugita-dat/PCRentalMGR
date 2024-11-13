// src/components/Header/Header.js
import React from 'react';
import { Link } from 'react-router-dom';
import './Header.css';

const Header = () => {
  return (
    <header className="header">
      <nav className="navbar">
        <Link to="/" className="navbar-link">PC管理システム</Link>
        <Link to="/rentals" className="navbar-link">貸出履歴</Link>
        <Link to="/devices" className="navbar-link">機器情報一覧</Link>
        <Link to="/users" className="navbar-link">ユーザー情報一覧</Link>
      </nav>
    </header>
  );
};

export default Header;

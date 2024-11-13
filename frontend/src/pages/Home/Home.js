// src/pages/Home/Home.js
import React from 'react';
import './Home.css';

const Home = () => {
  const handleButtonClick = (pageName) => {
    console.log(`${pageName}に遷移`);
  };

  return (
    <div className="home">
      <button onClick={() => handleButtonClick('貸出状況一覧')} className="home-button">貸出状況一覧</button>
      <button onClick={() => handleButtonClick('機器情報一覧')} className="home-button">機器情報一覧</button>
      <button onClick={() => handleButtonClick('ユーザー情報一覧')} className="home-button">ユーザー情報一覧</button>
    </div>
  );
};

export default Home;

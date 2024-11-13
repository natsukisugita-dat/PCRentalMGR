// src/App.js
import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import './App.css';
import Header from './components/Header/Header';
import Home from './pages/Home/Home';
import UserList from './pages/UserList/UserList';
import UserCreate from './pages/User/UserCreate';
import UserDetail from './pages/User/UserDetails';
import UserEdit from './pages/User/UserEdit';
import DeviceList from './pages/DeviceList/DeviceList';
import DeviceCreate from './pages/DeviceList/DeviceCreate';
import DeviceEdit from './pages/DeviceList/DeviceEdit';
import DeviceDetails from './pages/DeviceList/DeviceDetails';
import RentalCreate from './pages/Rental/RentalCreate'; 
import RentalList from './pages/Rental/RentalList';
import RentalReturn from './pages/Rental/RentalReturn';
const App = () => {
  return (
    <Router>
      <div className="App">
        <Header />
        <Routes>
          <Route path="/" element={<Home />} />
          {/* ユーザー関連 */}
          <Route path="/users" element={<UserList />} />
          <Route path="/users/create" element={<UserCreate/>} />
          <Route path="/users/edit/:id" element={<UserEdit/>} />
          <Route path="/users/details/:id" element={<UserDetail/>} />
          {/* 機器関連 */}
          <Route path="/devices" element={<DeviceList/>} />
          <Route path="/devices/create" element={<DeviceCreate/>} />
          <Route path="/devices/edit/:id" element={<DeviceEdit/>} />
          <Route path="/devices/details/:id" element={<DeviceDetails/>} />
          {/* 貸出関連 */}
          <Route path="/rentals/create/:deviceId" element={<RentalCreate />} />
          <Route path="/rentals/:deviceId/return" element={<RentalReturn />} /> {/* ルートを追加 */}
          <Route path="/rentals" element={<RentalList />} />
        </Routes>
      </div>
    </Router>
  );
};

export default App;

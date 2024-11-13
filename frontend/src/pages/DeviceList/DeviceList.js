import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './DeviceList.css';

const DeviceList = () => {
  const [devices, setDevices] = useState([]);

  useEffect(() => {
    fetchDevices();
  }, []);

  const fetchDevices = async () => {
    try {
      const response = await axios.get(`${process.env.REACT_APP_API_BASE_URL}/api/devices`);
      setDevices(response.data);
    } catch (error) {
      console.error('デバイス情報の取得に失敗しました:', error);
    }
  };

  const handleRentalClick = async (deviceId, isRented) => {
    if (isRented) {
      const confirmReturn = window.confirm("返却しますか？");
      if (!confirmReturn) {
        return; // 「いいえ」が選ばれた場合は処理を終了
      }
      try {
        await axios.post(`${process.env.REACT_APP_API_BASE_URL}/api/rentals/${deviceId}/return`);
        alert("返却が完了しました。");
      } catch (error) {
        console.error('返却に失敗しました:', error);
      }
    } else {
      try {
        await axios.post(`${process.env.REACT_APP_API_BASE_URL}/api/rentals/create`, { deviceId });
        alert("貸出が完了しました。");
      } catch (error) {
        console.error('貸出に失敗しました:', error);
      }
    }
    fetchDevices(); // デバイス一覧を更新
  };

  return (
    <div className="device-list">
      <h1>機器一覧</h1>
      <table className="device-table">
        <thead>
          <tr>
            <th></th>
            <th>資産番号</th>
            <th>メーカー</th>
            <th>OS</th>
            <th>メモリ</th>
            <th>容量</th>
            <th>グラフィックボード</th>
            <th>保管場所</th>
            <th>故障</th>
            <th>貸出状態</th>
            <th>登録日</th>
            <th>更新日</th>
          </tr>
        </thead>
        <tbody>
          {devices.map(device => (
            <tr key={device.id}>
              <td>
                <button 
                  onClick={() => handleRentalClick(device.id, device.isRented)} 
                  className={device.isRented ? 'return-button' : 'rental-button'}
                >
                  {device.isRented ? '返却' : '貸出'}
                </button>
              </td>
              <td>{device.asset_no}</td>
              <td>{device.maker}</td>
              <td>{device.os}</td>
              <td>{device.memory}</td>
              <td>{device.capacity}</td>
              <td>{device.gpu}</td>
              <td>{device.store}</td>
              <td>{device.failure}</td>
              <td>{device.isRented ? '貸出中' : '利用可能'}</td>
              <td>{device.register_date}</td>
              <td>{device.edit_date}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default DeviceList;

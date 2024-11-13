import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams, useNavigate } from 'react-router-dom';
import './DeviceDetails.css';

const DeviceDetails = () => {
  const { id } = useParams();
  const [device, setDevice] = useState({});
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  // 機器データを取得するuseEffect
  useEffect(() => {
    const fetchDevice = async () => {
      try {
        const response = await axios.get(`${process.env.REACT_APP_API_BASE_URL}/api/devices/${id}`);
        setDevice(response.data);
        setLoading(false);
      } catch (error) {
        setError('機器データの取得に失敗しました');
        setLoading(false);
      }
    };
    fetchDevice();
  }, [id]);

  if (loading) return <p>Loading...</p>;
  if (error) return <p>{error}</p>;

  return (
    <div className="device-details-container">
      <h1>機器詳細</h1>
      <table className="device-details-table">
        <tbody>
          <tr>
            <th>資産番号</th>
            <td>{device.asset_no}</td>
          </tr>
          <tr>
            <th>メーカー</th>
            <td>{device.maker}</td>
          </tr>
          <tr>
            <th>機種</th>
            <td>{device.model}</td>
          </tr>
          <tr>
            <th>OS</th>
            <td>{device.os}</td>
          </tr>
          <tr>
            <th>メモリ</th>
            <td>{device.memory}</td>
          </tr>
          <tr>
            <th>容量</th>
            <td>{device.capacity}</td>
          </tr>
          <tr>
            <th>グラフィックボード</th>
            <td>{device.gpu}</td>
          </tr>
          <tr>
            <th>保管場所</th>
            <td>{device.store}</td>
          </tr>
          <tr>
            <th>登録日</th>
            <td>{new Date(device.register_date).toLocaleDateString()}</td>
          </tr>
          <tr>
            <th>故障</th>
            <td>{device.failure}</td>
          </tr>
        </tbody>
      </table>
      <button className="btn btn-secondary" onClick={() => navigate('/devices')}>戻る</button>
    </div>
  );
};

export default DeviceDetails;

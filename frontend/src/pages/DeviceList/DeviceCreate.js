import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import './DeviceCreate.css';  // CSSファイルをインポート

const DeviceCreate = () => {
  const [device, setDevice] = useState({
    asset_no: '',
    maker: '',
    os: '',
    memory: '',
    capacity: '',
    gpu: '',
    store: '',
    register_date: '',
    start:'',
    limit:'',
    remaker:'',
  });

  const [error, setError] = useState(null);
  const navigate = useNavigate();

  const handleChange = (e) => {
    const { name, value, type, checked } = e.target;
    setDevice({ ...device, [name]: type === 'checkbox' ? checked : value });
  };

  const axiosInstance = axios.create({
    baseURL: "http://localhost:7012",  // すでに設定済みのURL
    timeout: 5000,  // タイムアウトを5秒に設定
  });

  const handleSubmit = async (e) => {
    e.preventDefault();
    console.log('送信データ:', device);  // 送信データを確認
    try {
      const response = await axios.post(`${process.env.REACT_APP_API_BASE_URL}/api/devices`, device);
      if (response.status === 200 || response.status === 201) {
        navigate('/devices');  // 成功時にリダイレクト
      }
    } catch (err) {
      if (err.response && err.response.status === 409) {
        setError("既に同じ資産番号が存在します。別の番号を指定してください。");
      } else {
        setError("デバイスの作成に失敗しました。");
      }
      console.error("エラー詳細:", err.response ? err.response.data : err.message);
    }
  };
  

  return (
    <div className="device-create-container">
      <h1>機器新規作成</h1>
      {error && <p className="error">{error}</p>}
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="asset_no">資産番号</label>
          <input
            type="text"
            id="asset_no"
            name="asset_no"
            value={device.asset_no}
            onChange={handleChange}
            className="form-control"
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="maker">メーカー</label>
          <input
            type="text"
            id="maker"
            name="maker"
            value={device.maker}
            onChange={handleChange}
            className="form-control"
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="os">OS</label>
          <input
            type="text"
            id="os"
            name="os"
            value={device.os}
            onChange={handleChange}
            className="form-control"
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="memory">メモリ</label>
          <input
            type="text"
            id="memory"
            name="memory"
            value={device.memory}
            onChange={handleChange}
            className="form-control"
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="capacity">容量</label>
          <input
            type="text"
            id="capacity"
            name="capacity"
            value={device.capacity}
            onChange={handleChange}
            className="form-control"
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="gpu">グラフィックボード</label>
          <input
            type="text"
            id="gpu"
            name="gpu"
            value={device.gpu}
            onChange={handleChange}
            className="form-control"
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="store">保管場所</label>
          <input
            type="text"
            id="store"
            name="store"
            value={device.store}
            onChange={handleChange}
            className="form-control"
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="register_date">登録日</label>
          <input
            type="date"
            id="register_date"
            name="register_date"
            value={device.register_date}
            onChange={handleChange}
            className="form-control"
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="start">利用開始日</label>
          <input
            type="date"
            id="start"
            name="start"
            value={device.start}
            onChange={handleChange}
            className="form-control"
          />
        </div>

        <div className="form-group">
          <label htmlFor="limit">使用期限日</label>
          <input
            type="date"
            id="limit"
            name="limit"
            value={device.limit}
            onChange={handleChange}
            className="form-control"
          />
        </div>

        <div className="form-group">
          <label htmlFor="remaker">備考</label>
          <input
            type="text"
            id="remaker"
            name="remaker"
            value={device.remaker}
            onChange={handleChange}
            className="form-control"
          />
        </div>

        <button type="submit" className="btn btn-primary">作成</button>
        <button type="button" className="btn btn-secondary" onClick={() => navigate('/devices')}>キャンセル</button>
      </form>
    </div>
  );
};

export default DeviceCreate;

import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import axios from 'axios';
import './DeviceEdit.css';  // CSSファイルをインポート

const DeviceEdit = () => {
  const { id } = useParams();  // URLから機器IDを取得
  const navigate = useNavigate();
  const [device, setDevice] = useState({
    asset_no: '',
    maker: '',
    model: '',
    os: '',
    memory: '',
    capacity: '',
    gpu: '',
    store: '',
    register_date: '',
    failure: false,
  });
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchDevice = async () => {
      try {
        const response = await axios.get(`${process.env.REACT_APP_API_BASE_URL}/api/devices/${id}`);
        setDevice(response.data);
      } catch (err) {
        setError('機器データの取得に失敗しました');
      }
    };
    fetchDevice();
  }, [id]);

  const handleChange = (e) => {
    const { name, value, type, checked } = e.target;
    setDevice({ ...device, [name]: type === 'checkbox' ? checked : value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.put(`${process.env.REACT_APP_API_BASE_URL}/api/devices/${id}`, device);
      if (response.status === 200 || response.status === 204) {
        navigate('/devices');  // 成功時にリダイレクト
      }
    } catch (err) {
      setError('機器データの更新に失敗しました');
    }
  };

  return (
    <div className="device-edit-container">
      <h1>機器情報編集</h1>
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
          <label htmlFor="limit">更新日</label>
          <input
            type="date"
            id="limit"
            name="limit"
            value={device.limit}
            onChange={handleChange}
            className="form-control"
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="failure">故障</label>
          <input
            type="checkbox"
            id="failure"
            name="failure"
            checked={device.failure}
            onChange={handleChange}
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

        <button type="submit" className="btn btn-primary">更新</button>
        <button type="button" className="btn btn-secondary" onClick={() => navigate(`/devices/`)}>キャンセル</button>
      </form>
    </div>
  );
};

export default DeviceEdit;

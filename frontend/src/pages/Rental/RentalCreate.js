import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import axios from 'axios';

const RentalCreate = () => {
  const { deviceId } = useParams();
  const navigate = useNavigate();
  const [rentalData, setRentalData] = useState({
    deviceId: deviceId ? parseInt(deviceId, 10) : '', // deviceIdがURLパラメータに存在する場合のみ整数に変換
    UserId: '', // UserIdを保持
    rentalstart: '',
    rentallimit: '',
    remarks: '',
  });
  const [users, setUsers] = useState([]); // ユーザーリストを保存
  const [error, setError] = useState(null);

  useEffect(() => {
    // ユーザーデータを取得する関数
    const fetchUsers = async () => {
      try {
        const response = await axios.get(`${process.env.REACT_APP_API_BASE_URL}/api/users`);
        setUsers(response.data); // 取得したユーザーデータを状態に保存
      } catch (err) {
        setError('ユーザーデータの取得に失敗しました');
      }
    };

    fetchUsers();
  }, []);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setRentalData({ ...rentalData, [name]: value });
  };

  const handleUserChange = (e) => {
    const selectedUserId = e.target.value;
    setRentalData({ ...rentalData, UserId: selectedUserId }); // UserIdを設定
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await axios.post(`${process.env.REACT_APP_API_BASE_URL}/api/rentals`, rentalData);
      alert('貸出が登録されました');
      navigate('/rentals');
    } catch (error) {
      console.error('Error:', error.response?.data || error.message); // エラーの詳細を確認
    }
  };

  return (
    <div>
      <h1>貸出登録</h1>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      <form onSubmit={handleSubmit}>
        <div>
          <label>社員番号</label>
          <select
            name="UserId"
            value={rentalData.UserId}
            onChange={handleUserChange} // ユーザー選択時にUserIdを設定
            required
          >
            <option value="">社員番号を選択してください</option>
            {users.map((user) => (
              <option key={user.id} value={user.id}>
                {user.employee_no} - {user.name}
              </option>
            ))}
          </select>
        </div>
        <div>
          <label>貸出開始日</label>
          <input type="date" name="rentalstart" value={rentalData.rentalstart} onChange={handleChange} required />
        </div>
        <div>
          <label>返却期限</label>
          <input type="date" name="rentallimit" value={rentalData.rentallimit} onChange={handleChange} required />
        </div>
        <div>
          <label>備考</label>
          <textarea name="remarks" value={rentalData.remarks} onChange={handleChange}></textarea>
        </div>
        <button type="submit">登録</button>
        <button type="button" onClick={() => navigate('/devices')}>キャンセル</button>
      </form>
    </div>
  );
};

export default RentalCreate;

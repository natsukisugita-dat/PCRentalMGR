import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import axios from 'axios';

const RentalReturn = () => {
  const { rentalId } = useParams();  // URLパラメータからrentalIdを取得
  const { deviceId } = useParams(); // URLパラメータからdeviceIdを取得
  const [rental, setRental] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  const fetchRental = async (id) => {
    try {
      const response = await axios.get(`${process.env.REACT_APP_API_BASE_URL}/api/rentals/${id}`);
      setRental(response.data);
    } catch (error) {
      console.error('レンタル情報の取得に失敗しました:', error);
    }
  };

  useEffect(() => {
    if (!deviceId) {
      console.error('デバイスIDが無効です');
      return;
    }
    fetchRental(deviceId);
  }, [deviceId]);

  const handleReturn = async () => {
    try {
      // 返却処理のAPIリクエストを送信
      await axios.put(`${process.env.REACT_APP_API_BASE_URL}/api/rentals/return/${rentalId}`);
      navigate('/rentals');  // 返却後、貸出一覧に戻る
    } catch (error) {
      setError('返却処理に失敗しました');
    }
  };

  if (loading) return <p>Loading...</p>;
  if (error) return <p>{error}</p>;

  return (
    <div className="rental-return-container">
      <h1>返却処理</h1>
      {rental && (
        <div>
          <p>社員ID: {rental.employeeId}</p>
          <p>貸出日: {new Date(rental.rentalStart).toLocaleDateString()}</p>
          <p>返却期限: {new Date(rental.rentalLimit).toLocaleDateString()}</p>
          <p>機器ID: {rental.deviceId}</p>
          <button onClick={handleReturn} className="btn btn-primary">返却</button>
          <button onClick={() => navigate('/rentals')} className="btn btn-secondary">キャンセル</button>
        </div>
      )}
    </div>
  );
};

export default RentalReturn;

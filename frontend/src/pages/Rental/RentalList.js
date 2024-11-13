import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import './RentalList.css';

const RentalList = () => {
    const [rentals, setRentals] = useState([]);
    const [error, setError] = useState(null);

    // データ取得
    const fetchRentals = async () => {
        try {
            const response = await axios.get(`${process.env.REACT_APP_API_BASE_URL}/api/rentals`);
            setRentals(response.data);
        } catch (err) {
            setError('貸出データの取得に失敗しました');
            console.error("Error fetching rentals:", err);
        }
    };

    // 初回レンダリング時にデータを取得
    useEffect(() => {
        fetchRentals();
    }, []);

    return (
        <div>
            <h2>貸出履歴</h2>
            {error && <p style={{ color: 'red' }}>{error}</p>}
            <table className="rental-table">
                <thead>
                    <tr>
                        <th>資産番号</th>
                        <th>メーカー</th>
                        <th>OS</th>
                        <th>保管場所</th>
                        <th>社員番号</th>
                        <th>社員氏名</th>
                        <th>貸出日</th>
                        <th>返却日</th>
                        <th>備考</th>
                    </tr>
                </thead>
                <tbody>
                {rentals.map((rental) => (
            <tr key={rental.id}>
              <td>{rental.device?.asset_no || "---"}</td>
              <td>{rental.device?.maker || "---"}</td>
              <td>{rental.device?.os || "---"}</td>
              <td>{rental.device?.store || "---"}</td>
              <td>{rental.user?.employee_no || "---"}</td>
              <td>{rental.user?.name || "---"}</td>
              <td>{rental.rentalStart ? new Date(rental.rentalStart).toLocaleDateString() : "---"}</td>
              <td>{rental.rentallimit ? new Date(rental.rentallimit).toLocaleDateString() : "---"}</td>
              <td>{rental.remarks || "---"}</td>
            </tr>
            ))}
                </tbody>
            </table>
        </div>
    );
};

export default RentalList;

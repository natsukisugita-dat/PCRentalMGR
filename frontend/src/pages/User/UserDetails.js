import React, { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";  // useNavigateをインポート
import axios from "axios";
import "./UserDetails.css";  // CSSファイルをインポート

const UserDetails = () => {
  const { id } = useParams();
  const navigate = useNavigate();  // useNavigateを使用
  const [user, setUser] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchUser = async () => {
      try {
        const response = await axios.get(`${process.env.REACT_APP_API_BASE_URL}/api/users/${id}`);
        setUser(response.data);
        setLoading(false);
      } catch (err) {
        setError("ユーザーデータの取得に失敗しました");
        setLoading(false);
      }
    };

    fetchUser();
  }, [id]);

  if (loading) {
    return <p>Loading...</p>;
  }

  if (error) {
    return <p>{error}</p>;
  }

  const handleBack = () => {
    navigate("/users");  // useHistoryの代わりにuseNavigateを使用
  };

  return (
    <div className="user-details-container">
      <h1>ユーザー詳細</h1>
      <table className="user-details-table">
        <tbody>
          <tr>
            <th>社員番号</th>
            <td>{user.employee_no}</td>
          </tr>
          <tr>
            <th>名前</th>
            <td>{user.name}</td>
          </tr>
          <tr>
            <th>フリガナ</th>
            <td>{user.name_kana}</td>
          </tr>
          <tr>
            <th>部署</th>
            <td>{user.department}</td>
          </tr>
          <tr>
            <th>電話番号</th>
            <td>{user.tel_no}</td>
          </tr>
          <tr>
            <th>メールアドレス</th>
            <td>{user.mail_address}</td>
          </tr>
          <tr>
            <th>年齢</th>
            <td>{user.age}</td>
          </tr>
          <tr>
            <th>性別</th>
            <td>{user.gender === 0 ? "男性" : user.gender === 1 ? "女性" : "その他"}</td>
          </tr>
          <tr>
            <th>役職</th>
            <td>{user.position}</td>
          </tr>
          <tr>
            <th>アカウントレベル</th>
            <td>{user.account_level}</td>
          </tr>
        </tbody>
      </table>
      <div className="actions">
        <button className="btn btn-secondary" onClick={handleBack}>戻る</button>
      </div>
    </div>
  );
};

export default UserDetails;

// src/pages/UserList/UserList.js
import React, { useEffect, useState } from 'react';
import axios from 'axios';
import './UserList.css';

const UserList = () => {
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');

  // ユーザーデータをAPIから取得
  useEffect(() => {
    axios.get('https://localhost:5001/api/users') // APIのエンドポイントを指定
      .then(response => {
        setUsers(response.data);
        setLoading(false);
      })
      .catch(err => {
        setError('ユーザーデータの取得に失敗しました');
        setLoading(false);
      });
  }, []);

  if (loading) return <p>Loading...</p>;
  if (error) return <p>{error}</p>;

  return (
    <div>
      <h1>ユーザー一覧</h1>
      <p>
        <button className="btn btn-primary">新規登録</button>
      </p>
      <table className="table">
        <thead>
          <tr>
            <th>社員番号</th>
            <th>氏名</th>
            <th>氏名(カタカナ)</th>
            <th>所属部署</th>
            <th>電話番号</th>
            <th>メールアドレス</th>
            <th>年齢</th>
            <th>性別</th>
            <th>役職</th>
            <th>PCアカウント権限</th>
            <th>退職日</th>
            <th>登録日</th>
            <th>更新日</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {users.map(user => (
            <tr key={user.id}>
              <td>{user.employee_no}</td>
              <td>{user.name}</td>
              <td>{user.name_kana}</td>
              <td>{user.department}</td>
              <td>{user.tel_no}</td>
              <td>{user.mail_address}</td>
              <td>{user.age}</td>
              <td>{user.gender}</td>
              <td>{user.position}</td>
              <td>{user.account_level}</td>
              <td>{user.retire_date}</td>
              <td>{user.register_date}</td>
              <td>{user.update_date}</td>
              <td>
                <button className="btn btn-primary">詳細</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default UserList;

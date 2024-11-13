import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useNavigate } from "react-router-dom";
import './UserList.css';

const UserList = () => {
    const [users, setUsers] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [searchTerm, setSearchTerm] = useState('');
    const navigate = useNavigate();

    useEffect(() => {
        const fetchUsers = async () => {
            try {
                const response = await axios.get(`${process.env.REACT_APP_API_BASE_URL}/api/users`);
                setUsers(response.data);
                setLoading(false);
            } catch (err) {
                setError('ユーザーデータの取得に失敗しました');
                setLoading(false);
            }
        };
        fetchUsers();
    }, []);

    if (loading) return <p>Loading...</p>;
    if (error) return <p>{error}</p>;

    // 検索処理
    const handleSearchChange = (e) => {
        setSearchTerm(e.target.value);
    };

    // 検索機能
    const filteredUsers = users.filter(user =>
        user.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
        user.employee_no.toLowerCase().includes(searchTerm.toLowerCase()) ||
        user.department.toLowerCase().includes(searchTerm.toLowerCase()) ||
        user.position.toLowerCase().includes(searchTerm.toLowerCase()) ||
        user.account_level.toLowerCase().includes(searchTerm.toLowerCase())
    );

    return (
      <div className="user-list-container">
        <div className="search-add-container">
          <button className="add-user-button" onClick={() => navigate("/users/create")}>ユーザー新規登録</button>
          <input
            type="text"
            placeholder="名前、社員番号、部署、役職、権限のいずれかを入力して検索"
            className="search-bar"
            onChange={handleSearchChange}
          />
        </div>

            <table className="user-table">
                <thead>
                    <tr>
                        <th>社員番号</th>
                        <th>名前</th>
                        <th>フリガナ</th>
                        <th>部署</th>
                        <th>電話番号</th>
                        <th>メールアドレス</th>
                        <th>年齢</th>
                        <th>性別</th>
                        <th>役職</th>
                        <th>権限</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {filteredUsers.map(user => (
                        <tr key={user.id}>
                            <td>{user.employee_no}</td>
                            <td>{user.name}</td>
                            <td>{user.name_kana}</td>
                            <td>{user.department}</td>
                            <td>{user.tel_no}</td>
                            <td>{user.mail_address}</td>
                            <td>{user.age}</td>
                            <td>{user.gender === 0 ? '男性' : user.gender === 1 ? '女性' : 'その他'}</td>
                            <td>{user.position}</td>
                            <td>{user.account_level}</td>
                            <td>
                                <a href={`/users/edit/${user.id}`} className="btn btn-warning">編集</a>
                                <a href={`/users/details/${user.id}`} className="btn btn-info">詳細</a>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default UserList;

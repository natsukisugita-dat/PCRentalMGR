import React, { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import axios from "axios";
import GenderFactory from "../../utils/GenderFactory";
import "./UserEdit.css";

const UserEdit = () => {
  const { id } = useParams();
  const navigate = useNavigate();  // useHistory の代わりに useNavigate を使用
  const [user, setUser] = useState({
    employee_no: '',
    name: '',
    gender: '',
    department: '',
    email: '',
    update_date: '', // 初期値を追加
  });
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchUser = async () => {
      try {
        const response = await axios.get(`${process.env.REACT_APP_API_BASE_URL}/api/users/${id}`);
        setUser(response.data);
        const userData = response.data;
        userData.update_date = userData.update_date ? new Date(userData.update_date).toISOString().split('T')[0] : '';
        setUser(userData);
      } catch (err) {
        setError('ユーザーデータの取得に失敗しました');
      }
    };

    fetchUser();
  }, [id]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setUser({ ...user, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await axios.put(`${process.env.REACT_APP_API_BASE_URL}/api/users/${id}`, user);
      navigate('/users');  // 成功時にユーザー一覧ページに遷移
    } catch (err) {
      setError('ユーザーデータの更新に失敗しました');
    }
  };

  return (
    <div className="user-edit-container">
      <h1>ユーザー編集</h1>
      {error && <p className="error">{error}</p>}
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="employee_no">社員番号</label>
          <input
            type="text"
            id="employee_no"
            name="employee_no"
            value={user.employee_no}
            onChange={handleChange}
            className="form-control"
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="name">名前</label>
          <input
            type="text"
            id="name"
            name="name"
            value={user.name}
            onChange={handleChange}
            className="form-control"
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="name_kana">フリガナ</label>
          <input
            type="text"
            id="name_kana"
            name="name_kana"
            value={user.name_kana}
            onChange={handleChange}
            className="form-control"
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="department">部署</label>
          <input
            type="text"
            id="department"
            name="department"
            value={user.department}
            onChange={handleChange}
            className="form-control"
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="tel_no">電話番号</label>
          <input
            type="text"
            id="tel_no"
            name="tel_no"
            value={user.tel_no}
            onChange={handleChange}
            className="form-control"
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="mail_address">メールアドレス</label>
          <input
            type="text"
            id="mail_address"
            name="mail_address"
            value={user.mail_address}
            onChange={handleChange}
            className="form-control"
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="age">年齢</label>
          <input
            type="text"
            id="age"
            name="age"
            value={user.age}
            onChange={handleChange}
            className="form-control"
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="position">役職</label>
          <input
            type="text"
            id="position"
            name="position"
            value={user.position}
            onChange={handleChange}
            className="form-control"
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="account_level">アカウントレベル</label>
          <select
            type="text"
            id="account_level"
            name="account_level"
            value={user.account_level}
            onChange={handleChange}
            className="form-control"
            required
            >
              <option value="使用者">使用者</option>
              <option value="管理者">管理者</option>
            </select>
        </div>
        
        <div className="form-group">
          <label htmlFor="update_date">更新日</label>
          <input
            type="date"
            id="update_date"
            name="update_date"
            value={user.update_date}
            onChange={handleChange}
            className="form-control"
            required
          />
        </div>

        <button type="submit" className="btn btn-primary">保存</button>
        <button type="button" className="btn btn-secondary" onClick={() => navigate('/users')}>キャンセル</button>
      </form>
    </div>
  );
};

export default UserEdit;
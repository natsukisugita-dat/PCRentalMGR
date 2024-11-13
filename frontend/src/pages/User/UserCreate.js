import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";

const UserCreate = () => {
  const navigate = useNavigate();
  const [user, setUser] = useState({
    employee_no: "",
    name: "",
    name_kana: "",
    department: "",
    tel_no: "",
    mail_address: "",
    age: "",
    position: "",
    account_level: "使用者",
    gender: "",
    register_date: "",
    update_date: new Date().toISOString().split('T')[0],
  });
  const [errors, setErrors] = useState({});
  const [error, setError] = useState(null);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setUser({ ...user, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    const userData = { ...user };

    // retire_dateが空の場合に削除
    if (!userData.retire_date) {
      delete userData.retire_date;
    }

    try {
      await axios.post(`${process.env.REACT_APP_API_BASE_URL}/api/users`, userData);
      navigate("/users");
    } catch (err) {
      if (err.response) {
          console.error("エラーレスポンス詳細:", err.response.data);  // サーバーからのエラーメッセージを出力
          setError(err.response.data.title || 'ユーザーの作成に失敗しました');
      } else {
          console.error("リクエストエラー:", err);
          setError('リクエストエラーが発生しました');
      }
  }
  };

  return (
    <div className="user-create-container">
      <h1>ユーザー新規作成</h1>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label>社員番号</label>
          <input
            type="text"
            name="employee_no"
            value={user.employee_no}
            onChange={handleChange}
            className="form-control"
          />
          {errors.employee_no && <span className="text-danger">{errors.employee_no}</span>}
        </div>

        <div className="form-group">
          <label>名前</label>
          <input
            type="text"
            name="name"
            value={user.name}
            onChange={handleChange}
            className="form-control"
          />
          {errors.name && <span className="text-danger">{errors.name}</span>}
        </div>

        <div className="form-group">
          <label>フリガナ</label>
          <input
            type="text"
            name="name_kana"
            value={user.name_kana}
            onChange={handleChange}
            className="form-control"
          />
          {errors.name_kana && <span className="text-danger">{errors.name_kana}</span>}
        </div>

        <div className="form-group">
          <label>部署</label>
          <input
            type="text"
            name="department"
            value={user.department}
            onChange={handleChange}
            className="form-control"
          />
          {errors.department && <span className="text-danger">{errors.department}</span>}
        </div>

        <div className="form-group">
          <label>電話番号</label>
          <input
            type="text"
            name="tel_no"
            value={user.tel_no}
            onChange={handleChange}
            className="form-control"
          />
          {errors.tel_no && <span className="text-danger">{errors.tel_no}</span>}
        </div>

        <div className="form-group">
          <label>メールアドレス</label>
          <input
            type="email"
            name="mail_address"
            value={user.mail_address}
            onChange={handleChange}
            className="form-control"
          />
          {errors.mail_address && <span className="text-danger">{errors.mail_address}</span>}
        </div>

        <div className="form-group">
          <label>年齢</label>
          <input
            type="number"
            name="age"
            value={user.age}
            onChange={handleChange}
            className="form-control"
          />
          {errors.age && <span className="text-danger">{errors.age}</span>}
        </div>

        <div className="form-group">
          <label>性別</label>
          <select
            name="gender"
            value={user.gender}
            onChange={handleChange}
            className="form-control"
          >
            <option value="0">男性</option>
            <option value="1">女性</option>
            <option value="2">その他</option>
          </select>
          {errors.gender && <span className="text-danger">{errors.gender}</span>}
        </div>

        <div className="form-group">
          <label>役職</label>
          <input
            type="text"
            name="position"
            value={user.position}
            onChange={handleChange}
            className="form-control"
          />
          {errors.position && <span className="text-danger">{errors.position}</span>}
        </div>

        <div className="form-group">
          <label>権限</label>
          <select
            name="account_level"
            value={user.account_level}
            onChange={handleChange}
            className="form-control"
          >
            <option value="使用者">使用者</option>
            <option value="管理者">管理者</option>
          </select>
          {errors.account_level && <span className="text-danger">{errors.account_level}</span>}
        </div>

        <div className="form-group">
          <label>登録日</label>
          <input
            type="date"
            name="register_date"
            value={user.register_date}
            onChange={handleChange}
            className="form-control"
          />
          {errors.register_date && <span className="text-danger">{errors.register_date}</span>}
        </div>
        {/* 他の入力フィールドも同様に修正 */}
        <button type="submit" className="btn btn-primary">作成</button>
        <button type="button" className="btn btn-secondary" onClick={() => navigate('/users')}>キャンセル</button>
      </form>
    </div>
  );
};

export default UserCreate;

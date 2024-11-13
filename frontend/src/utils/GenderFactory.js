import React from "react";

const GenderFactory = ({ value, onChange }) => {
  return (
    <select name="gender" value={value} onChange={onChange} className="form-control">
      <option value={0}>男性</option>
      <option value={1}>女性</option>
      <option value={2}>その他</option>
    </select>
  );
};

export default GenderFactory;

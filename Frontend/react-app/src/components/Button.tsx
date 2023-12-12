import React from "react";
import "./Button.css";

/* Property Interface for Button */
interface ButtonProps {
  label: string;
  onClick: () => void;
  disabled?: boolean;
}

/* Initialize Button */
const Button: React.FC<ButtonProps> = ({ label, onClick, disabled }) => {
  return (
    <button className="entry-exit-button" onClick={onClick} disabled={disabled}>
      {label}
    </button>
  );
};

export default Button;

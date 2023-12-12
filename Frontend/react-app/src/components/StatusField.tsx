import React from "react";
import "./StatusField.css";

/* Property Interface for StatusField */
interface StatusFieldProps {
  status: "green" | "red";
}

/* Initialize StatusField */
const StatusField: React.FC<StatusFieldProps> = ({ status }) => {
  const icon = status === "green" ? "✓" : "✕";

  return <div className={`status-field ${status}`}>{icon}</div>;
};

export default StatusField;

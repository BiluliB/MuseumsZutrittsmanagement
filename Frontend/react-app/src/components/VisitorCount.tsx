import React from "react";
import "./VisitorCount.css";

/* Property Interface for VisitorCount */
interface VisitorCountProps {
  count: number;
}

/* Initialize VisitorCount */
const VisitorCount: React.FC<VisitorCountProps> = ({ count }) => {
  return <div className="visitor-count">Aktuelle Anzahl Besucher: {count}</div>;
};

export default VisitorCount;

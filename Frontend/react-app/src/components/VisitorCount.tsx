import React from "react";
import "./VisitorCount.css";

interface VisitorCountProps {
  currentVisitorCount: number;
}

const VisitorCount: React.FC<VisitorCountProps> = ({ currentVisitorCount }) => {
  return (
    <div className="visitor-count">
      {currentVisitorCount !== null
        ? `Aktuelle Anzahl Besucher: ${currentVisitorCount}`
        : "Fehler beim Abrufen der Daten"}
    </div>
  );
};

export default VisitorCount;

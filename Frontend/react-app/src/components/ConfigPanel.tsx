import React, { useState } from "react";
import "./ConfigPanel.css";

const ConfigPanel = () => {
  const [isEditing, setIsEditing] = useState(false);

  const toggleEditSave = () => {
    setIsEditing((prev) => !prev);
  };

  return (
    <div className="config-panel">
      <table>
        <thead>
          <tr>
            <th></th>
            <th>Museumsbereich 1</th>
            <th>Museumsbereich 2</th>
            <th>Aktionen</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <th>Öffnungszeiten</th>
            <td>19:00-21:00</td>
            <td>18:00-20:00</td>
            <td>
              <button onClick={toggleEditSave}>
                {isEditing ? "Speichern" : "Bearbeiten"}
              </button>
            </td>
          </tr>
          <tr>
            <th>Maximale Anzahl Personen</th>
            <td>19</td>
            <td>19</td>
            <td>
              <button onClick={toggleEditSave}>
                {isEditing ? "Speichern" : "Bearbeiten"}
              </button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  );
};

export default ConfigPanel;

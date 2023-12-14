import React, { useState, useEffect } from "react";
import { BrowserRouter as Router, Route, Routes, Link } from "react-router-dom";
import Button from "./components/Button";
import RadioButton from "./components/RadioButton";
import StatusField from "./components/StatusField";
import VisitorCount from "./components/VisitorCount";
import LoginForm from "./components/LoginForm";
import ConfigPanel from "./components/ConfigPanel";
import "./App.css";

function App() {
  const [selectedArea, setSelectedArea] = useState("area1");
  const [area1Visitors, setArea1Visitors] = useState(0);
  const [area2Visitors, setArea2Visitors] = useState(0);
  const [updateTrigger, setUpdateTrigger] = useState(0);
  const [maxVisitorsArea1, setMaxVisitorsArea1] = useState(50); // Standardwert 50
  const [maxVisitorsArea2, setMaxVisitorsArea2] = useState(50); // Standardwert 50

  useEffect(() => {
    fetchMaxVisitorCapacity();
    fetchCurrentVisitorCount();
  }, [selectedArea, updateTrigger]);

  const fetchMaxVisitorCapacity = async () => {
    try {
      const response = await fetch(
        `https://localhost:5000/api/VisitorCapacity`
      );
      if (!response.ok) {
        throw new Error(`HTTP-Status: ${response.status}`);
      }
      const capacities = await response.json();
      setMaxVisitorsArea1(
        capacities.find((c) => c.museumAreaId === 1).maxVisitorCount
      );
      setMaxVisitorsArea2(
        capacities.find((c) => c.museumAreaId === 2).maxVisitorCount
      );
    } catch (error) {
      console.error(
        "Fehler beim Abrufen der maximalen Besucherkapazität:",
        error
      );
    }
  };

  const fetchCurrentVisitorCount = async () => {
    const museumAreaId = selectedArea === "area1" ? 1 : 2;
    try {
      const response = await fetch(
        `https://localhost:5000/api/AccessLog/${museumAreaId}`
      );
      if (!response.ok) {
        throw new Error(`HTTP-Status: ${response.status}`);
      }
      const data = await response.json();
      if (selectedArea === "area1") {
        setArea1Visitors(data.currentVisitorCount);
      } else {
        setArea2Visitors(data.currentVisitorCount);
      }
    } catch (error) {
      console.error("Fehler beim Abrufen der aktuellen Besucherzahlen:", error);
    }
  };

  const updateVisitorCount = async (action) => {
    const museumAreaId = selectedArea === "area1" ? 1 : 2;
    const currentVisitorCount =
      selectedArea === "area1" ? area1Visitors : area2Visitors;
    const newVisitorCount =
      action === "Eintritt" ? currentVisitorCount + 1 : currentVisitorCount - 1;

    // Angenommen, Sie haben eine ID des zu aktualisierenden Eintrags
    const entryId = museumAreaId;

    try {
      const response = await fetch(
        `https://localhost:5000/api/AccessLog/${entryId}`,
        {
          method: "PUT",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            museumAreaId,
            currentVisitorCount: newVisitorCount,
          }),
        }
      );

      if (!response.ok) {
        throw new Error(`HTTP-Status: ${response.status}`);
      }

      // Aktualisieren des State nach dem erfolgreichen Update
      if (selectedArea === "area1") {
        setArea1Visitors(newVisitorCount);
      } else {
        setArea2Visitors(newVisitorCount);
      }
      setUpdateTrigger((prev) => prev + 1); // Aktualisieren des Update-Triggers
    } catch (error) {
      console.error("Fehler beim Senden des PUT-Requests:", error);
    }
  };

  const visitorCount = selectedArea === "area1" ? area1Visitors : area2Visitors;

  const handleRadioChange = (event) => {
    setSelectedArea(event.target.value);
  };

  const handleEntry = () => {
    const maxVisitors =
      selectedArea === "area1" ? maxVisitorsArea1 : maxVisitorsArea2;
    if (visitorCount < maxVisitors) {
      updateVisitorCount("Eintritt");
    }
  };

  const handleExit = () => {
    if (visitorCount > 0) {
      updateVisitorCount("Austritt");
    }
  };

  const isEntryDisabled = () => {
    const maxVisitors =
      selectedArea === "area1" ? maxVisitorsArea1 : maxVisitorsArea2;
    return visitorCount >= maxVisitors;
  };

  return (
    <Router>
      <div className="app-container">
        <nav>
          <Link to="/">Hauptseite</Link> | <Link to="/login">Einloggen</Link> |{" "}
          <Link to="/config">Konfigurationspanel</Link>
        </nav>
        <Routes>
          <Route
            path="/"
            element={
              <>
                <h1>Museumsbereich</h1>
                <div className="radio-button-group">
                  <RadioButton
                    label="Bereich 1"
                    name="area"
                    value="area1"
                    checked={selectedArea === "area1"}
                    onChange={handleRadioChange}
                  />
                  <RadioButton
                    label="Bereich 2"
                    name="area"
                    value="area2"
                    checked={selectedArea === "area2"}
                    onChange={handleRadioChange}
                  />
                </div>
                <Button
                  label="Eintritt"
                  onClick={handleEntry}
                  disabled={isEntryDisabled()} // Hier rufen Sie die Funktion auf
                />
                <Button label="Austritt" onClick={handleExit} />
                <StatusField status={isEntryDisabled() ? "red" : "green"} />

                <VisitorCount currentVisitorCount={visitorCount} />
              </>
            }
          />
          <Route path="/login" element={<LoginForm />} />
          <Route path="/config" element={<ConfigPanel />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;

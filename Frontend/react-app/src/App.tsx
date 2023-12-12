import Button from "./components/Button";
import RadioButton from "./components/RadioButton";
import StatusField from "./components/StatusField";
import VisitorCount from "./components/VisitorCount";
import "./App.css";
import { useState } from "react";

function App() {
  const [selectedArea, setSelectedArea] = useState("area1");
  const [area1Visitors, setArea1Visitors] = useState(0);
  const [area2Visitors, setArea2Visitors] = useState(0);

  const handleRadioChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setSelectedArea(event.target.value);
  };

  const handleEntry = () => {
    if (selectedArea === "area1" && area1Visitors < 50) {
      setArea1Visitors(area1Visitors + 1);
    } else if (selectedArea === "area2" && area2Visitors < 50) {
      setArea2Visitors(area2Visitors + 1);
    }
  };

  const handleExit = () => {
    if (selectedArea === "area1" && area1Visitors > 0) {
      setArea1Visitors(area1Visitors - 1);
    } else if (selectedArea === "area2" && area2Visitors > 0) {
      setArea2Visitors(area2Visitors - 1);
    }
  };

  const visitorCount = selectedArea === "area1" ? area1Visitors : area2Visitors;
  const isEntryDisabled = visitorCount >= 50;

  return (
    <div className="app-container">
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
        disabled={isEntryDisabled}
      />
      <Button label="Austritt" onClick={handleExit} />
      <StatusField status={isEntryDisabled ? "red" : "green"} />
      <VisitorCount count={visitorCount} />
    </div>
  );
}

export default App;

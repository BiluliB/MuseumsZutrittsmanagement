import React, { useState, useEffect } from "react";
import "./ConfigPanel.css";

interface ScheduleItem {
  id: number;
  museumAreaId: number;
  weekday: string;
  opens: string;
  closes: string;
}

interface UpdatedScheduleItem {
  id: number;
  museumAreaId: number;
  weekday: string;
  opens: string;
  closes: string;
}

interface VisitorCapacity {
  id: number;
  museumAreaId: number;
  maxVisitorCount: number;
}

const ConfigPanel = () => {
  const [schedule, setSchedule] = useState<ScheduleItem[]>([]);
  const [editingId, setEditingId] = useState<number | null>(null);
  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<string | null>(null);

  const [visitorCapacities, setVisitorCapacities] = useState<VisitorCapacity[]>(
    []
  );
  const [tempMaxVisitors, setTempMaxVisitors] = useState<string>("");
  const [isEditingVisitorCapacity, setIsEditingVisitorCapacity] = useState<
    number | null
  >(null);

  const [tempOpens, setTempOpens] = useState<string>("");
  const [tempCloses, setTempCloses] = useState<string>("");

  useEffect(() => {
    const fetchSchedule = async () => {
      setLoading(true);
      try {
        const response = await fetch("https://localhost:5000/api/OpeningHour");
        if (!response.ok) {
          throw new Error("Network response was not ok");
        }
        const data: ScheduleItem[] = await response.json();
        setSchedule(data);
      } catch (error) {
        if (error instanceof Error) {
          setError(error.message);
        } else {
          setError("An unknown error occurred");
        }
      } finally {
        setLoading(false);
      }
    };

    fetchSchedule();
  }, []);

  const handleEditClick = (item: ScheduleItem) => {
    setEditingId(item.id);
    setTempOpens(item.opens);
    setTempCloses(item.closes);
  };

  const handleSave = async (id: number) => {
    const currentScheduleItem = schedule.find((item) => item.id === id);
    if (!currentScheduleItem) {
      console.error("ScheduleItem nicht gefunden");
      return;
    }

    const updatedOpens = `${tempOpens}:00`;
    const updatedCloses = `${tempCloses}:00`;

    const updatedSchedule: UpdatedScheduleItem = {
      id: id,
      museumAreaId: currentScheduleItem.museumAreaId,
      weekday: currentScheduleItem.weekday,
      opens: updatedOpens,
      closes: updatedCloses,
    };

    try {
      const response = await fetch(
        `https://localhost:5000/api/OpeningHour/${id}`,
        {
          method: "PUT",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(updatedSchedule),
        }
      );

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }
      setEditingId(null);
    } catch (error) {
      if (error instanceof Error) {
        setError(error.message);
      } else {
        setError("An unknown error occurred");
      }
    } finally {
      setSchedule(
        schedule.map((item) =>
          item.id === id
            ? {
                ...item,
                opens: updatedSchedule.opens,
                closes: updatedSchedule.closes,
              }
            : item
        )
      );
    }
  };

  const handleEditVisitorCapacity = (capacity: VisitorCapacity) => {
    setIsEditingVisitorCapacity(capacity.id);
    setTempMaxVisitors(capacity.maxVisitorCount.toString());
  };

  const handleSaveVisitorCapacity = async (id: number) => {
    const updatedCapacity = {
      ...visitorCapacities.find((cap) => cap.id === id),
      maxVisitorCount: parseInt(tempMaxVisitors),
    };

    if (!updatedCapacity) {
      console.error("Kapazität zum Aktualisieren nicht gefunden");
      return;
    }

    try {
      const response = await fetch(
        `https://localhost:5000/api/VisitorCapacity/${id}`,
        {
          method: "PUT",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(updatedCapacity),
        }
      );

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      setVisitorCapacities((prev) =>
        prev.map((cap) =>
          cap.id === id
            ? { ...cap, maxVisitorCount: parseInt(tempMaxVisitors) }
            : cap
        )
      );
      setIsEditingVisitorCapacity(null);
    } catch (error) {
      if (error instanceof Error) {
        setError(error.message);
      } else {
        setError("An unknown error occurred");
      }
    }
  };

  useEffect(() => {
    const fetchVisitorCapacities = async () => {
      try {
        const response = await fetch(
          "https://localhost:5000/api/VisitorCapacity"
        );
        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }
        const data: VisitorCapacity[] = await response.json();
        setVisitorCapacities(data);
      } catch (error) {
        if (error instanceof Error) {
          setError(error.message);
        } else {
          setError("An unknown error occurred");
        }
      }
    };

    fetchVisitorCapacities();
  }, []);

  if (loading) {
    return <div>Loading...</div>;
  }

  if (error) {
    return <div>Error: {error}</div>;
  }

  return (
    <>
      <table className="ConfigPanel">
        <thead>
          <tr>
            <th>Museumsbereiche</th>
            <th>Wochentag</th>
            <th>Öffnet</th>
            <th>Schliesst</th>
            <th>Aktionen</th>
          </tr>
        </thead>
        <tbody>
          {schedule.map((entry) => (
            <tr key={entry.id}>
              <td>{`Bereich ${entry.museumAreaId}`}</td>
              <td>{entry.weekday}</td>
              <td>
                {editingId === entry.id ? (
                  <input
                    type="time"
                    value={tempOpens}
                    onChange={(e) => setTempOpens(e.target.value)}
                  />
                ) : (
                  entry.opens
                )}
              </td>
              <td>
                {editingId === entry.id ? (
                  <input
                    type="time"
                    value={tempCloses}
                    onChange={(e) => setTempCloses(e.target.value)}
                  />
                ) : (
                  entry.closes
                )}
              </td>
              <td>
                {editingId === entry.id ? (
                  <button onClick={() => handleSave(entry.id)}>
                    Speichern
                  </button>
                ) : (
                  <button onClick={() => handleEditClick(entry)}>
                    Bearbeiten
                  </button>
                )}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      <table className="ConfigPanel">
        <thead>
          <tr>
            <th>Museumsbereich</th>
            <th>Maximale Besucher</th>
            <th>Aktionen</th>
          </tr>
        </thead>
        <tbody>
          {visitorCapacities.map((capacity) => (
            <tr key={capacity.id}>
              <td>{`Museumsbereich ${capacity.museumAreaId}`}</td>
              <td>
                {isEditingVisitorCapacity === capacity.id ? (
                  <input
                    type="number"
                    min="0"
                    value={tempMaxVisitors}
                    onChange={(e) => setTempMaxVisitors(e.target.value)}
                  />
                ) : (
                  capacity.maxVisitorCount
                )}
              </td>
              <td>
                {isEditingVisitorCapacity === capacity.id ? (
                  <button
                    onClick={() => handleSaveVisitorCapacity(capacity.id)}
                  >
                    Speichern
                  </button>
                ) : (
                  <button onClick={() => handleEditVisitorCapacity(capacity)}>
                    Bearbeiten
                  </button>
                )}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
};

export default ConfigPanel;

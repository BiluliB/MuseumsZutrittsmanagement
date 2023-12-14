import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import "./LoginForm.css";

const LoginForm = () => {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [authError, setAuthError] = useState(false);
  const navigate = useNavigate();

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();
    setAuthError(false);

    try {
      const response = await fetch("https://localhost:5000/api/Auth/login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ username, password }),
      });

      if (response.ok) {
        navigate("/config");
      } else {
        setAuthError(true);
      }
    } catch (error) {
      console.error("Fehler bei der Anmeldung:", error);
      setAuthError(true);
    }
  };

  const inputClass = authError ? "input-error" : "";

  return (
    <div className="login-form-container">
      <form onSubmit={handleSubmit} className="login-form">
        <label>
          Benutzername:
          <input
            type="text"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
            className={inputClass}
          />
        </label>
        <label>
          Passwort:
          <input
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            className={inputClass}
          />
        </label>
        <button type="submit">Einloggen</button>
        {authError && (
          <div className="error-message">
            Falscher Benutzername oder Passwort
          </div>
        )}
      </form>
    </div>
  );
};

export default LoginForm;

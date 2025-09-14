# 🗓️ AI Calendar

![.NET](https://img.shields.io/badge/.NET-512BD4?logo=dotnet)
![Minimal API](https://img.shields.io/badge/Minimal%20API-lightgrey)
![Google Calendar API](https://img.shields.io/badge/Google%20Calendar%20API-00875C?logo=google-calendar)

An AI-powered scheduling app built with **.NET 9**, **Minimal API**, and **Google Calendar API**, designed to handle natural language event management. Users can **create, update, cancel, and list events** effortlessly.

---

## ✨ Features

- **Natural Language Scheduling** 💬: Schedule meetings using natural language.
  - *Example: "Book a meeting with Sandyaa at 3 PM tomorrow"*
- **Event Management** 🗓️: List all events and attendees, and dynamically create, update, and cancel events.
- **Secure Integration** 🔒: Google OAuth 2.0 integration for secure access.
- **Offline AI Model** 🧠 (Optional): Use an offline AI model (LLaMA / Ollama) for intent recognition and entity extraction.
- **Clean Architecture** 🏗️: A clean, layered architecture with API, Domain, Data, and Shared layers.

---

## ⚡ Prerequisites

- **.NET 9 SDK** ➡️ [Download Here](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- **Visual Studio 2022 / VS Code** 💻
- **Google Calendar API credentials** 🔑

---

## 🛠️ Setup

1.  **Clone repository**

    ```bash
    git clone [https://github.com/](https://github.com/)<your-username>/assignments.git
    cd assignments
    ```

2.  **Install NuGet packages**

    ```bash
    cd src/Api
    dotnet add package Google.Apis.Calendar.v3
    dotnet add package Google.Apis.Auth
    dotnet add package Google.Apis.OAuth2
    dotnet add package Newtonsoft.Json
    ```

3.  **Add Google OAuth Credentials**

    - Go to Google Cloud Console → APIs & Services → Credentials.
    - Create OAuth 2.0 Client ID (Web application).
    - Add redirect URI: `http://localhost`.
    - Download `credentials.json` → place in `/src/Api`.

4.  **Restore and build**

    ```bash
    cd ../../
    dotnet restore
    dotnet build
    ```

5.  **🚀 Run Locally**

    ```bash
    cd src/Api
    dotnet run
    ```

    - API endpoints available at: `https://localhost:5001`
    - Minimal API examples:
      - **List all events**: `GET /events`
      - **Create new event**: `POST /events`
      - **Get event by ID**: `GET /events/{id}`

---

## 💡 Optional AI Integration

-   Run with local LLaMA model via Ollama or LM Studio.
-   Handles:
    -   **Intent classification**: create/update/cancel/list
    -   **Entity extraction**: title, attendees, time
    -   Calls MCP tools for database updates.

---

## 🛠 Architecture Overview

-   **API Layer** → Minimal API endpoints, request validation.
-   **Domain Layer** → EventFactory, business rules.
-   **Data Layer** → EF Core, repositories, MCP server.
-   **Shared Layer** → DTOs, validation, models.

---

## 📌 Notes

-   All attendees must be valid email addresses for Google Calendar.
-   Deprecated Google `EventDateTime.DateTime` warnings are suppressed.
-   Nullable collections handled with `?? Array.Empty<string>()`.

---

## 🎯 Future Enhancements

-   Integrate LLaMA-based NLP fully for natural language scheduling.
-   Add recurring events & time zone conversions.
-   Enhance UI with Blazor / React for web dashboard.
-   Add notification system (email or push notifications).
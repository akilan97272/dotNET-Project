# Day 2 Progress

## ✅ Chosen API Style
We selected **REST with OpenAPI 3.1**.  
Reason: Best tooling, client support, and easy adoption for mobile/web apps.

## ✅ Contract
OpenAPI spec is stored in `/assignments/contracts/openapi.yaml`.

## ✅ Example Calls
- `GET /events` → List all events
- `POST /events` → Create an event
```json
{
  "title": "Team Sync",
  "start": "2025-09-10T10:00:00Z",
  "end": "2025-09-10T11:00:00Z",
  "attendees": ["aki@example.com", "sandyaa@example.com"]
}

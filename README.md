# ABC-Ignite-Gym-API

## Overview
ABC Ignite is a Software-as-a-Service (SaaS) solution for workout clubs and gyms to manage classes, memberships, and bookings. This project provides a REST API built with **.NET Core 9 Web API** to:

- Create classes
- Book members into classes
- Search for class bookings

## Technologies Used
- **.NET Core 9** (Web API)
- **C#**
- **Postman** (for testing API endpoints)
- **In-memory data storage** (no database required for this version)

---

## Setup Instructions
### **1. Prerequisites**
Ensure you have the following installed:
- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [Postman](https://www.postman.com/downloads/) for API testing

### **2. Clone the Repository**
```sh
git clone https://github.com/your-repo-url.git
cd ABC-Ignite-Gym-API
```

### **3. Run the API**
```sh
dotnet run
```

The API will start on `http://localhost:5101` (or another port if http://localhost:5101).

---

## API Endpoints
### **1. Create a Class**
#### **Endpoint:**
```http
POST /api/classes
```
#### **Request Body:**
```json
{
  "Name": "Pilates",
  "StartDate": "2025-02-01T00:00:00Z",
  "EndDate": "2025-02-20T00:00:00Z",
  "StartTime": "14:00:00",
  "Duration": "01:00:00",
  "Capacity": 10
}
```
#### **Response:**
```json
{
  "id": 1,
  "name": "Pilates",
  "startDate": "2025-02-01T00:00:00Z",
  "endDate": "2025-02-20T00:00:00Z",
  "startTime": "14:00:00",
  "duration": "01:00:00",
  "capacity": 10
}
```

---
### **2. Book a Class**
#### **Endpoint:**
```http
POST /api/bookings
```
#### **Request Body:**
```json
{
  "MemberName": "John Doe",
  "ClassId": 1,
  "ParticipationDate": "2025-02-01T14:00:00Z"
}
```
#### **Response:**
```json
{
  "id": 1,
  "memberName": "John Doe",
  "classId": 1,
  "participationDate": "2025-02-01T14:00:00Z"
}
```

---
### **3. Search Bookings**
#### **Endpoint:**
```http
GET /api/bookings?memberName=John&startDate=2025-02-01&endDate=2025-02-10
```
#### **Response:**
```json
[
  {
    "className": "Pilates",
    "startTime": "14:00:00",
    "bookingDate": "2025-02-01",
    "member": "John Doe"
  }
]
```

---

## Testing with Postman
1. Open **Postman**.
2. Send a `POST` request to `http://localhost:5101/api/classes` with the example JSON body.
3. Send a `POST` request to `http://localhost:5101/api/bookings`.
4. Use `GET /api/bookings` to retrieve bookings.

---

## Future Improvements
- We can add authentication (JWT-based)
- We Integrate with a database (e.g., SQL Server, PostgreSQL)
- We can add a frontend UI.

## Author
[Bhanu Shankar Dourla] - 2025



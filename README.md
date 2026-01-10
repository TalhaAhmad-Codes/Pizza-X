
---

# 🍕 Pizza X

**Pizza X** is a modular **POS & CRM system** designed for scalability, maintainability, and multi-platform support.
It follows **Clean Architecture principles**, with a shared backend and multiple frontends consuming the same APIs.

---

## 📌 Project Overview

**Pizza X** is built to support real-world restaurant operations such as:

* Point of Sale (POS)
* Customer Relationship Management (CRM)
* Multi-device usage (Desktop & Web)
* Cloud-ready backend architecture

The system is structured as a **single GitHub repository with multiple branches**, each representing a major module.

---

## 🧱 Architecture Overview

```
Pizza X
│
├── Backend (ASP.NET Web APIs)
│   ├── Domain
│   ├── Application
│   ├── Infrastructure
│   └── WebAPIs
│
├── Desktop Frontend (WPF)
│   └── MVVM Pattern (Consumes Backend APIs)
│
├── Web Frontend (React)
│   └── React + Bootstrap (Consumes Backend APIs)
```

✔ Business logic lives **only in the backend**
✔ Frontends are **thin API consumers**
✔ Clean separation of concerns

---

## 🌿 Branch Strategy

Each major module lives in its **own branch**:

| Branch Name        | Purpose                                 |
| ------------------ | --------------------------------------- |
| `main`             | Root branch (governance, configs, docs) |
| `backend`          | ASP.NET Web APIs                        |
| `desktop-frontend` | WPF (.NET 10) Desktop App               |
| `web-frontend`     | React Web Application                   |
| `documentation`    | Architecture docs, diagrams, manuals    |

> ⚠️ No direct feature development happens in `main`.

---

## 🛠 Tech Stack

### Backend

* **Framework:** ASP.NET Web APIs
* **Language:** C#
* **SDK:** .NET 10
* **ORM:** Entity Framework
* **Architecture:** Clean Architecture

### Desktop Frontend

* **Framework:** WPF
* **Language:** C#
* **SDK:** .NET 10
* **Pattern:** MVVM

### Web Frontend

* **Framework:** React
* **UI:** Bootstrap
* **Languages:** HTML, CSS, JavaScript

### Database

* **Initial:** Local Database (Development)
* **Production:** Cloud DB (SmarterASP.NET)

---

## 🧪 Development Tools

| Tool          | Usage                      |
| ------------- | -------------------------- |
| Visual Studio | Backend & WPF Development  |
| VS Code       | React Development          |
| Git           | Version Control            |
| GitHub        | Repository & Collaboration |

---

## 📁 Repository Rules

* `.gitignore` is centralized in `main`
* Each branch is **self-contained**
* Shared logic **must never be duplicated**
* Frontends communicate **only via APIs**

---

## 📚 Documentation

All documentation is maintained in the `documentation` branch, including:

* Architectural diagrams
* ADRs (Architectural Decision Records)
* User manuals
* Draw.io files
* Technical notes

---

## 🚀 Getting Started

1. Clone the repository
2. Checkout the required branch:

   ```bash
   git checkout backend
   ```
3. Open:

   * **Backend / WPF** → Visual Studio
   * **React** → VS Code
4. Configure local database
5. Run & develop

---

## 🔐 Environment & Configuration

* Sensitive files (`appsettings.Local.json`, `.env`) are **not committed**
* Use environment-specific configs locally
* Cloud configuration will be added later

---

## 🤝 Contribution Guidelines

* Follow branch responsibilities
* Keep commits atomic and descriptive
* Do not push directly to `main`
* Use Pull Requests for integration

---

## 📄 License

This project is licensed under [MIT](/LICENSE).

---

## ✨ Status

🚧 **Active Development**
Architecture & foundations for backend are being finalized.

---

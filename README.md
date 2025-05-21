# 🎫 AdmisionOperCanarios

> Access control platform developed for **Grupo Oper**, designed to manage and regulate customer entry to gaming venues.  
> The system integrates internal evaluations and government database checks to allow or deny access based on customer risk profiles.

---

## 🧭 Overview

**AdmisionOperCanarios** is a web-based solution for managing real-time access to gaming venues. It identifies restricted or flagged individuals and ensures compliance with industry regulations and safety protocols. The platform allows operators to automatically assess entry eligibility based on behavioral flags or voluntary exclusion lists.

---

## 🧰 Tech Stack and Tools

| Area                | Technologies / Tools                           |
|---------------------|-------------------------------------------------|
| Backend Language    | C#                                              |
| Backend Framework   | ASP.NET Core                                    |
| Frontend Language   | JavaScript                                      |
| Frontend Framework  | React.js                                        |
| Database            | MariaDB (managed via HeidiSQL)                 |
| API Testing         | Postman                                         |
| Security            | JSON Web Tokens (JWT), custom middleware        |
| Containers          | Docker, docker-compose                          |
| Version Control     | Git + GitHub                                    |
| CI/CD               | GitHub Actions                                  |

---

## 🧩 Project Structure

```
AdmisionOperCanarios/
├── frontend/          # React web interface
├── backend/           # ASP.NET Core RESTful API
│   ├── Controllers/   # HTTP endpoints
│   ├── Services/      # Business logic
│   └── Models/        # Domain entities
├── docker-compose.yml # Docker orchestration
└── README.md
```

---

## 🚀 Local Deployment

### Clone the repository

```bash
git clone https://github.com/JoseGlezHerrera/AdmisionOperCanarios.git
cd AdmisionOperCanarios
```

### Start with Docker

```bash
docker-compose up --build
```

The app will run on your default browser (e.g., http://localhost:3000).

---

## 🔐 Security and Access Control

- Authentication via **JSON Web Tokens (JWT)**
- Identity validation with custom middleware in ASP.NET Core
- Role-based access and policy enforcement

---

## 🔄 Functional Workflow

1. The operator inputs a customer's **DNI** (national ID).
2. The system checks:
   - Internal lists of flagged or problematic individuals.
   - Official exclusion records (e.g., self-banned from gambling).
3. An automatic access **decision is returned**.
4. All access attempts are **logged for auditing**.

---

## 📡 REST API – Examples

### `GET /api/clients`

```json
[
  {
    "id": "1",
    "name": "María González",
    "dni": "98765432Z",
    "entryDate": "2025-05-14T11:12:00Z",
    "status": "normal"
  }
]
```

### `POST /api/clients`

```json
{
  "name": "Carlos Ramos",
  "dni": "12345678A"
}
```

---

## 📁 MariaDB Setup / SQL Scripts

- Database managed using **HeidiSQL**
- Schema includes a client table with the following fields:
  - `id`, `name`, `dni`, `entryDate`, `status`

(*Note: the repository does not contain any real personal data.*)

---

## 👨‍💻 Author

**José González Herrera**  
🌍 [github.com/JoseGlezHerrera](https://github.com/JoseGlezHerrera)

---

## 📄 License

Distributed under the MIT License. See the [`LICENSE`](LICENSE) file for details.

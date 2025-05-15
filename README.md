# 🎫 AdmisionOperCanarios

> Plataforma de control de acceso desarrollada para **Grupo Oper**, destinada a verificar y regular la entrada de clientes en salas de juego.  
> El sistema integra evaluaciones internas y validaciones con organismos gubernamentales para permitir o denegar el acceso según distintos perfiles de riesgo.

---

## 📘 Descripción

**AdmisionOperCanarios** es una solución digital diseñada para controlar el acceso a establecimientos de Grupo Oper en Canarias y Madrid. El sistema evalúa en tiempo real si un cliente debe ser admitido o no, cruzando datos con registros internos y fuentes oficiales.

Permite identificar clientes conflictivos, personas con autoprohibición por ludopatía u otras restricciones, y actuar en consecuencia según criterios normativos y operativos. Su objetivo es garantizar un entorno seguro, legalmente conforme y alineado con la responsabilidad social corporativa.

---

## 🧰 Tecnologías utilizadas

| Capa          | Tecnología            |
|---------------|------------------------|
| Backend       | ASP.NET Core (C#)      |
| Frontend      | React.js               |
| Base de Datos | MongoDB                |
| Autenticación | JSON Web Tokens (JWT)  |
| DevOps        | Docker, GitHub Actions |

---

## 🗂️ Estructura del proyecto

```
AdmisionOperCanarios/
├── frontend/      # Interfaz web construida con React
├── backend/       # API REST desarrollada en ASP.NET Core
└── docker-compose.yml
```

---

## ⚙️ Instalación y despliegue

1. Clona el repositorio:

```bash
git clone https://github.com/JoseGlezHerrera/AdmisionOperCanarios.git
cd AdmisionOperCanarios
```

2. Ejecuta la aplicación en modo desarrollo:

```bash
docker-compose up --build
```

---

## 🔐 Autenticación

El sistema utiliza autenticación mediante **JWT**, aplicando middleware en ASP.NET Core para proteger endpoints sensibles y aplicar políticas según roles definidos.

---

## 📡 API – Ejemplos

### `GET /api/clients`

```json
[
  {
    "id": "abc123",
    "name": "Juan Pérez",
    "dni": "12345678A",
    "entryDate": "2025-05-14T10:00:00Z",
    "status": "conflictivo"
  }
]
```

### `POST /api/clients`

```json
{
  "name": "Lucía López",
  "dni": "87654321B"
}
```

---

## 🤝 Contribuciones

Las contribuciones están abiertas. Puedes enviar un *pull request* o abrir un *issue* para sugerencias, mejoras o reportes de errores.

---

## 👨‍💻 Autor

**José González Herrera**  
🌐 [github.com/JoseGlezHerrera](https://github.com/JoseGlezHerrera)

---

## 📄 Licencia

Distribuido bajo la licencia MIT. Revisa el archivo [`LICENSE`](LICENSE) para más detalles.

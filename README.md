# 📘 AddressBookApp (.NET Minimal API)

Este proyecto implementa un backend RESTful para una aplicación de libreta de direcciones utilizando **.NET 8**, **Minimal APIs** y **Swagger**. La arquitectura sigue los principios de la **Arquitectura Limpia (Clean Architecture)**, separando las responsabilidades en capas bien definidas: Dominio, Aplicación, Infraestructura e Interfaz.

---

## ✅ Características

- `GET /contacts`  
  Devuelve todos los contactos ordenados alfabéticamente por nombre.  
  Soporta filtrado opcional mediante el parámetro de consulta `phrase` (insensible a mayúsculas/minúsculas).

- `GET /contacts/{id}`  
  Devuelve los detalles de un contacto específico por su ID.

- `DELETE /contacts/{id}`  
  Elimina un contacto por su ID. Devuelve `204 No Content` si fue exitoso.

---

## ⚙️ Detalles de implementación

- La fuente de datos es una **base falsa en memoria** ideal para pruebas y demostraciones (portada desde un `fakedatabase.js` original).
- Manejo de errores conforme al estándar:
  - `400 Bad Request` si `phrase=` está vacío.
  - `404 Not Found` para rutas o IDs inexistentes.
  - `405 Method Not Allowed` para métodos no permitidos en rutas válidas.
  - `204 No Content` al eliminar correctamente un contacto.
- Incluye **Swagger UI** para documentación y pruebas de los endpoints de forma visual.

---

## 🚀 Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)

---

## ▶️ Cómo ejecutar

1. Clona el repositorio:
   ```bash
   git clone https://github.com/carlosqm09/AddressBookApp.git
   cd AddressBookApp
   ```

2. Restaura dependencias y ejecuta:
   ```bash
   dotnet run --project API
   ```

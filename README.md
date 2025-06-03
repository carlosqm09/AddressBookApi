# 📘 Libreta de Contactos - API REST

Este proyecto implementa una **API REST** para gestionar una libreta de contactos, creada con **.NET 8**, **Minimal API**, y principios de **Clean Architecture**. Incluye una interfaz Swagger personalizada para documentación y pruebas.

---

## 🧱 Estructura del proyecto

- **Domain**: Entidades del dominio (ej. `Contact`)
- **Application**: Interfaces como `IContactService`
- **Infrastructure**: Servicio `JsonContactService` que simula una base de datos con un archivo `fakedatabase.json`
- **API**: Punto de entrada principal con endpoints minimalistas y documentación Swagger

---

## 📂 Archivo `fakedatabase.json`

Los datos de los contactos se almacenan en `API/Infrastructure/Data/fakedatabase.json`.  
- Si el archivo no existe, se genera automáticamente con 10 contactos ficticios basados en personajes de Pokémon.
- Este diseño permite sustituir fácilmente la fuente de datos por una base real (como SQL Server o EF Core) sin modificar la capa de aplicación o la API.
- Vista del archivo [fakedatabase.json](https://github.com/carlosqm09/AddressBookApi/blob/master/API/Docs/Data/fakedatabase.json)
---

## 🔗 Endpoints disponibles

| Método | Ruta                 | Descripción                             |
|--------|----------------------|-----------------------------------------|
| GET    | `/contacts`          | Lista todos los contactos               |
| GET    | `/contacts?phrase=xy`| Filtra por nombre (case-insensitive)    |
| GET    | `/contacts/{id}`     | Devuelve un contacto por su ID          |
| DELETE | `/contacts/{id}`     | Elimina un contacto por su ID           |

Los métodos `POST`, `PUT` y `PATCH` devolverán `405 Method Not Allowed`.

## 🧪 Pruebas con Postman

Se incluye una colección de Postman para probar los endpoints disponibles, incluyendo pruebas para códigos `405`.

- 👉 [Colección completa con variable baseUrl](https://github.com/carlosqm09/AddressBookApi/blob/master/API/Docs/AddressBook%20API.postman_collection.json)

Importa los archivos en Postman y asegúrate de establecer la variable `baseUrl` con tu `LOCALHOST`.

---

## 🖼 Capturas

- 📷Vista general de Swagger personalizada
  
 ![Swagger UI](https://raw.githubusercontent.com/carlosqm09/AddressBookApi/refs/heads/master/API/Docs/img/API_UI.png)

- 📷Resultado de los endpoints
  
 ![Ejemplo de respuesta JSON](https://raw.githubusercontent.com/carlosqm09/AddressBookApi/refs/heads/master/API/Docs/img/Example_response.png)

- 📷Coleccion de pruebas en Postman
  
 ![Postman](https://raw.githubusercontent.com/carlosqm09/AddressBookApi/refs/heads/master/API/Docs/img/Postman_test.png)

---

## 👨‍💻 Autor

**Carlos Quijada**  
[GitHub](https://github.com/carlosqm09) · carmanu09@gmail.com

---
